using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject _menu;
    [SerializeField] private Canvas _canvas;
    private Shop _shop;

    [Inject]
    void Constructor(Camera mainCamera, Shop shop)
    {
        _shop = shop;
        _canvas.worldCamera = mainCamera;
    }
    public void OpenMenu()
    {
        if (!_menu.activeSelf)
        {
            _menu.SetActive(true);
        }
    }
    public void CloseMenu()
    {
        if (_menu.activeSelf)
        {
            _menu.SetActive(false);
        } 
    }

    public void Buy(BuildingType buildingType)
    {
        _shop.BuyBuilding(buildingType);
    }
}
