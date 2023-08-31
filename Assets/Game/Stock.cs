using System.Collections.Generic;
using UnityEngine;

public class Stock
{
    private int _resource = 0;
    private int _maxResource = 0;
    private List<IWorksHouse> _workHouses;

    public int Resource
    {
        get => _resource;
        set
        {
            if (value <= _maxResource) 
                _resource = value;
        }
    }
    public int MaxResource
    {
        get => _maxResource;
        set
        {
            if (value >= 0)
                _maxResource = value;
        }
    }

    public Stock()
    {
        _workHouses = new List<IWorksHouse>();
    }
    public void AddBuildings(IWorksHouse workHouse)
    {
        workHouse.Work();
        _workHouses.Add(workHouse);
    }
    public void RemoveBuildings(IWorksHouse workHouse)
    {
        _workHouses.Remove(workHouse);
    }
}
