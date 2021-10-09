using System;
using System.IO;
using FFXIV;
using FlatBuffers;

namespace NetStone.GameData.Packs
{
    public class PacksGameDataProvider : IGameDataProvider
    {
        private readonly ItemTable items;

        private PacksGameDataProvider(string path)
        {
            items = ItemTable.GetRootAsItemTable(LoadByteBuffer(Path.Combine(path, "item_table.bin")));
        }

        public NamedGameData? GetItem(string name)
        {
            var lower = name.ToLower().Replace("", string.Empty);

            for (var i = 0; i < items.ItemsLength; i++)
            {
                var item = items.Items(i)!.Value;

                if (lower.Equals(item.NameEn, StringComparison.InvariantCultureIgnoreCase)
                    || lower.Equals(item.NameDe, StringComparison.InvariantCultureIgnoreCase)
                    || lower.Equals(item.NameFr, StringComparison.InvariantCultureIgnoreCase)
                    || lower.Equals(item.NameJa, StringComparison.InvariantCultureIgnoreCase))
                {
                    return new NamedGameData
                    {
                        Info = new GameDataInfo
                        {
                            Key = item.Id,
                            Name = name,
                        },

                        Name = new LanguageStrings
                        {
                            En = item.NameEn,
                            De = item.NameDe,
                            Fr = item.NameFr,
                            Ja = item.NameJa,
                        },
                    };
                }
            }

            return null;
        }

        private ByteBuffer LoadByteBuffer(string file)
        {
            var bytes = File.ReadAllBytes(file);
            return new ByteBuffer(bytes);
        }

        public static PacksGameDataProvider Load(DirectoryInfo path) => new PacksGameDataProvider(path.FullName);
    }
}