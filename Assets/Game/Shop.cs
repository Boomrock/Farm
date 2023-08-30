using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    private Dictionary<string, int> priceList = new Dictionary<string, int> 
    { 
        {"FarmHouse", 1 },
        {"StockHouse", 5 } 
    };
    [SerializeField]
    private BuildingsGrid Grid;
    [SerializeField]
    private int defaultPrice = 1;
    [SerializeField]
    private Stock stock;
    // Start is called before the first frame update
    public void BuyWorkHouse(Building worksHouse)
    {
        if (!priceList.ContainsKey(worksHouse.Name))
            priceList.Add(worksHouse.Name, defaultPrice);
        if (priceList[worksHouse.Name] > stock.Resource)
            return;
        stock.Resource -= priceList[worksHouse.Name];
        priceList[worksHouse.Name]++;
        Grid.StartPlacingBuilding(worksHouse);
    }
    public int GetPrice(string key) => priceList[key]; 
}
