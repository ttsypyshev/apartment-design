using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject CenterImage;
    public Camera camera;
    public GeneralManager generalManager;

    public bool stile1 = true;
    public bool stile2 = false;
    public bool stile3 = false;
    public bool stile4 = false;

    void Update()
    {
        if (!generalManager.menu)
        {
            return;
        }


        var mousePosision = Input.mousePosition;
        mousePosision.x -= 60;
        CenterImage.transform.position = mousePosision;
    }
}
