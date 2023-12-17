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
    public bool stile5 = false;

    void Update()
    {
        if (!generalManager.menu)
        {
            return;
        }

        Cursor.visible = false;
        var mousePosision = Input.mousePosition;
        CenterImage.transform.position = mousePosision;
    }
}
