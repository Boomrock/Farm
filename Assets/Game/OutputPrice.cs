using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

public class OutputPrice : MonoBehaviour
{ 
    [SerializeField] TextMeshProUGUI _text;
    [SerializeField] BuildingType _workHouseType;
    [SerializeField] string _workHouseName;
    private    Shop _shop;

    [Inject]
    void Constructor(Shop shop)
    {
        _shop = shop;
    }
    void Update()
    { 
        _text.text = _workHouseName +": "+_shop.GetPrice(_workHouseType);
    }
}
