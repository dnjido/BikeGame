using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateUI : MonoBehaviour
{
    [SerializeField] private Transform _canvas;
    // Start is called before the first frame update
    public void Create(GameObject UI)
    {
        Instantiate(UI, _canvas.transform);
    }
}
