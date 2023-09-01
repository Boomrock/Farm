namespace Game.Building
{
    public class StockHouseController : BuildingController{
        Stock _stock;
        private BuildingView _view;

        public StockHouseController(Stock stock, StockHouseView view)
        {
            _stock = stock;
            _view = view;
        }

        public override BuildingView View { get => _view; }

        public override void Work()
        {
        
            _stock.MaxResource +=10;
        }

        public override void StopWork()
        {
            _stock.MaxResource -=10;
        }

        public void Work(Stock scoreCounter)
        {
        
        }

    }
}
