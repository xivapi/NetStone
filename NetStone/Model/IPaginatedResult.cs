using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HtmlAgilityPack;
using NetStone.Definitions.Model;
using NetStone.Search;

namespace NetStone.Model;

/// <summary>
/// Models data that is presented over multiple pages
/// </summary>
/// <typeparam name="T">Type of data presented</typeparam>
public interface IPaginatedResult<T> where T : LodestoneParseable
{
    /// <summary>
    /// Currently handled page
    /// </summary>
    int CurrentPage { get; }

    /// <summary>
    /// Total number of pages
    /// </summary>
    int NumPages { get; }

    /// <summary>
    /// Gets the next page of results
    /// </summary>
    /// <returns>Task of retrieving next page</returns>
    Task<T?> GetNextPage();
}

/// <summary>
/// Container class holding paginated information
/// </summary>
public abstract class PaginatedIdResult<TPage, TEntry, TEntryDef> 
    : PaginatedResult<TPage, TEntry, TEntryDef,string> where TPage : LodestoneParseable 
                                                       where TEntry : LodestoneParseable 
                                                       where TEntryDef : PagedEntryDefinition
{
    ///<inheritdoc />
    protected PaginatedIdResult(HtmlNode rootNode, PagedDefinition<TEntryDef> pageDefinition, 
                                Func<string, int, Task<TPage?>> nextPageFunc, string id) 
        : base(rootNode, pageDefinition, nextPageFunc, id)
    {
    }
}
/// <summary>
/// Container class holding paginated information
/// </summary>
public abstract class PaginatedSearchResult<TPage, TEntry, TEntryDef, TQuery> 
    : PaginatedResult<TPage, TEntry, TEntryDef,TQuery> where TPage : LodestoneParseable 
                                                       where TEntry : LodestoneParseable 
                                                       where TEntryDef : PagedEntryDefinition
                                                       where TQuery : ISearchQuery
{
    ///<inheritdoc />
    protected PaginatedSearchResult(HtmlNode rootNode, PagedDefinition<TEntryDef> pageDefinition, 
                                    Func<TQuery, int, Task<TPage?>> nextPageFunc, 
                                    TQuery query) 
        : base(rootNode, pageDefinition, nextPageFunc, query)
    {
    }
}


/// <summary>
    /// Container class holding paginated information
    /// </summary>
    public abstract class PaginatedResult<TPage, TEntry, TEntryDef,TRequest> : LodestoneParseable, IPaginatedResult<TPage> where TPage : LodestoneParseable where TEntry : LodestoneParseable where TEntryDef : PagedEntryDefinition
    {
    /// <summary>
    /// Definition for the paginated type
    /// </summary>
    protected readonly PagedDefinition<TEntryDef> PageDefinition;

    private readonly TRequest request;
    
    private readonly Func<TRequest, int, Task<TPage?>> nextPageFunc;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="rootNode">The root document node of the page</param>
    /// <param name="pageDefinition">CSS definitions for the paginated type</param>
    /// <param name="nextPageFunc">Function to retrieve a page of this type</param>
    /// <param name="request">The input used to request further pages.</param>
    protected PaginatedResult(HtmlNode rootNode, PagedDefinition<TEntryDef> pageDefinition,Func<TRequest, int, Task<TPage?>> nextPageFunc, TRequest request) : base(rootNode)
    {
        this.PageDefinition = pageDefinition;
        this.request = request;
        this.nextPageFunc = nextPageFunc;
    }

    /// <summary>
    /// If there is any data
    /// </summary>
    public bool HasResults => this.PageDefinition.NoResultsFound is null || !HasNode(this.PageDefinition.NoResultsFound);
    
    private TEntry[]? parsedResults;
    
    /// <summary>
    /// List of members
    /// </summary>
    protected IEnumerable<TEntry> Results
    {
        get
        {
            if (!this.HasResults) return Array.Empty<TEntry>();
            this.parsedResults ??= ParseResults();
            return this.parsedResults;
        }
    }

    /// <summary>
    /// Creates the array of all entries on this page>
    /// </summary>
    protected abstract TEntry[] ParseResults();
    
    private int? currentPageVal;

    ///<inheritdoc />
    public int CurrentPage
    {
        get
        {
            if (!this.HasResults)
                return 0;
            if (!this.currentPageVal.HasValue)
                ParsePagesCount();

            return this.currentPageVal!.Value;
        }
    }

    private int? numPagesVal;

    /// <inheritdoc/>
    public int NumPages
    {
        get
        {
            if (!this.HasResults)
                return 0;
            if (!this.numPagesVal.HasValue)
                ParsePagesCount();

            return this.numPagesVal!.Value;
        }
    }
    private void ParsePagesCount()
    {
        var results = ParseRegex(this.PageDefinition.PageInfo);

        this.currentPageVal = int.Parse(results["CurrentPage"].Value);
        this.numPagesVal = int.Parse(results["NumPages"].Value);
    }
    
    /// <inheritdoc />
    public async Task<TPage?> GetNextPage()
    {
        if (!this.HasResults)
            return null;
        
        if (this.CurrentPage == this.NumPages)
            return null;

        return await this.nextPageFunc(this.request, this.CurrentPage + 1);
    }
}