using UnityEngine;
public class ctile2 : MonoBehaviour
{
    public MainMenu MainMenu;
    public GameObject plane2;

    void Start()
    {
        plane2.SetActive(false);
    }
    private void Update()
    {
        if (MainMenu.stile2)
        {
            plane2.SetActive(true);
        }
        else
        {
            plane2.SetActive(false);
        }
    }
    public void onClick()
    {
        if (!MainMenu.stile2)
        {
            MainMenu.stile1 = false;
            MainMenu.stile2 = true;
            MainMenu.stile3 = false;
            MainMenu.stile4 = false;
            MainMenu.stile5 = false;
        }
    }
}
