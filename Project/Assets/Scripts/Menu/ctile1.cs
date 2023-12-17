using UnityEngine;
public class ctile1 : MonoBehaviour
{
    public MainMenu MainMenu;
    public GameObject plane1;

    void Start()
    {
        plane1.SetActive(false);
    }
    private void Update()
    {
        if (MainMenu.stile1)
        {
            plane1.SetActive(true);
        }
        else
        {
            plane1.SetActive(false);
        }
    }
    public void onClick()
    {
        if (!MainMenu.stile1)
        {
            MainMenu.stile1 = true;
            MainMenu.stile2 = false;
            MainMenu.stile3 = false;
            MainMenu.stile4 = false;
            MainMenu.stile5 = false;
        }
    }
}
