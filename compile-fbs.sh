#!/bin/sh

echo Clearing ./NetStone/GameData/Internal/...
rm -rf ./NetStone/GameData/Internal/

echo Packing data exports...
./flatc --csharp -o ./NetStone/GameData/Internal/ --gen-onefile --filename-suffix "" ./lib/lodestone-data-exports/schema/*.fbs
#go-bindata -o internal/pack/exports/gamedata.go -prefix "lodestone-data-exports/pack" -ignore="(LICENSE|README.md|.git|.gitignore|meta.json|LodestoneDataExporter.*|schema|.vscode)" lodestone-data-exports/...
#sed -i "s/package main/package exports/g" internal/pack/exports/gamedata.go

#find ./NetStone/GameData/Internal/ -type f -exec sed -i 's/using global::FlatBuffers;/using global::Google.FlatBuffers;/g' {} \;
#find ./NetStone/GameData/Internal/ -type f -exec sed -i 's/FFXIV/NetStone.GameData.Internal/g' {} \;

echo Done!
