using System;
using System.IO;
using System.Threading.Tasks;
using NetStone.GameData.Packs;
using NetStone.Model.Parseables.Character;
using NetStone.Model.Parseables.Character.Gear;
using NetStone.Search.Character;
using NetStone.Search.FreeCompany;
using NetStone.StaticData;
using NUnit.Framework;
using SortKind = NetStone.Search.Character.SortKind;

namespace NetStone.Test;

public class Tests
{
    private LodestoneClient lodestone;
    
    private const string TestCharacterIdFull = "42256897"; 
    private const string TestCharacterIdBare = "9426169";

    private const string TestFreeCompany = "9232379236109629819";

    [SetUp]
    public async Task Setup()
    {
        var gameData =
            PacksGameDataProvider.Load(new DirectoryInfo("../../../../lib/lodestone-data-exports/pack"));
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
        Assert.NotNull(page);
        Assert.GreaterOrEqual(page.NumPages, 4);
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
        Assert.NotNull(fc);
        Assert.AreEqual("Maelstrom", fc.GrandCompany);
        Assert.AreEqual("Hell On Aura", fc.Name);
        Assert.AreEqual("«Fury»", fc.Tag);
        Assert.AreEqual("I EAT BABIES FOR BREAKFAST - KAIVE", fc.Slogan);
        Assert.AreEqual(new DateTime(2019, 01, 14, 04, 22, 05), fc.Formed);
        Assert.GreaterOrEqual(fc.ActiveMemberCount, 35);
        Assert.AreEqual(30, fc.Rank);

        //Reputation
        Assert.NotNull(fc.Reputation);

        Assert.AreEqual("Maelstrom", fc.Reputation.Maelstrom.Name);
        Assert.AreEqual("Allied", fc.Reputation.Maelstrom.Rank);
        Assert.AreEqual(100, fc.Reputation.Maelstrom.Progress);

        Assert.AreEqual("Order of the Twin Adder", fc.Reputation.Adders.Name);
        Assert.AreEqual("Neutral", fc.Reputation.Adders.Rank);
        Assert.AreEqual(0, fc.Reputation.Adders.Progress);

        Assert.AreEqual("Immortal Flames", fc.Reputation.Flames.Name);
        Assert.AreEqual("Neutral", fc.Reputation.Flames.Rank);
        Assert.AreEqual(0, fc.Reputation.Flames.Progress);


        //Estate
        Assert.NotNull(fc.Estate);
        Assert.IsTrue(fc.Estate.Exists);
        Assert.AreEqual("Aura's Kitchen Fire", fc.Estate.Name);
        Assert.AreEqual("Plot 18, 17 Ward, Empyreum (Medium)", fc.Estate.Plot);

        //Focus
        //todo: selector does not work
        Assert.AreEqual("Always", fc.ActiveState);
        Assert.AreEqual("Open", fc.Recruitment);

        Assert.IsNotNull(fc.Focus);
        Assert.AreEqual("Role-playing", fc.Focus.RolePlay.Name);
        Assert.IsFalse(fc.Focus.RolePlay.IsEnabled);
        Assert.IsNotNull(fc.Focus.RolePlay.Icon?.AbsoluteUri);

        Assert.AreEqual("Leveling", fc.Focus.Leveling.Name);
        Assert.IsTrue(fc.Focus.Leveling.IsEnabled);
        Assert.IsNotNull(fc.Focus.Leveling.Icon?.AbsoluteUri);

        Assert.AreEqual("Casual", fc.Focus.Casual.Name);
        Assert.IsTrue(fc.Focus.Casual.IsEnabled);

        Assert.AreEqual("Hardcore", fc.Focus.Hardcore.Name);
        Assert.IsFalse(fc.Focus.Hardcore.IsEnabled);

        Assert.AreEqual("Dungeons", fc.Focus.Dungeons.Name);
        Assert.IsTrue(fc.Focus.Dungeons.IsEnabled);

        Assert.AreEqual("Guildhests", fc.Focus.Guildhests.Name);
        Assert.IsFalse(fc.Focus.Guildhests.IsEnabled);

        Assert.AreEqual("Trials", fc.Focus.Trials.Name);
        Assert.IsTrue(fc.Focus.Trials.IsEnabled);

        Assert.AreEqual("Raids", fc.Focus.Raids.Name);
        Assert.IsTrue(fc.Focus.Raids.IsEnabled);

        Assert.AreEqual("PvP", fc.Focus.PvP.Name);
        Assert.IsFalse(fc.Focus.PvP.IsEnabled);


        //Members
        var members = await fc.GetMembers();
        Assert.NotNull(members);

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
        Assert.GreaterOrEqual(page.NumPages,1);
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
        Assert.NotNull(classJob.Warrior);
        Assert.AreEqual(1, classJob.Warrior.Level);
        Assert.False(classJob.Alchemist.IsUnlocked);
        Assert.False(classJob.WhiteMage.IsUnlocked);
        Assert.Null(await chara.GetMinions());
        Assert.Null(await chara.GetMounts());
        Assert.NotNull(chara.Gear);
        Assert.Null(chara.Gear.Body);
        Assert.NotNull(chara.Gear.Mainhand);
        Assert.AreEqual(1, chara.ActiveClassJobLevel);
        Assert.Null(chara.PvPTeam);
        Assert.Null(chara.FreeCompany);
    }
    
