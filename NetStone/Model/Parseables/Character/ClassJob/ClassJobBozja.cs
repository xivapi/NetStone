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
	public string Name => ParseTooltip(this.definition.NAME);

	/// <summary>
	/// Value indicating whether this class has its job unlocked.
	/// </summary>
	public bool IsJobUnlocked => this.Name.Contains("/");

	/// <summary>
	/// The level this class or job is at.
	/// </summary>
	public int Level
	{
		get
		{
			var level = Parse(this.definition.LEVEL);
			return level == "-" ? 0 : int.Parse(level);
		}
	}

	private string ExpString => ParseInnerText(this.definition.METTLE);

	private long? expCurrentVal;

	/// <summary>
	/// The amount of current achieved EXP on this level.
	/// </summary>
	public long ExpCurrent
	{
		get
		{
			if (!this.expCurrentVal.HasValue)
				ParseExp();

			return this.expCurrentVal!.Value;
		}
	}

	private long? expMaxVal;

	/// <summary>
	/// The amount of EXP to be reached to gain the next level.
	/// </summary>
	public long ExpMax
	{
		get
		{
			if (!this.expCurrentVal.HasValue)
				ParseExp();

			return this.expMaxVal!.Value;
		}
	}

	/// <summary>
	/// The outstanding amount of EXP to go to the next level.
	/// </summary>
	public long ExpToGo => this.ExpMax - this.ExpCurrent;

	private void ParseExp()
	{
		if (!this.Exists)
		{
			this.expCurrentVal = 0;
			this.expMaxVal = 0;

			return;
		}

		var expVals = this.ExpString.Split(" / ").Select(x => x.Replace(",", string.Empty)).ToArray();

		if (expVals[0] == "--")
		{
			this.expCurrentVal = 0;
			this.expMaxVal = 0;

			return;
		}

		this.expCurrentVal = long.Parse(Regex.Match(expVals[0], @"\d+").Value);
		this.expMaxVal = long.Parse(Regex.Match(expVals[1], @"\d+").Value);
	}

	/// <summary>
	/// Value indicating if this class is unlocked.
	/// </summary>
	public bool Exists => this.Level != 0;

	/// <summary>
	/// Value indicating if this class is unlocked.
	/// </summary>
	public bool IsUnlocked => this.Exists;

	/// <summary>
	/// The string representation of this object.
	/// </summary>
	/// <returns>Name (Level)</returns>
	public override string ToString() => $"{this.Name} ({this.Level})";
}