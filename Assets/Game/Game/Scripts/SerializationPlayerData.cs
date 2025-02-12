using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

public interface ISerializationDataPlayer
{
    public void SaveData();
    public void LoadData();
}

public class SerializationPlayerData : ISerializationDataPlayer
{
    private readonly string _directoryPath;
    private readonly string _filePath;
    private const string _fileName = "Player.xml";

    public SerializationPlayerData()
    {
        _directoryPath = Path.Combine(Application.dataPath, "Save");
        _filePath = Path.Combine(_directoryPath, _fileName);
        CheckDirectory();
    }

    private void CheckDirectory()
    {
        if (!Directory.Exists(_directoryPath))
        {
            Directory.CreateDirectory(_directoryPath);
            CreateSave();
        }
    }

    private void CreateSave()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(PlayerData));
        using (FileStream stream = new FileStream(_filePath, FileMode.Create))
        {
            serializer.Serialize(stream, new PlayerData());
        }
        LoadData();
    }

    public void SaveData()
    {
        PlayerData playerData = new PlayerData{ bikeID = PlayerDataStorage.playerData.bikeID };

        XmlSerializer serializer = new XmlSerializer(typeof(PlayerData));
        using (FileStream stream = new FileStream(_filePath, FileMode.Create))
        {
            serializer.Serialize(stream, playerData);
        }
    }

    public void LoadData()
    {
        if (!File.Exists(_filePath))
        {
            Debug.LogWarning("Save file not found!");
            CreateSave();

            return;
        }

        XmlSerializer serializer = new XmlSerializer(typeof(PlayerData));
        using (FileStream stream = new FileStream(_filePath, FileMode.Open))
        {
            PlayerData playerData = (PlayerData)serializer.Deserialize(stream);
            PlayerDataStorage.SetData(playerData);
        }
    }
}

[System.Serializable]
public class PlayerData
{
    public string bikeID = "red";
}
