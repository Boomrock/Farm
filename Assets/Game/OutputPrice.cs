using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OutputPrice : MonoBehaviour
{
    [SerializeField]
    Shop shop;
    [SerializeField]
    TextMeshProUGUI text;
    [SerializeField]
    string WorkHouseKey;
    [SerializeField]
    string WorkHouseName;
    void Update()
    {
        text.text = WorkHouseName +": "+shop.GetPrice(WorkHouseKey);
    }
}
