![Wifi Campus logo](https://github.com/atillakati/sw_developer_2020_Atilla/blob/main/docs/wifi_campus.PNG)
# Wifi.PlaylistEditor.Repositories.MongoDb
Eine MongoDb Anbindung an unser PlaylistEditor Tool.
Die Bereitstellung und einrichtung der MongoDb Umgebung ist hier beschrieben:
[mongodb-service](https://github.com/atillakati/sw_developer_2020_Atilla/tree/main/docs/mongodb-service)

## Nuget erstellen

Zuvor sollte die Solution im Release-Mode kompiliert werden. Die Versionsnummer im AssemblyInfo.cs und in der .nuspec Datei müssen aktualisiert werden.

```
nuget pack Wifi.PlaylistEditor.Repositories.MongoDb.csproj -properties Configuration=Release
```
Weitere Infos zum Thema Generieren von Nuget-Packages findest du hier: [create-nuget-package](https://nuget-tutorial.net/en/tutorial/100001/create-nuget-package)

## Die app.config

```C#
<appSettings>
    <add key="connectionString" value="mongodb://admin:password@192.168.10.200:27017" />
    <add key="dbName" value="PlaylistDb" />
    <add key="collectionName" value="PlaylistCollection" />
    <add key="ClientSettingsProvider.ServiceUri" value="" />
</appSettings>
```

## Laden von Playlist Dokumenten

```C#
//Repository instanziieren
IDatabaseRepository mongoDbRepository = new MongoDbRepository(_playlistItemFactory);

//alle Playlist Dokumente laden
var allPlaylistDocuments = mongoDbRepository.LoadAll();

if (allPlaylistDocuments != null)
{
    //Auswahldialog mit Playlistnamen versorgen und anzeigen
    IDatabaseLoadDialog formLoad = new frm_databaseLoad();
    
    var listWithPlaylistNames = allPlaylistDocuments.Select(x => x.Name);
    if(formLoad.ShowDialog(listWithPlaylistNames) == DialogResult.OK)
    {
        //ein einzelnes Dokument über den Playlist Namen laden
        _playlist = mongoDbRepository.Load(formLoad.SelectedPlaylistName);        
        
        //update your view here
        //...
        //..
    }
}
```
## Speichern von Playlist Dokumenten

```C#
IDatabaseRepository mongoDbRepository = new MongoDbRepository(_playlistItemFactory);

mongoDbRepository.Save(_playlist.Title, _playlist);

```
