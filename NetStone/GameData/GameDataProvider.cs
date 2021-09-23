using System;
using System.IO;
using FFXIV;
using FlatBuffers;

namespace NetStone.GameData
{
    internal class GameDataProvider
    {
        private readonly ItemTable items;

        private GameDataProvider(string path)
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
                        Key = item.Id,
                        Name = name,

                        NameEn = item.NameEn,
                        NameDe = item.NameDe,
                        NameFr = item.NameFr,
                        NameJa = item.NameJa,
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

        public static GameDataProvider Load(DirectoryInfo path) => new GameDataProvider(path.FullName);
    }
}