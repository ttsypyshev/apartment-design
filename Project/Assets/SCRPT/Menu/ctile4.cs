using UnityEngine;
public class ctile4 : MonoBehaviour
{
    public MainMenu MainMenu;
    public GameObject plane4;

    void Start()
    {
        plane4.SetActive(false);
    }
    private void Update()
    {
        if (MainMenu.stile4)
        {
            plane4.SetActive(true);
        }
        else
        {
            plane4.SetActive(false);
        }
    }
    public void onClick()
    {
        if (!MainMenu.stile4)
        {
            MainMenu.stile1 = false;
            MainMenu.stile2 = false;
            MainMenu.stile3 = false;
            MainMenu.stile4 = true;
        }
    }
}