    [Test]
    public async Task CheckCharacterFull()
    {
        var chara = await this.lodestone.GetCharacter(TestCharacterIdFull);
        Assert.NotNull(chara);
        //General data
        Assert.AreEqual(chara.ToString(), "Alyria Lafranie on Lich");
        Assert.AreEqual(chara.Server, "Lich");
        Assert.AreEqual(chara.Name, "Alyria Lafranie");
        Assert.AreEqual("Au Ra",chara.Race);
        Assert.AreEqual("Raen", chara.Tribe);
        Assert.AreEqual(LodestoneCharacter.FemaleChar, chara.Gender);
        Assert.AreEqual("-",chara.Bio);
        Assert.AreEqual(chara.GuardianDeityName, "Rhalgr, the Destroyer");
        Assert.AreEqual(chara.Nameday, "4th Sun of the 4th Umbral Moon");
        Assert.IsEmpty(chara.Title);
        Assert.AreEqual(chara.TownName, "Ul'dah");
        Assert.NotNull(chara.Avatar);
        Assert.NotNull(chara.Portrait);

        Console.WriteLine(chara.GuardianDeityIcon);

        //Free Company
        Assert.NotNull(chara.FreeCompany);
        Assert.AreEqual(chara.FreeCompany.Id, "9228438586435703207");
        Assert.AreEqual(chara.FreeCompany.Name, "Parabellum");
        Assert.AreEqual(chara.FreeCompany.Link?.AbsoluteUri,
            "https://eu.finalfantasyxiv.com/lodestone/freecompany/9228438586435703207/");
        //todo: iconlayer
        //PvP
        //Assert.NotNull(chara.PvPTeam);
        //Assert.AreEqual(chara.PvPTeam.Id, "59665d98bf81ff58db63305b538cd69a6c64d578");
        //Assert.AreEqual(chara.PvPTeam.Name, "Raubahn's Left Arm");
        //Assert.AreEqual(chara.PvPTeam.Link?.AbsoluteUri,
        //    "https://eu.finalfantasyxiv.com/lodestone/pvpteam/59665d98bf81ff58db63305b538cd69a6c64d578/");
        //todo: iconlayer

        //Gear
        var gear = chara.Gear;
        Assert.AreEqual($"Stonegold Milpreves{GearEntry.HqChar}", gear.Mainhand?.ItemName);
        Assert.IsTrue(gear.Mainhand.IsHq);
        Assert.AreEqual("Stonegold Milpreves", gear.Mainhand.StrippedItemName);
        
        Assert.IsNotNull(gear.Mainhand.ItemDatabaseLink);
        Assert.IsEmpty(gear.Mainhand.GlamourName);
        Assert.IsEmpty(gear.Mainhand.Stain);
        
        Assert.IsNull(gear.Offhand);

        Assert.AreEqual("Bookwyrm's Spectacles", gear.Head?.ItemName);
        
        Assert.AreEqual("Bookwyrm's Chasuble", gear.Body?.ItemName);
        Assert.AreEqual("Bookwyrm's Chasuble", gear.Body?.StrippedItemName);

        Assert.AreEqual("Bookwyrm's Gloves", gear.Hands?.ItemName);

        Assert.AreEqual("Bookwyrm's Waistwrap", gear.Legs?.ItemName);

        Assert.AreEqual("Bookwyrm's Boots", gear.Feet?.ItemName);

        Assert.AreEqual("Menphina's Earring", gear.Earrings?.ItemName);

        Assert.AreEqual("Augmented Scaevan Choker of Healing", gear.Necklace?.ItemName);

        Assert.AreEqual("Bracelet of the Divine Harvest", gear.Bracelets?.ItemName);
        

        Assert.AreEqual("Weathered Ring", gear.Ring1?.ItemName);
        Assert.IsFalse(gear.Ring1.IsHq);
        
        Assert.AreEqual("Ring of Freedom", gear.Ring2?.ItemName);
        
        Assert.AreEqual("Soul of the Sage", gear.Soulcrystal?.ItemName);

        //Materia
        //Not dyed item
        //Assert.NotNull(chara.Gear.Legs?.Materia[0]);
        //Dyed item
        //Assert.NotNull(chara.Gear.Body?.Materia[0]);

        //Classes/Jobs
        var classJob = await chara.GetClassJobInfo();
        Assert.NotNull(classJob);

        foreach (var job in Enum.GetValues<ClassJob>())
        {
            switch (job)
            {
                case ClassJob.None:
                    continue;
                case ClassJob.Lancer:
                    Assert.IsFalse(classJob.ClassJobDict[job].IsUnlocked, $"{job}");
                    break;
                case ClassJob.Sage:
                    Assert.IsTrue(classJob.Sage.IsUnlocked);
                    Assert.AreEqual(70,classJob.Sage.Level);
                    Assert.AreEqual(1834966,classJob.Sage.ExpCurrent);
                    Assert.AreEqual(2923000,classJob.Sage.ExpMax);
                    break;
                default:
                    Assert.NotNull(classJob.ClassJobDict[job]);
                    break;
            }
        }

        //Attributes
        var attributes = chara.Attributes;
        Assert.AreEqual(175, attributes.Strength);
        Assert.AreEqual(295, attributes.Dexterity);
        Assert.AreEqual(1080, attributes.Vitality);
        Assert.AreEqual(336, attributes.Intelligence);
        Assert.AreEqual(1161, attributes.Mind);
        Assert.AreEqual(696, attributes.CriticalHitRate);
        Assert.AreEqual(900, attributes.Determination);
        Assert.AreEqual(364, attributes.DirectHitRate);
        Assert.AreEqual(935, attributes.Defense);
        Assert.AreEqual(1629, attributes.MagicDefense);
        Assert.AreEqual(175, attributes.AttackPower);
        Assert.AreEqual(364, attributes.SkillSpeed);
        Assert.AreEqual(1161, attributes.AttackMagicPotency);
        Assert.AreEqual(1161, attributes.HealingMagicPotency);
        Assert.AreEqual(487, attributes.SpellSpeed);
        Assert.AreEqual(364, attributes.Tenacity);
        Assert.AreEqual(626, attributes.Piety);
        Assert.AreEqual(12817, attributes.Hp);
        Assert.AreEqual(10000, attributes.MpGpCp);
        Assert.AreEqual("MP", attributes.MpGpCpParameterName);

        //Achievements

        var achieve = await chara.GetAchievement();
        Assert.NotNull(achieve);
        Assert.AreEqual(1505,achieve.AchievementPoints);
        Assert.GreaterOrEqual(achieve.TotalAchievements,131);
        Assert.GreaterOrEqual(achieve.NumPages,3);
        Assert.AreEqual(1, achieve.CurrentPage);
        bool found592 = false;
        bool found1805 = false;
        while (achieve is not null)
        {
            foreach (var achievement in achieve.Achievements)
            {
                Assert.NotNull(achievement.Id);
                switch (achievement.Id)
                {
                    case 592:
                        Assert.AreEqual("Through the Gate I", achievement.Name);
                        Assert.AreEqual(new DateTime(2022, 03, 03, 20, 03, 42),
                                        achievement.TimeAchieved);
                        found592 = true;
                        break;
                    case 1805:
                        Assert.AreEqual("Flying Colors III", achievement.Name);
                        Assert.AreEqual(new DateTime(2022, 03, 3, 20, 03, 42),
                                        achievement.TimeAchieved);
                        found1805 = true;
                        break;
                }
            }
            achieve = await achieve.GetNextPage();
        }
        Assert.IsTrue(found592);
        Assert.IsTrue(found1805);
        var mount = await chara.GetMounts();
        Assert.NotNull(mount);
        foreach (var m in mount.Collectables)
        {
            Assert.NotNull(m.Name);
        }

        var minion = await chara.GetMinions();
        Assert.NotNull(minion);
        foreach (var m in minion.Collectables)
        {
            Assert.NotNull(m.Name);
        }
    }

    [Test]
    public async Task CheckCharacterPrivateAchievements()
    {
        var chara = await this.lodestone.GetCharacterAchievement("11166211");
        Assert.NotNull(chara);
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