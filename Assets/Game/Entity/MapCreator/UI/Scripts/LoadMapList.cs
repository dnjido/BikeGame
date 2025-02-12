using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadMapList : MonoBehaviour
{
    [SerializeField] private GameObject _panel, _prefab;
    // Start is called before the first frame update
    public void Fill(MapButtonType loadType)
    {
        SerializationMapData serializationData = new("");
        List<string> list = serializationData.GetAllMapsName();

        foreach (string map in list)
        {
            GameObject button = Instantiate(_prefab, _panel.transform);
            button.GetComponent<MapButton>().Create(map, loadType);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
