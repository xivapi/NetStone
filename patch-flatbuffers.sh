#!/bin/sh

sed -i 's/netstandard2.0;net46/netstandard2.0/g' ./lib/flatbuffers/net/FlatBuffers/FlatBuffers.csproj

echo Done!
