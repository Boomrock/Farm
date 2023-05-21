using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResorcesOutPut : MonoBehaviour
{
    [SerializeField]
    private Stock stock;
    [SerializeField]
    private TextMeshProUGUI text;
    // Update is called once per frame
    void Update()
    {
        text.text = "Resources:" + stock.Resource + "\\" + stock.MaxResource;
    }
}
