using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

public class OutputPrice : MonoBehaviour
{ 
    [SerializeField] Shop _shop;
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] string WorkHouseKey;
    [SerializeField] string WorkHouseName;

    [Inject]
    void Constructor()
    {

    }
    void Update()
    { 
        //text.text = WorkHouseName +": "+_shop.GetPrice(WorkHouseKey);
    }
}
