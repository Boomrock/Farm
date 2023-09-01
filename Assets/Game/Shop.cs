using System.Collections;
using System.Collections.Generic;
using Game.Building;
using UnityEditor.UIElements;
using UnityEngine;

public class Shop
{
    private BuildingsGrid _grid;
    private readonly Placer _placer;
    private Stock _stock;
    private readonly BuildingConfig _config;
    private readonly BuildingsFactory _factory;

    public Shop(Placer placer, Stock stock, BuildingConfig config, BuildingsFactory factory)
    {
        _placer = placer;
        _stock = stock;
        _config = config;
        _factory = factory;
    }
    public BuildingController BuyBuilding(BuildingType Type)
    {
        var model = _config.Dictionary[Type];
        if (model.Price > _stock.Resource)
            return null;
        var builderController = _factory.Create(Type);
        _stock.Resource -= model.Price;
        _placer.StartPlacingBuilding(builderController);
        return builderController;
    }
    public int GetPrice(BuildingType Type) => _config.Dictionary[Type].Price; 
}

public enum BuildingType{
    FarmHouse,
    StockHouse
}
