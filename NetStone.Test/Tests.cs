using System;
using System.IO;
using System.Threading.Tasks;
using NetStone.GameData.Packs;
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

    private const string TestCharacterIdFull = "9575452"; //arc
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
        Assert.NotNull(fc);
        Assert.AreEqual("Maelstrom", fc.GrandCompany);
        Assert.AreEqual("Hell On Aura", fc.Name);
        Assert.AreEqual("«Fury»", fc.Tag);
        Assert.AreEqual("I EAT BABIES FOR BREAKFAST - KAIVE", fc.Slogan);
        Assert.AreEqual(new DateTime(2019, 01, 14, 04, 22, 05), fc.Formed);
        Assert.AreEqual(35, fc.ActiveMemberCount);
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
        Assert.AreEqual("https://img.finalfantasyxiv.com/lds/h/9/2RIcg3Swu7asLE9w5hF11Gm1Sg.png",
            fc.Focus.RolePlay.Icon?.AbsoluteUri);

        Assert.AreEqual("Leveling", fc.Focus.Leveling.Name);
        Assert.IsTrue(fc.Focus.Leveling.IsEnabled);
        Assert.AreEqual("https://img.finalfantasyxiv.com/lds/h/n/5Y0D3iH7ngHlRpv9-KJKalt3_o.png",
            fc.Focus.Leveling.Icon?.AbsoluteUri);

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

        Assert.Null(chara.FreeCompany);
    }

    [Test]
    public async Task CheckCharacterFull()
    {
        var chara = await this.lodestone.GetCharacter(TestCharacterIdFull);
        Assert.NotNull(chara);
        //General data
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

        //Free Company
        Assert.NotNull(chara.FreeCompany);
        Assert.AreEqual(chara.FreeCompany.Id, "9232379236109629819");
        Assert.AreEqual(chara.FreeCompany.Name, "Hell On Aura");
        Assert.AreEqual(chara.FreeCompany.Link.AbsoluteUri,
            "https://eu.finalfantasyxiv.com/lodestone/freecompany/9232379236109629819/");
        //todo: iconlayer
        //PvP
        Assert.NotNull(chara.PvPTeam);
        Assert.AreEqual(chara.PvPTeam.Id, "59665d98bf81ff58db63305b538cd69a6c64d578");
        Assert.AreEqual(chara.PvPTeam.Name, "Raubahn's Left Arm");
        Assert.AreEqual(chara.PvPTeam.Link.AbsoluteUri,
            "https://eu.finalfantasyxiv.com/lodestone/pvpteam/59665d98bf81ff58db63305b538cd69a6c64d578/");
        //todo: iconlayer

        //Gear
        var gear = chara.Gear;
        Assert.AreEqual($"Classical War Scythe{GearEntry.HqChar}", gear.Mainhand.ItemName);
        Assert.IsTrue(gear.Mainhand.IsHq);
        Assert.AreEqual("Classical War Scythe", gear.Mainhand.StrippedItemName);

        Assert.IsNull(gear.Offhand);

        Assert.AreEqual($"Reaper's Chapeau", gear.Head.ItemName);
        Assert.IsFalse(gear.Head.IsHq);
        Assert.AreEqual("Reaper's Chapeau", gear.Head.StrippedItemName);

        Assert.AreEqual("Reaper's Corselet", gear.Body.ItemName);

        Assert.AreEqual("Reaper's Armguards", gear.Hands.ItemName);

        Assert.AreEqual("Moonward Hose of Maiming", gear.Legs.ItemName);

        Assert.AreEqual("Reaper's Boots", gear.Feet.ItemName);

        Assert.AreEqual($"The Last Earring of Slaying", gear.Earrings.ItemName);
        Assert.IsFalse(gear.Earrings.IsHq);
        Assert.AreEqual("The Last Earring of Slaying", gear.Earrings.StrippedItemName);

        Assert.AreEqual("The Last Necklace of Slaying", gear.Necklace.ItemName);

        Assert.AreEqual("The Last Bracelet of Slaying", gear.Bracelets.ItemName);

        Assert.AreEqual("Moonward Ring of Slaying", gear.Ring1.ItemName);

        Assert.AreEqual("The Last Ring of Slaying", gear.Ring2.ItemName);

        //Materia
        //Not dyed item
        Assert.NotNull(chara.Gear.Legs?.Materia[0]);
        //Dyed item
        Assert.NotNull(chara.Gear.Body?.Materia[0]);

        //Classes/Jobs
        var classJob = await chara.GetClassJobInfo();
        Assert.NotNull(classJob);

        foreach (var job in Enum.GetValues<ClassJob>())
        {
            switch (job)
            {
                case ClassJob.None:
                    continue;
                case ClassJob.Sage:
                    Assert.Null(classJob.ClassJobDict[job], $"{job}");
                    break;
                default:
                    Assert.NotNull(classJob.ClassJobDict[job], $"{job}");
                    break;
            }
        }

        Assert.NotNull(classJob.Reaper);
        Assert.AreEqual(90, classJob.Reaper.Level);
        Assert.AreEqual(0, classJob.Reaper.ExpToGo);
        Assert.AreEqual(0, classJob.Reaper.ExpCurrent);
        Assert.AreEqual(0, classJob.Reaper.ExpMax);
        Assert.IsFalse(classJob.Reaper.IsJobUnlocked);

        Assert.NotNull(classJob.Scholar);
        Assert.AreEqual(74, classJob.Scholar.Level);
        Assert.AreEqual(6612, classJob.Scholar.ExpCurrent);
        Assert.AreEqual(3532000, classJob.Scholar.ExpMax);
        Assert.AreEqual(3532000 - 6612, classJob.Scholar.ExpToGo);

        Assert.NotNull(classJob.WhiteMage);
        Assert.IsTrue(classJob.WhiteMage.IsJobUnlocked);

        Assert.NotNull(classJob.Weaver);
        Assert.AreEqual(classJob.Weaver.IsSpecialized, true);

        Assert.NotNull(classJob.Carpenter);
        Assert.AreEqual(classJob.Carpenter.IsSpecialized, false);

        //Attributes
        var attributes = chara.Attributes;
        Assert.AreEqual(2208, attributes.Strength);
        Assert.AreEqual(393, attributes.Dexterity);
        Assert.AreEqual(2178, attributes.Vitality);
        Assert.AreEqual(311, attributes.Intelligence);
        Assert.AreEqual(155, attributes.Mind);
        Assert.AreEqual(1603, attributes.CriticalHitRate);
        Assert.AreEqual(1378, attributes.Determination);
        Assert.AreEqual(1321, attributes.DirectHitRate);
        Assert.AreEqual(2827, attributes.Defense);
        Assert.AreEqual(2223, attributes.MagicDefense);
        Assert.AreEqual(2208, attributes.AttackPower);
        Assert.AreEqual(577, attributes.SkillSpeed);
        Assert.AreEqual(311, attributes.AttackMagicPotency);
        Assert.AreEqual(155, attributes.HealingMagicPotency);
        Assert.AreEqual(400, attributes.SpellSpeed);
        Assert.AreEqual(400, attributes.Tenacity);
        Assert.AreEqual(390, attributes.Piety);
        Assert.AreEqual(46898, attributes.Hp);
        Assert.AreEqual(10000, attributes.MpGpCp);
        Assert.AreEqual("MP", attributes.MpGpCpParameterName);

        //Achievements

        var achieve = await chara.GetAchievement();
        Assert.NotNull(achieve);
        foreach (var achievement in achieve.Achievements)
        {
            Assert.NotNull(achievement.Id);
            switch (achievement.Id)
            {
                case 3090:
                    Assert.AreEqual("Sustainable Sourcing I", achievement.Name);
                    Assert.AreEqual(new DateTime(2022, 08, 28, 15, 04, 02), achievement.TimeAchieved);
                    break;
                case 1642:
                    Assert.AreEqual("Sins of the Savage Creator I", achievement.Name);
                    Assert.AreEqual(new DateTime(2019, 07, 29, 02, 34, 08), achievement.TimeAchieved);
                    break;
            }
        }

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