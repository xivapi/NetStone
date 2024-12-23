using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using NetStone.GameData.Packs;
using NetStone.Model.Parseables.Character;
using NetStone.Search.Character;
using NetStone.Search.FreeCompany;
using NetStone.Search.Linkshell;
using NetStone.StaticData;
using NUnit.Framework;
using SortKind = NetStone.Search.Character.SortKind;

namespace NetStone.Test;

public class Tests
{
    private LodestoneClient lodestone;
    
    private const string TestCharacterIdFull = "24471319";
    private const string TestCharacterIdEureka = "14556736";
    private const string TestLinkshell = "18577348462979918";
    private const string TestCWLS = "097b99377634f9980eb0cf0b4ff6cf86807feb2c";
    private const string TestCharacterIdEureka2 = "6787158";
    private const string TestCharacterIdBare = "9426169";
    private const string TestCharacterIdDoH = "42256897";

    private const string TestFreeCompany = "9232379236109629819";
    private const string TestFreeCompanyRecruiting = "9232660711086374997";

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
                    $"{members.CurrentPage} - {searchResult.Name} - {searchResult.RankIcon} - {searchResult.Id} - {searchResult.FreeCompanyRankIcon} - {searchResult.FreeCompanyRank}");
            }

            members = await members.GetNextPage();
        } while (members != null);
    }

    [Test]
    public async Task CheckFreeCompanyRecruiting()
    {
        var fc = await this.lodestone.GetFreeCompany(TestFreeCompanyRecruiting);
        Assert.NotNull(fc);
        Assert.AreEqual("Immortal Flames", fc.GrandCompany);
        Assert.AreEqual("Bedge Lords", fc.Name);
        Assert.AreEqual("«BEDGE»", fc.Tag);
        Assert.IsTrue(fc.Slogan.StartsWith("Friendly FC with"));
        Assert.AreEqual(new DateTime(2022, 12, 04, 19, 47, 07), fc.Formed);
        Assert.GreaterOrEqual(fc.ActiveMemberCount, 50);
        Assert.AreEqual(30, fc.Rank);

        //Reputation
        Assert.NotNull(fc.Reputation);

        
        Assert.AreEqual("Maelstrom", fc.Reputation.Maelstrom.Name);
        //Assert.AreEqual("Neutral", fc.Reputation.Maelstrom.Rank);
        Assert.AreEqual(0, fc.Reputation.Maelstrom.Progress);

        Assert.AreEqual("Order of the Twin Adder", fc.Reputation.Adders.Name);
        Assert.AreEqual("Neutral", fc.Reputation.Adders.Rank);
        Assert.AreEqual(0, fc.Reputation.Adders.Progress);

        Assert.AreEqual("Immortal Flames", fc.Reputation.Flames.Name);
        Assert.AreEqual("Allied", fc.Reputation.Flames.Rank);
        Assert.AreEqual(100, fc.Reputation.Flames.Progress);


        //Estate
        Assert.NotNull(fc.Estate);
        Assert.IsTrue(fc.Estate.Exists);
        Assert.AreEqual("Bedge & Breakfast", fc.Estate.Name);
        Assert.AreEqual("Plot 5, 11 Ward, The Goblet (Large)", fc.Estate.Plot);

        //Focus
        Assert.AreEqual("Always", fc.ActiveState);
        Assert.AreEqual("Open", fc.Recruitment);

        Assert.IsNotNull(fc.Focus);
        Assert.AreEqual("Role-playing", fc.Focus.RolePlay.Name);
        Assert.IsTrue(fc.Focus.RolePlay.IsEnabled);
        Assert.IsNotNull(fc.Focus.RolePlay.Icon?.AbsoluteUri);

        Assert.AreEqual("Leveling", fc.Focus.Leveling.Name);
        Assert.IsTrue(fc.Focus.Leveling.IsEnabled);
        Assert.IsNotNull(fc.Focus.Leveling.Icon?.AbsoluteUri);

        Assert.AreEqual("Casual", fc.Focus.Casual.Name);
        Assert.IsTrue(fc.Focus.Casual.IsEnabled);

        Assert.AreEqual("Hardcore", fc.Focus.Hardcore.Name);
        Assert.IsTrue(fc.Focus.Hardcore.IsEnabled);

        Assert.AreEqual("Dungeons", fc.Focus.Dungeons.Name);
        Assert.IsTrue(fc.Focus.Dungeons.IsEnabled);

        Assert.AreEqual("Guildhests", fc.Focus.Guildhests.Name);
        Assert.IsFalse(fc.Focus.Guildhests.IsEnabled);

        Assert.AreEqual("Trials", fc.Focus.Trials.Name);
        Assert.IsTrue(fc.Focus.Trials.IsEnabled);

        Assert.AreEqual("Raids", fc.Focus.Raids.Name);
        Assert.IsTrue(fc.Focus.Raids.IsEnabled);

        Assert.AreEqual("PvP", fc.Focus.PvP.Name);
        Assert.IsTrue(fc.Focus.PvP.IsEnabled);


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
            Name = "new",
            DataCenter = "Crystal",
            Housing = Housing.EstateBuilt,
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
                    $"{page.CurrentPage}({cPages}) - {cResults} - {searchResult.Name} - {searchResult.ActiveMembers} - {searchResult.Id} - {searchResult.Server} - {searchResult.Formed} - {searchResult.Active} - {searchResult.RecruitmentOpen}");
                cResults++;
            }

            cPages++;

            page = await page.GetNextPage();
        } while (page != null);
    }

    [Test]
    public async Task CheckCharacterDoH()
    {
        var chara = await this.lodestone.GetCharacter(TestCharacterIdDoH);
        Assert.NotNull(chara);
        var attribs = chara.Attributes;
        Assert.AreEqual(39, attribs.Craftsmanship);
        Assert.AreEqual(7, attribs.Control);
        Assert.AreEqual(180, attribs.MpGpCp);
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
    public async Task CheckCharacterEurekaBozja()
    {
        var chara = await this.lodestone.GetCharacter(TestCharacterIdEureka);
        Assert.NotNull(chara);
        var classJob = await chara.GetClassJobInfo();
        Assert.NotNull(classJob);
        
        Assert.NotNull(classJob.Bozja);
        Assert.IsTrue(classJob.Bozja.Exists);
        Assert.AreEqual("Resistance Rank",classJob.Bozja.Name);
        Assert.AreEqual(6,classJob.Bozja.Level);
        Assert.AreEqual(13_443, classJob.Bozja.MettleCurrent);
        Assert.AreEqual(18_000, classJob.Bozja.MettleMax);
        
        Assert.NotNull(classJob.Eureka);
        Assert.IsTrue(classJob.Eureka.Exists);
        Assert.AreEqual("Elemental Level",classJob.Eureka.Name);
        Assert.AreEqual(1,classJob.Eureka.Level);
        Assert.AreEqual(431, classJob.Eureka.ExpCurrent);
        Assert.AreEqual(1_000, classJob.Eureka.ExpMax);
    }
    
    [Test]
    public async Task CheckCharacterFull()
    {
        var chara = await this.lodestone.GetCharacter(TestCharacterIdFull);
        Assert.NotNull(chara);
        //General data
        Assert.AreEqual(chara.ToString(), "Elya Solais on Odin");
        Assert.AreEqual(chara.Server, "Odin");
        Assert.AreEqual(chara.Name, "Elya Solais");
        Assert.AreEqual("Miqo'te",chara.Race);
        Assert.AreEqual("Keeper of the Moon", chara.Tribe);
        Assert.AreEqual(LodestoneCharacter.FemaleChar, chara.Gender);
        Assert.AreEqual("-",chara.Bio);
        Assert.AreEqual(chara.GuardianDeityName, "Menphina, the Lover");
        Assert.AreEqual(chara.Nameday, "14th Sun of the 2nd Umbral Moon");
        Assert.AreEqual("Sweet Dreamer",chara.Title);
        Assert.AreEqual(chara.TownName, "Limsa Lominsa");
        Assert.NotNull(chara.Avatar);
        Assert.NotNull(chara.Portrait);

        Console.WriteLine(chara.GuardianDeityIcon);

        //Free Company
        Assert.NotNull(chara.FreeCompany);
        Assert.AreEqual(chara.FreeCompany.Id, "9232660711086250960");
        Assert.AreEqual(chara.FreeCompany.Name, "Corni Licentiae");
        Assert.AreEqual(chara.FreeCompany.Link?.AbsoluteUri,
            "https://eu.finalfantasyxiv.com/lodestone/freecompany/9232660711086250960/");
        
        //Gear
        var gear = chara.Gear;
        Assert.AreEqual("Mandervillous Wings", gear.Mainhand?.ItemName);
        Assert.IsFalse(gear.Mainhand.IsHq);
        Assert.AreEqual("Mandervillous Wings", gear.Mainhand.StrippedItemName);
        
        Assert.IsNotNull(gear.Mainhand.ItemDatabaseLink);
        Assert.IsEmpty(gear.Mainhand.GlamourName);
        Assert.IsEmpty(gear.Mainhand.Stain);
        
        Assert.IsNull(gear.Offhand);

        Assert.AreEqual("Augmented Credendum Circlet of Healing", gear.Head?.ItemName);
        Assert.AreEqual(660, gear.Head?.ItemLevel);
        Assert.NotNull(gear.Head.ItemDatabaseLink);
        Assert.AreEqual("The Emperor's New Hat",gear.Head.GlamourName);
        Assert.NotNull(gear.Head.GlamourDatabaseLink);
        Assert.AreEqual("Savage Aim Materia X",gear.Head.Materia[0]);
        Assert.AreEqual("Heavens' Eye Materia X",gear.Head.Materia[1]);
        
        Assert.AreEqual("Ascension Robe of Healing", gear.Body?.ItemName);
        Assert.AreEqual(660, gear.Body?.ItemLevel);

        Assert.AreEqual("Augmented Credendum Gauntlets of Healing", gear.Hands?.ItemName);
        Assert.AreEqual(660, gear.Hands?.ItemLevel);

        Assert.AreEqual("Augmented Credendum Hose of Healing", gear.Legs?.ItemName);
        Assert.AreEqual(660, gear.Legs?.ItemLevel);

        Assert.AreEqual("Ascension Sandals of Healing", gear.Feet?.ItemName);
        Assert.AreEqual(660, gear.Feet?.ItemLevel);

        Assert.AreEqual("Augmented Credendum Earrings of Healing", gear.Earrings?.ItemName);
        Assert.AreEqual(660, gear.Earrings?.ItemLevel);

        Assert.AreEqual("Ascension Necklace of Healing", gear.Necklace?.ItemName);
        Assert.AreEqual(660, gear.Necklace?.ItemLevel);

        Assert.AreEqual("Ascension Bracelet of Healing", gear.Bracelets?.ItemName);
        Assert.AreEqual(660, gear.Bracelets?.ItemLevel);
        
        Assert.AreEqual("Ascension Ring of Healing", gear.Ring1?.ItemName);
        Assert.AreEqual(660, gear.Ring1?.ItemLevel);
        Assert.IsFalse(gear.Ring1.IsHq);
        
        Assert.AreEqual("Augmented Credendum Ring of Healing", gear.Ring2?.ItemName);
        Assert.AreEqual(660, gear.Ring2?.ItemLevel);
        
        Assert.AreEqual("Soul of the Sage", gear.Soulcrystal?.ItemName);
        
        //Classes/Jobs
        var classJob = await chara.GetClassJobInfo();
        Assert.NotNull(classJob);

        foreach (var job in Enum.GetValues<ClassJob>().Where(job => job != ClassJob.None))
        {
            var activeJob = classJob.ClassJobDict[job];
            switch (job)
            {
                case ClassJob.Culinarian:
                    Assert.IsTrue(activeJob.IsSpecialized);
                    break;
                case ClassJob.Viper or ClassJob.Pictomancer:
                    Assert.IsFalse(activeJob.IsUnlocked, $"{job}");
                    break;
                case ClassJob.WhiteMage:
                    Assert.IsTrue(activeJob.IsJobUnlocked);
                    break;
                case ClassJob.Samurai:
                    Assert.IsTrue(activeJob.IsUnlocked);
                    Assert.AreEqual(50,activeJob.Level);
                    Assert.AreEqual(11_700,activeJob.ExpCurrent);
                    Assert.AreEqual(421_000,activeJob.ExpMax);
                    break;
                default:
                    Assert.IsTrue(activeJob.IsUnlocked);
                    break;
            }
        }
        Assert.NotNull(classJob.Bozja);
        Assert.AreEqual(19, classJob.Bozja.Level);
        Assert.AreEqual(4_441_657, classJob.Bozja?.MettleCurrent);
        Assert.AreEqual(6_163_000, classJob.Bozja?.MettleMax);
        Assert.AreEqual(1_721_343,classJob.Bozja.MettleToGo);
        Assert.AreEqual("Resistance Rank", classJob.Bozja.Name);

        Assert.Null(classJob.Eureka);
        
        //Attributes
        var attributes = chara.Attributes;
        Assert.LessOrEqual(233, attributes.Strength);
        Assert.LessOrEqual(392, attributes.Dexterity);
        Assert.LessOrEqual(3319, attributes.Vitality);
        Assert.LessOrEqual(449, attributes.Intelligence);
        Assert.LessOrEqual(3379, attributes.Mind);
        Assert.LessOrEqual(2397, attributes.CriticalHitRate);
        Assert.LessOrEqual(2040, attributes.Determination);
        Assert.LessOrEqual(904, attributes.DirectHitRate);
        Assert.LessOrEqual(2032, attributes.Defense);
        Assert.LessOrEqual(3551, attributes.MagicDefense);
        Assert.LessOrEqual(233, attributes.AttackPower);
        Assert.LessOrEqual(400, attributes.SkillSpeed);
        Assert.LessOrEqual(3379, attributes.AttackMagicPotency);
        Assert.LessOrEqual(3379, attributes.HealingMagicPotency);
        Assert.LessOrEqual(676, attributes.SpellSpeed);
        Assert.LessOrEqual(400, attributes.Tenacity);
        Assert.LessOrEqual(535, attributes.Piety);
        Assert.LessOrEqual(74324, attributes.Hp);
        Assert.AreEqual(10000, attributes.MpGpCp);
        Assert.AreEqual("MP", attributes.MpGpCpParameterName);

        //Achievements

        var achieve = await chara.GetAchievement();
        Assert.NotNull(achieve);
        Assert.AreEqual(7565,achieve.AchievementPoints);
        Assert.GreaterOrEqual(achieve.TotalAchievements,898);
        Assert.GreaterOrEqual(achieve.NumPages,8);
        Assert.AreEqual(1, achieve.CurrentPage);
        bool found655 = false;
        bool found3303 = false;
        var found1750 = false;
        while (achieve is not null)
        {
            foreach (var achievement in achieve.Achievements)
            {
                Assert.NotNull(achievement.Id);
                switch (achievement.Id)
                {
                    case 655:
                        Assert.AreEqual("Mapping the Realm: Southern Thanalan", achievement.Name);
                        Assert.AreEqual(new DateTime(2021, 07, 31, 12, 09, 17),
                                        achievement.TimeAchieved);
                        found655 = true;
                        break;
                    case 3303:
                        Assert.AreEqual("Reforged: Majestic Manderville Wings", achievement.Name);
                        Assert.AreEqual(new DateTime(2024, 01, 24, 18, 35, 19),
                                        achievement.TimeAchieved);
                        found3303 = true;
                        break;
                    case 1750:
                        found1750 = true;
                        break;
                }
            }
            achieve = await achieve.GetNextPage();
        }
        Assert.IsTrue(found655);
        Assert.IsTrue(found3303);
        Assert.IsFalse(found1750);
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

    [Test]
    public async Task CheckCrossworldLinkShell()
    {
        var cwls = await this.lodestone.GetCrossworldLinkshell(TestCWLS);
        Assert.IsNotNull(cwls);
        Assert.AreEqual("COR and Friends", cwls.Name);
        Assert.AreEqual("Light", cwls.DataCenter);
        Assert.AreEqual(2, cwls.NumPages);
        while (cwls is not null)
        {
            foreach (var member in cwls.Members)
            {
                Console.WriteLine($"{member.Name} ({member.Rank}) {member.RankIcon}\n" +
                                  $"\tId: {member.Id}\n" +
                                  $"\tAvatar: {member.Avatar}\n" +
                                  $"\tServer: {member.Server}\n" +
                                  $"\tLS Rank: {member.LinkshellRank}\n" +
                                  $"\tLS Rank Icon: {member.LinkshellRankIcon}");
            }
            cwls = await cwls.GetNextPage();
        }
    }

    [Test]
    public async Task CheckCrossworldLinkShellSearch()
    {
        var emptyQuery = new CrossworldLinkshellSearchQuery()
        {
            Name = "abcedfas",
        };
        var emptyResult = await this.lodestone.SearchCrossworldLinkshell(emptyQuery);
        Assert.IsNotNull(emptyResult);
        Assert.False(emptyResult.HasResults);
        var query = new CrossworldLinkshellSearchQuery()
        {
            Name = "Hell",
            ActiveMembers = LinkshellSizeCategory.ElevenToThirty,
            DataCenter = "Chaos",
        };
        bool first = true;
        var results = await this.lodestone.SearchCrossworldLinkshell(query);
        Assert.IsNotNull(results);
        Assert.True(results.HasResults);
        Assert.AreEqual(2, results.NumPages);
        while (results is not null)
        {
            foreach (var result in results.Results)
            {
                if (first)
                {
                    first = false;
                    var shell = await result.GetCrossworldLinkshell();
                    Assert.IsNotNull(shell);
                    Assert.AreEqual(result.Name, shell.Name);
                }
                Console.WriteLine($"{result.Name} ({result.Id}): {result.ActiveMembers}\n");
            }
            results = await results.GetNextPage();
        }
    }

    [Test]
    public async Task CheckLinkshell()
    {
        var ls = await this.lodestone.GetLinkshell(TestLinkshell);
        Assert.IsNotNull(ls);
        Assert.AreEqual("CORshell", ls.Name);
        Assert.AreEqual(2, ls.NumPages);
        while (ls is not null)
        {
            foreach (var member in ls.Members)
            {
                Console.WriteLine($"{member.Name} ({member.Rank}) {member.RankIcon}\n" +
                                  $"Id: {member.Id}\n" +
                                  $"Avatar: {member.Avatar}\n" +
                                  $"Server: {member.Server}\n" +
                                  $"LS Rank: {member.LinkshellRank}\n" +
                                  $"LS Rank Icon: {member.LinkshellRankIcon}");
                
            }
            ls = await ls.GetNextPage();
        }
        
    }
    
    [Test]
    public async Task CheckLinkShellSearch()
    {
        var emptyQuery = new LinkshellSearchQuery()
        {
            Name = "abcedfas",
        };
        var emptyResult = await this.lodestone.SearchLinkshell(emptyQuery);
        Assert.IsNotNull(emptyResult);
        Assert.False(emptyResult.HasResults);
        var query = new LinkshellSearchQuery()
        {
            Name = "Hell",
            ActiveMembers = LinkshellSizeCategory.ElevenToThirty,
            DataCenter = "Chaos",
        };
        bool first = true;
        var results = await this.lodestone.SearchLinkshell(query);
        Assert.IsNotNull(results);
        Assert.True(results.HasResults);
        Assert.AreEqual(2, results.NumPages);
        while (results is not null)
        {
            foreach (var result in results.Results)
            {
                if (first)
                {
                    first = false;
                    var shell = await result.GetLinkshell();
                    Assert.IsNotNull(shell);
                    Assert.AreEqual(result.Name, shell.Name);
                }
                Console.WriteLine($"{result.Name} ({result.Id}): {result.ActiveMembers}\n");
            }
            results = await results.GetNextPage();
        }
        query = new LinkshellSearchQuery()
        {
            Name = "Hell",
            ActiveMembers = LinkshellSizeCategory.ElevenToThirty,
            HomeWorld = "Spriggan",
        };
        results = await this.lodestone.SearchLinkshell(query);
        Assert.IsNotNull(results);
        Assert.True(results.HasResults);
        Assert.AreEqual(1, results.NumPages);
        while (results is not null)
        {
            foreach (var result in results.Results)
            {
                Console.WriteLine($"{result.Name} ({result.Id}): {result.ActiveMembers}\n");
            }
            results = await results.GetNextPage();
        }
    }
}