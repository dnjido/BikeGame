using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MapButton : MonoBehaviour
{
    [SerializeField] private TMP_Text _label;
    [SerializeField] private MapButtonType _loadType;

    public void Create(string text, MapButtonType loadType)
    {
        _loadType = loadType;
        _label.text = text;
    }

    public void Click()
    {
        ISerializationDataMaps serializationData = new SerializationMapData(_label.text);
        serializationData.LoadScene();

        if(_loadType == MapButtonType.Game) SceneManager.LoadScene("Game");
        if(_loadType == MapButtonType.MapEditor) SceneManager.LoadScene("MapEditor");

    }
}

public enum MapButtonType
{
    Game = 0,
    MapEditor = 1
}

