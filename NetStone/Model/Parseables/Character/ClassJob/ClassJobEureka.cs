using System.Linq;
using HtmlAgilityPack;
using NetStone.Definitions.Model.Character;

namespace NetStone.Model.Parseables.Character.ClassJob;

/// <summary>
/// Entry for Eureka Field Operation of a character
/// </summary>
public class ClassJobEureka : LodestoneParseable, IOptionalParseable<ClassJobEureka>
{
	private readonly ClassJobEurekaDefinition definition;

	/// <summary>
	/// Constructs a new class entry
	/// </summary>
	/// <param name="rootNode">Root node of this entry</param>
	/// <param name="definition">Parser definition</param>
	public ClassJobEureka(HtmlNode rootNode, ClassJobEurekaDefinition definition) : base(rootNode)
	{
		this.definition = definition;
	}

	/// <summary>
	/// The name of this class and job combo.
	/// </summary>
	public string Name => Parse(this.definition.Name);

	/// <summary>
	/// Value indicating whether this class has its job unlocked.
	/// </summary>
	public bool IsJobUnlocked => this.Name.Contains("/");

	/// <summary>
	/// The level this class or job is at.
	/// </summary>
	public int Level => int.TryParse(Parse(this.definition.Level), out var level)? level : 0;

	private string ExpString => ParseInnerText(this.definition.Exp);

	private int? expCurrentVal;

	/// <summary>
	/// The amount of current achieved EXP on this level.
	/// </summary>
	public int ExpCurrent
	{
		get
		{
			if (!this.expCurrentVal.HasValue)
				ParseExp();

			return this.expCurrentVal!.Value;
		}
	}

	private int? expMaxVal;

	/// <summary>
	/// The amount of EXP to be reached to gain the next level.
	/// </summary>
	public int ExpMax
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
	public int ExpToGo => this.ExpMax - this.ExpCurrent;

	private void ParseExp()
	{
		if (!this.Exists)
		{
			this.expCurrentVal = 0;
			this.expMaxVal = 0;

			return;
		}

		var expVals = this.ExpString.Split(" / ").Select(x => x.Replace(",", string.Empty)).ToArray();

		this.expCurrentVal = int.TryParse(expVals[0], out var expCur) ? expCur : 0;
		this.expMaxVal = int.TryParse(expVals[1], out var expMax) ? expMax : 0;
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