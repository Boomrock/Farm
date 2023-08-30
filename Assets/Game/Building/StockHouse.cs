
using UnityEngine;

public class StockHouse : Building, IWorksHouse
{
    Stock stock;
    public override string Name => "StockHouse";
    public void Work(Stock scoreCounter)
    {
        this.stock = scoreCounter;
        scoreCounter.MaxResource +=10;
    }
    void OnDestroy()
    {
        stock.MaxResource -=10; 
    }
}
