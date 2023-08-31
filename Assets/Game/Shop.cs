using System.Collections;
using System.Collections.Generic;
using Game.Building;
using UnityEditor.UIElements;
using UnityEngine;

public class Shop
{
    private Dictionary<string, int> priceList = new Dictionary<string, int> 
    { 
        {"FarmHouse", 1 },
        {"StockHouse", 5 } 
    };
    private BuildingsGrid _grid;
    private Stock _stock;
    private int _defaultPrice = 1;

    public Shop(BuildingsGrid grid, Stock stock)
    {
        _grid = grid;
        _stock = stock;
    }


    public int GetPrice(string key) => priceList[key]; 
}

public enum BuildingType{
    FarmHouse,
    StockHouse
}
