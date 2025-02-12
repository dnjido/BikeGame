using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerInit : MonoBehaviour
{
    [SerializeField] private BikesData _bikeData;

    private PlayerData _playerData => PlayerDataStorage.playerData;

    void Start() => Init();

    private void Init()
    {
        BikeObject bikeObject = _bikeData.GetBike(_playerData.bikeID);
        GameObject prefab = Instantiate(bikeObject.prefab, transform);
        Camera.main.GetComponent<CameraFollow>().SetTarget(prefab);
    }
}
