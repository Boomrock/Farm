using UnityEngine;
using Zenject;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    [SerializeField] private Canvas canvas;

    [Inject]
    void Constructor(Camera mainCamera)
    {
        canvas.worldCamera = mainCamera;
    }
    public void OpenMenu()
    {
        if (!menu.activeSelf)
        {
            menu.SetActive(true);
        }
        

    }
    public void CloseMenu()
    {
        if (menu.activeSelf)
        {

            menu.SetActive(false);
        }
        
    }
}
