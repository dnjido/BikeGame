using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SaveMapButton : MonoBehaviour
{
    [SerializeField] private TMP_InputField _field;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Press()
    {
        ISerializationDataMaps serializationData = new SerializationMapData(_field.text);
        serializationData.SaveScene();
    }
}
