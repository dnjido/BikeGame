using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(fileName = "BikeData", menuName = "ScriptableObjects/Bike Data")]
public class BikesData : ScriptableObject
{
    [SerializeField]public BikeObject[] bikesDatas;

    public BikeObject GetBike(string nameID)
    {
        BikeObject bike = bikesDatas.FirstOrDefault(c => c.nameID == nameID);
        return bike;
    }
}

[System.Serializable]
public class BikeObject
{
    [SerializeField] public string name, nameID;
    [SerializeField] public GameObject prefab;
}
