using System.Collections.Generic;
using UnityEngine;

public class Stock : MonoBehaviour
{
    [SerializeField]
    private int resource = 0;
    [SerializeField]
    private int maxResource = 0;
    private List<IWorksHouse> workHouses;

    public int Resource
    {
        get => resource;
        set
        {
            if (value <= maxResource) 
                resource = value;
        }
    }
    public int MaxResource
    {
        get => maxResource;
        set
        {
            if (value >= 0)
                maxResource = value;
        }
    }

    void Start()
    {
        workHouses = new List<IWorksHouse>();
    }
    public void AddBuildings(IWorksHouse workHouse)
    {
        
        workHouse.Work(this);
        workHouses.Add(workHouse);
    }
    public void RemoveBuildings(IWorksHouse workHouse)
    {
        workHouses.Remove(workHouse);
    }
}
