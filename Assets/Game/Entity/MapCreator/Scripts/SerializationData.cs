using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using System.Xml.Linq;
using UnityEngine;
using System.Linq;

public interface ISerializationDataMaps
{
    public void SaveScene();
    public void LoadScene();
    public List<string> GetAllMapsName();
}

public class SerializationMapData : ISerializationDataMaps
{
    private readonly string _directoryPath;
    private readonly string _filePath;
    private readonly string _fileName;

    public SerializationMapData(string fileName) 
    {
        _fileName = fileName;
        _directoryPath = Path.Combine(Application.dataPath, "Maps");
        _filePath = Path.Combine(_directoryPath, _fileName + ".xml");
        CheckDirectory();
    }

    private void CheckDirectory()
    {
        if (!Directory.Exists(_directoryPath))
        {
            Directory.CreateDirectory(_directoryPath);
        }
    }

    public void SaveScene()
    {
        MapData mapData = new MapData {name = _fileName};

        mapData.name = _fileName;

        foreach (GameObject obj in GameObject.FindObjectsOfType<GameObject>())
        {
            if (obj.tag != "MapObject") continue;

            MapObjectData objectData = new MapObjectData
            {
                type = obj.name,
                position = obj.transform.position,
                rotation = obj.transform.rotation,
                scale = obj.transform.localScale
            };

            mapData.objectDataList.Add(objectData);
        }

        XmlSerializer serializer = new XmlSerializer(typeof(MapData));
        using (FileStream stream = new FileStream(_filePath, FileMode.Create))
        {
            serializer.Serialize(stream, mapData);
        }
    }

    public void LoadScene()
    {
        if (!File.Exists(_filePath))
        {
            Debug.LogWarning("Save file not found!");
            return;
        }

        XmlSerializer serializer = new XmlSerializer(typeof(MapData));
        using (FileStream stream = new FileStream(_filePath, FileMode.Open))
        {
            MapData mapData = (MapData)serializer.Deserialize(stream);
            MapDataStorage.SetData(mapData);
        }
    }

    public List<string> GetAllMapsName()
    {
        List<string> maps = new List<string>();
        if (!Directory.Exists(_directoryPath))
        {
            Debug.LogWarning("Folder file not found!");
            return maps;
        }

        string[] files = Directory.GetFiles(_directoryPath);

        foreach (string file in files)
        {
            string filePath = _directoryPath + "/" + Path.GetFileName(file);
            
            try
            {
                XDocument xdoc = XDocument.Load(filePath);
                string firstItemText = xdoc.Descendants("name").FirstOrDefault()?.Value;
                maps.Add(firstItemText);
            }
            catch { continue; }
        }

        return maps;
    }
}

[System.Serializable]
public class MapData
{
    public string name;
    public List<MapObjectData> objectDataList = new List<MapObjectData>();
}

[System.Serializable]
public struct MapObjectData
{
    public string type;
    public Vector3 position;
    public Quaternion rotation;
    public Vector3 scale;
}
