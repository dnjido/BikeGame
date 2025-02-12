using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MakeShopItem : MonoBehaviour
{
    [SerializeField] private string _nameID;
    [SerializeField] private BikesData _bikesData;

    [SerializeField] private TMP_Text _label;
    [SerializeField] private Transform _prefabPoint;

    public void SetItem(string id)
    {
        _nameID = id;
        BikeObject bikeObject = _bikesData.GetBike(_nameID);
        _label.text = bikeObject.name;

        GameObject prefab = Instantiate(bikeObject.prefab, _prefabPoint.transform);
        SetLayer(prefab);
    }

    private void SetLayer(GameObject prefab)
    {
        int layer = LayerMask.NameToLayer("UI");
        prefab.layer = layer;

        foreach (Transform child in prefab.transform)
        {
            child.gameObject.layer = layer;
        }
    }

    public void Select()
    {
        PlayerData playerData = new PlayerData { bikeID = _nameID };
        PlayerDataStorage.SetData(playerData);

        ISerializationDataPlayer serializationPlayer = new SerializationPlayerData();
        serializationPlayer.SaveData();
    }
}
