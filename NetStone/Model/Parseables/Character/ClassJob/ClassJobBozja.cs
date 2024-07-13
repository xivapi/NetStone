using System.Linq;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using NetStone.Definitions.Model.Character;

namespace NetStone.Model.Parseables.Character.ClassJob;

/// <summary>
/// Entry for Bozja Field Operation of a character
/// </summary>
public class ClassJobBozja : LodestoneParseable, IOptionalParseable<ClassJobBozja>
{
	private readonly ClassJobBozjaDefinition definition;

	/// <summary>
	/// Constructs a new class entry
	/// </summary>
	/// <param name="rootNode">Root node of this entry</param>
	/// <param name="definition">Parser definition</param>
	public ClassJobBozja(HtmlNode rootNode, ClassJobBozjaDefinition definition) : base(rootNode)
	{
		this.definition = definition;
	}

	/// <summary>
	/// The name of this class and job combo.
	/// </summary>
	public string Name => Parse(this.definition.NAME);

	/// <summary>
	/// The level this class or job is at.
	/// </summary>
	public int Level => int.TryParse(Parse(this.definition.LEVEL), out var levelOut) ? levelOut : 0 ;

	private string MettleString => ParseInnerText(this.definition.METTLE);

	private int? mettleCurrentVal;

	/// <summary>
	/// The amount of current achieved EXP on this level.
	/// </summary>
	public int MettleCurrent
	{
		get
		{
			if (!this.mettleCurrentVal.HasValue)
				ParseMettle();

			return this.mettleCurrentVal!.Value;
		}
	}

	private int? mettleMaxVal;

	/// <summary>
	/// The amount of EXP to be reached to gain the next level.
	/// </summary>
	public int MettleMax
	{
		get
		{
			if (!this.mettleCurrentVal.HasValue)
				ParseMettle();

			return this.mettleMaxVal!.Value;
		}
	}

	/// <summary>
	/// The outstanding amount of EXP to go to the next level.
	/// </summary>
	public int MettleToGo => this.MettleMax - this.MettleCurrent;

	private void ParseMettle()
	{
		if (!this.Exists)
		{
			this.mettleCurrentVal = 0;
			this.mettleMaxVal = 0;

			return;
		}

		var mettleVals = this.MettleString.Split(" / ").Select(x => x.Replace(",", string.Empty)).ToArray();

		this.mettleCurrentVal = int.TryParse(Regex.Match(mettleVals[0], @"\d+").Value, out var mettleCur) ? mettleCur : 0;
		this.mettleMaxVal = int.TryParse(Regex.Match(mettleVals[1], @"\d+").Value, out var mettleMax) ? mettleMax : 0;
	}

	/// <summary>
	/// Value indicating if this class is unlocked.
	/// </summary>
	public bool Exists => this.Level != 0;

	/// <summary>
	/// The string representation of this object.
	/// </summary>
	/// <returns>Name (Level)</returns>
	public override string ToString() => $"{this.Name} ({this.Level})";
}