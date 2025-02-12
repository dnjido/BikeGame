using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeShopPanel : MonoBehaviour
{
    [SerializeField] private string[] _bikesID;
    [SerializeField] private GameObject _shopPrefab;
    [SerializeField] private GameObject _itemPrefab;
    [SerializeField] private Transform _canvas;

    public void Fill()
    {
        GameObject shop = Instantiate(_shopPrefab, _canvas);
        Transform itemPoint = shop.transform.Find("ItemPoint");
        foreach (string id in _bikesID)
        {
            GameObject item = Instantiate(_itemPrefab, itemPoint.transform);
            item.GetComponent<MakeShopItem>().SetItem(id);
        }
    }
}
