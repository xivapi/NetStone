using System;
using System.IO;
using System.Threading.Tasks;
using NetStone.GameData.Packs;
using NetStone.Search.Character;
using NetStone.Search.FreeCompany;
using NetStone.StaticData;
using NUnit.Framework;
using SortKind = NetStone.Search.Character.SortKind;

namespace NetStone.Test;

public class Tests
{
    private LodestoneClient lodestone;

    private const string TestCharacterIdFull = "9575452"; //arc
    private const string TestCharacterIdBare = "9426169";

    private const string TestFreeCompany = "9232379236109629819";

    [SetUp]
    public async Task Setup()
    {
        var gameData = PacksGameDataProvider.Load(new DirectoryInfo("../../../../lib/lodestone-data-exports/pack"));
        this.lodestone = await LodestoneClient.GetClientAsync(gameData);
    }

    [Test]
    public void CheckDefinitions()
    {
        Assert.IsNotNull(this.lodestone.Definitions.Character);
        Assert.IsNotNull(this.lodestone.Definitions.ClassJob);
        Assert.IsNotNull(this.lodestone.Definitions.Gear);
        Assert.IsNotNull(this.lodestone.Definitions.Achievement);
    }

    [Test]
    public async Task CheckCharacterSearch()
    {
        var query = new CharacterSearchQuery
        {
            CharacterName = "Bob",
            DataCenter = "Aether",
            Role = Role.Dps,
            Race = Race.Hyur,
            GrandCompany = GrandCompany.ImmortalFlames | GrandCompany.Maelstrom | GrandCompany.OrderOfTheTwinAdder,
            Language = Language.English | Language.German | Language.French,
            SortKind = SortKind.NameZtoA,
        };

        var page = await this.lodestone.SearchCharacter(query);
        Assert.AreEqual(4, page.NumPages);
        Assert.AreEqual(1, page.CurrentPage);

        var cResults = 0;
        var cPages = 1;

        do
        {
            Assert.AreEqual(cPages, page.CurrentPage);

            foreach (var searchResult in page.Results)
            {
                Console.WriteLine(
                    $"{page.CurrentPage}({cPages}) - {cResults} - {searchResult.Name} - {searchResult.Id}");
                cResults++;
            }

            cPages++;

            page = await page.GetNextPage();
        } while (page != null);
    }

    [Test]
    public async Task CheckFreeCompany()
    {
        var fc = await this.lodestone.GetFreeCompany(TestFreeCompany);

        Console.WriteLine(fc.Focus.Leveling.IsEnabled);

        Console.WriteLine(fc.Formed);

        var members = await fc.GetMembers();

        do
        {
            foreach (var searchResult in members.Members)
            {
                Console.WriteLine(
                    $"{members.CurrentPage} - {searchResult.Name} - {searchResult.RankIcon} - {searchResult.Id}");
            }

            members = await members.GetNextPage();
        } while (members != null);
    }

    [Test]
    public async Task TestFreeCompanySearch()
    {
        var query = new FreeCompanySearchQuery
        {
            Name = "Crystal",
            Housing = Housing.EstateBuilt,
            GrandCompany = GrandCompany.ImmortalFlames,
        };

        var page = await this.lodestone.SearchFreeCompany(query);
        Assert.NotNull(page);
        Assert.AreEqual(6, page.NumPages);
        Assert.AreEqual(1, page.CurrentPage);

        var cResults = 0;
        var cPages = 1;

        do
        {
            Assert.AreEqual(cPages, page.CurrentPage);

            foreach (var searchResult in page.Results)
            {
                Console.WriteLine(
                    $"{page.CurrentPage}({cPages}) - {cResults} - {searchResult.Name} - {searchResult.Id}");
                cResults++;
            }

            cPages++;

            page = await page.GetNextPage();
        } while (page != null);
    }

