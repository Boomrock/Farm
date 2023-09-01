using System.Collections;
using UnityEngine;

namespace Game.Building
{
    public class FarmHouseController : BuildingController
    {
        public override BuildingView View { get => _view; }

        
        private readonly Stock _stock;
        private readonly FarmHouseView _view;
        private readonly MonoBehaviour _context;
        private Coroutine _coroutine;

        public FarmHouseController(Stock stock, FarmHouseView view, MonoBehaviour context)
        {
            Debug.Log("construct " + view);
            _stock = stock;
            _view = view;
        }


        public override void Work()
        {
            _coroutine = _context.StartCoroutine(AddResources());
        }

        public override void StopWork()
        {
            _context.StopCoroutine(_coroutine);
        }
        private IEnumerator AddResources()
        {
            while (true)
            {
                _stock.Resource++;
                yield return new WaitForSeconds(1);
            }
        }

    }
}
