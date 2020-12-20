using System;
using System.Threading.Tasks;
using NetStone;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using NUnit.Framework.Internal;

namespace NetStone.Test
{
    public class Tests
    {
        private LodestoneClient lodestone;

        private const int TestCharacterId = 9575452; //arc

        [SetUp]
        public void Setup()
        {
            this.lodestone = new LodestoneClient();
        }

        [Test]
        public void CheckDefinitions()
        {
            Assert.IsNotNull(this.lodestone.Definitions.Character);
            Assert.IsNotNull(this.lodestone.Definitions.ClassJob);
            Assert.IsNotNull(this.lodestone.Definitions.Gear);
        }

        [Test]
        public async Task CheckCharacter()
        {
            var chara = await this.lodestone.GetCharacter(TestCharacterId);

            //Assert.AreEqual(chara.Name, "Arcane Disgea");
            //Assert.AreEqual(chara.FreeCompany.Id, "9232379236109629819");

            var classjob = await chara.GetClassJobInfo();
        }
    }
}