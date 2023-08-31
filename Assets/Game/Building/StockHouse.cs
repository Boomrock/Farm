public class StockHouse : BuildingController{
    Stock _stock;

    public StockHouse(Stock stock)
    {
        _stock = stock;
    }
    public override void Work()
    {
        
        _stock.MaxResource +=10;
    }

    public override void StopWork()
    {
        throw new System.NotImplementedException();
    }

    public void Work(Stock scoreCounter)
    {
        
    }

}
