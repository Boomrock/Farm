using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField]
    private GameObject menu;

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
