using UnityEngine;

public class ChoiceObjects : MonoBehaviour
{
    public NotificationManager notificationManager;
    public GeneralManager generalManager;
    public Camera camera;
    public GameObject body;
    public GameObject CenterImage;
    public string bodyName;

    public bool condition = false;

    void Update()
    {
        if (!generalManager.isChoiceObjects || !generalManager.edit)
        {
            return;
        }

        Cursor.visible = false;
        var mousePosision = Input.mousePosition;
        CenterImage.transform.position = mousePosision;

        RaycastHit hit;

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.tag == "body")
                {
                    bodyName = hit.collider.gameObject.name;
                    body = GameObject.Find(bodyName);
                    condition = true;
                    print(bodyName);
                    notificationManager.inputText = "Объект выбран";
                    return;
                }

                if (hit.collider.gameObject.tag == "body1")
                {
                    bodyName = hit.collider.gameObject.transform.parent.gameObject.name;
                    body = GameObject.Find(bodyName);
                    condition = true;
                    print(bodyName);
                    notificationManager.inputText = "Объект выбран";
                    return;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            if (!condition)
            {
                Ray ray = camera.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.gameObject.tag == "body")
                    {
                        bodyName = hit.collider.gameObject.name;
                        body = GameObject.Find(bodyName);
                        print("Удаление объекта");
                        print(hit.collider.gameObject.name);
                        Destroy(body);
                        notificationManager.inputText = "Объект удалён";
                        return;
                    }

                    if (hit.collider.gameObject.tag == "body1")
                    {
                        bodyName = hit.collider.gameObject.transform.parent.gameObject.name;
                        body = GameObject.Find(bodyName);
                        condition = true;
                        print("Удаление объекта");
                        print(bodyName);
                        Destroy(body);
                        notificationManager.inputText = "Объект удалён";
                        return;
                    }
                }
            }
            else
            {
                print("Удаление объекта");
                print(bodyName);
                Destroy(body);
                condition = false;
                notificationManager.inputText = "Объект удалён";
                bodyName = "";
            }
        }
    }
}