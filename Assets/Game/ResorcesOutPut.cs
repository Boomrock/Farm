using TMPro;
using UnityEngine;
using Zenject;

public class ResorcesOutPut : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI text;

    private Stock _stock;
    [Inject]
    private void Constructor(Stock stock)
    {
        _stock = stock;
    }
    // Update is called once per frame
    void Update()
    {
        text.text = "Resources:" + _stock.Resource + "\\" + _stock.MaxResource;
    }
}
