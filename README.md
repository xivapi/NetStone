# NetStone [![Nuget](https://img.shields.io/nuget/v/NetStone)](https://www.nuget.org/packages/NetStone)

NetStone is a portable and modern .NET FFXIV Lodestone API.

## What works

- [x] Characters
- [x] Character Search
- [x] FCs
- [x] FC Search
- [ ] PvP Teams
- [ ] PvP Team Search
- [ ] Linkshell
- [ ] Linkshell Search
- [ ] CWLS
- [ ] CWLS Search

Eorzea DB support is not planned.

## Usage

### Set up the client
If you want to use NetStone you need to create one instance of the LodestoneClient and use this instance for all your requests.
Note that this operation downloads current definitions and can therefore take an unknown amount of time or even throw and exception.

#### Example Code

```C#
try{
	var lodestoneClient = await LodestoneClient.GetClientAsync();
} catch(HttpRequestException ex){
	...
}
```

### Retrieve character information
Character information is fetched using the character's lodestone ID (the number contained in the Url).
If the ID is not known to you, you can use the built in search functionality to look up a character by name and home world.
If you need to fetch data for a specific character often it is best practice to save the Lodestone Id.
Note that the search can have 0 results and that a character is null if the request failed.
#### Example code
```C#
//Get Lodestone Id if not known
var searchResponse = await lodestoneClient.SearchCharacter(new CharacterSearchQuery()
{
    CharacterName = "Name Surname",
    World = "Lich"
});
var lodestoneCharacter = 
	searchResponse?.Results
	.FirstOrDefault(entry => entry.Name == "Name Surname");
string lodestoneId = lodestoneCharacter.Id;

//If Lodestone id is known
var lodestoneCharacter = await lodestoneClient.GetCharacter(lodestoneId);

```