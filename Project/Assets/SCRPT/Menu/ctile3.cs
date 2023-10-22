using UnityEngine;
public class ctile3 : MonoBehaviour
{
    public MainMenu MainMenu;
    public GameObject plane3;

    void Start()
    {
        plane3.SetActive(false);
    }
    private void Update()
    {
        if (MainMenu.stile3)
        {
            plane3.SetActive(true);
        }
        else
        {
            plane3.SetActive(false);
        }
    }
    public void onClick()
    {
        if (!MainMenu.stile3)
        {
            MainMenu.stile1 = false;
            MainMenu.stile2 = false;
            MainMenu.stile3 = true;
            MainMenu.stile4 = false;
        }
    }
}