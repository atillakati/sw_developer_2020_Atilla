![Wifi Campus logo](https://github.com/atillakati/sw_developer_2020_Atilla/blob/main/docs/wifi_campus.PNG)
# Wifi.PlaylistEditor.Repositories.MongoDb
Eine MongoDb Anbindung an unser PlaylistEditor Tool

## Die app.config

```C#
<appSettings>
    <add key="connectionString" value="mongodb://admin:password@192.168.10.200:27017" />
    <add key="dbName" value="PlaylistDb" />
    <add key="collectionName" value="PlaylistCollection" />
    <add key="ClientSettingsProvider.ServiceUri" value="" />
</appSettings>
```

## Nuget erstellen

Zuvor sollte die Solution im Release-Mode kompiliert werden. Die Versionsnummer im AssemblyInfo.cs und in der .nuspec Datei müssen aktualisiert werden.

```
nuget pack Wifi.PlaylistEditor.Repositories.MongoDb.csproj -properties Configuration=Release
```

## Laden von Playlist Dokumenten

```C#
//Repository instanziieren
IDatabaseRepository mongoDbRepository = new MongoDbRepository(_playlistItemFactory);

//alle Playlist Dokumente laden
var names = mongoDbRepository.LoadAll();

if (names != null)
{
    //Auswahldialog mit Playlistnamen versorgen und anzeigen
    frm_databaseLoad formLoad = new frm_databaseLoad(names.Select(x => x.Title));
    if(formLoad.ShowDialog() == DialogResult.OK)
    {
        //ein einzelnes Dokument über den Playlist Namen laden
        _playlist = mongoDbRepository.Load(formLoad.SelectedPlaylistName);        
    }
}
```
## Speichern von Playlist Dokumenten

```C#
IDatabaseRepository mongoDbRepository = new MongoDbRepository(_playlistItemFactory);

mongoDbRepository.Save(_playlist.Title, _playlist);

```
