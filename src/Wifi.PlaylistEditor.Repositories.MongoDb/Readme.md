![Wifi Campus logo](https://github.com/atillakati/sw_developer_2020_Atilla/blob/main/docs/wifi_campus.PNG)
# Wifi.PlaylistEditor.Repositories.MongoDb
Eine MongoDb Anbindung an unser PlaylistEditor Tool

## Die app.config

```
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