    [Test]
    public async Task CheckCharacterBare()
    {
        var chara = await this.lodestone.GetCharacter(TestCharacterIdBare);
        Assert.NotNull(chara);

        var classJob = await chara.GetClassJobInfo();
        Assert.NotNull(classJob);
    }

    [Test]
    public async Task CheckCharacterFull()
    {
        var chara = await this.lodestone.GetCharacter(TestCharacterIdFull);
        Assert.NotNull(chara);

        Assert.AreEqual(chara.ToString(), "Arcane Disgea on Leviathan");
        Assert.AreEqual(chara.Server, "Leviathan");
        Assert.AreEqual(chara.Name, "Arcane Disgea");
        Assert.True(chara.Bio.StartsWith(
            "This is a test of the emergency alert system.AHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHHH"));
        Assert.AreEqual(chara.GuardianDeityName, "Menphina, the Lover");
        Assert.AreEqual(chara.Nameday, "28th Sun of the 6th Astral Moon");
        Assert.AreEqual(chara.Title, "Mammeteer");
        Assert.AreEqual(chara.TownName, "Limsa Lominsa");
        Assert.True(chara.Avatar != null);
        Assert.True(chara.Portrait != null);

        Console.WriteLine(chara.GuardianDeityIcon);

        Assert.NotNull(chara.FreeCompany);
        Assert.AreEqual(chara.FreeCompany.Id, "9232379236109629819");
        Assert.AreEqual(chara.FreeCompany.Name, "Hell Hath No Fury");
        Assert.AreEqual(chara.FreeCompany.Link.AbsoluteUri,
            "https://eu.finalfantasyxiv.com/lodestone/freecompany/9232379236109629819/");
        //todo: iconlayer

        Assert.NotNull(chara.PvPTeam);
        Assert.AreEqual(chara.PvPTeam.Id, "59665d98bf81ff58db63305b538cd69a6c64d578");
        Assert.AreEqual(chara.PvPTeam.Name, "Raubahn's Left Arm");
        Assert.AreEqual(chara.PvPTeam.Link.AbsoluteUri,
            "https://eu.finalfantasyxiv.com/lodestone/pvpteam/59665d98bf81ff58db63305b538cd69a6c64d578/");
        //todo: iconlayer

        //Assert.AreEqual(chara.Gear.Mainhand.ItemName, "Skullrender");

        //Assert.AreEqual(chara.Attributes.SkillSpeed, 3990);

        var classjob = await chara.GetClassJobInfo();
        Assert.NotNull(classjob);

        //todo: all classjob
        Assert.NotNull(classjob.Warrior);
        Assert.AreEqual(classjob.Warrior.Level, 80);
        Assert.AreEqual(classjob.Warrior.ExpToGo, 0);
        Assert.AreEqual(classjob.Warrior.IsJobUnlocked, true);

        Assert.NotNull(classjob.Weaver);
        Assert.AreEqual(classjob.Weaver.IsSpecialized, true);

        Assert.NotNull(classjob.Carpenter);
        Assert.AreEqual(classjob.Carpenter.IsSpecialized, false);

        /*var achieve = await chara.GetAchievement();

        foreach (var characterAchievementEntry in achieve.Achievements)
        {
            Console.WriteLine($"{characterAchievementEntry.Id} - {characterAchievementEntry.Name}");
        }*/

        //var mount = await chara.GetMounts();
        //var res = mount.Collectables;

        //var minion = await chara.GetMinions();
    }

    [Test]
    public async Task CheckCharacterPrivateAchievements()
    {
        var chara = await this.lodestone.GetCharacterAchievement("11166211");

        Assert.False(chara.HasResults);
    }

    [Test]
    public async Task CheckCharacterCollectableNotFound()
    {
        var mounts = await this.lodestone.GetCharacterMount("0");
        Assert.IsNull(mounts);

        var minions = await this.lodestone.GetCharacterMinion("0");
        Assert.IsNull(minions);
    }
}