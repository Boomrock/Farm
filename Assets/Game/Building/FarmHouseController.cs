using System.Collections;
using UnityEngine;

namespace Game.Building
{
    public class FarmHouseController : BuildingController
    {
        private readonly Stock _stock;
        private readonly MonoBehaviour _context;
        private Coroutine _coroutine;

        public FarmHouseController(Stock stock, MonoBehaviour Context)
        {
            _stock = stock;
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
