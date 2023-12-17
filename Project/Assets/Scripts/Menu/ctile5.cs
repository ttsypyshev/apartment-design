using UnityEngine;
public class ctile5 : MonoBehaviour
{
    public MainMenu MainMenu;
    public GameObject plane5;

    void Start()
    {
        plane5.SetActive(false);
    }
    private void Update()
    {
        if (MainMenu.stile5)
        {
            plane5.SetActive(true);
        }
        else
        {
            plane5.SetActive(false);
        }
    }
    public void onClick()
    {
        if (!MainMenu.stile5)
        {
            MainMenu.stile1 = false;
            MainMenu.stile2 = false;
            MainMenu.stile3 = false;
            MainMenu.stile4 = false;
            MainMenu.stile5 = true;
        }
    }
}
