using System.Collections;
using UnityEngine;
public class FarmHouse : Building, IWorksHouse
{
    Stock stock;

    public override string Name => "FarmHouse";

    public void Work(Stock stock)
    {
        this.stock = stock;
        StartCoroutine(AddResources());
    }
    private IEnumerator AddResources()
    {
        while (true)
        {
            stock.Resource++;
            yield return new WaitForSeconds(1);
        }
    }
    void OnDisable()
    {
        StopAllCoroutines();
    }

}
