using UnityEngine;

public class ChoiceObjects : MonoBehaviour
{
    public GeneralManager generalManager;
    public Camera camera;
    public GameObject body;
    public GameObject CenterImage;
    public string bodyName;
    public string[] text = new string[2] {"Объект выбран","Объект удалён"};

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
                    generalManager.time = 3;
                    generalManager.notificftionText.text = text[0];
                    return;
                }
                if (hit.collider.gameObject.tag == "body1")
                {
                    bodyName = hit.collider.gameObject.transform.parent.gameObject.name;
                    body = GameObject.Find(bodyName);
                    condition = true;
                    print(bodyName);
                    generalManager.time = 3;
                    generalManager.notificftionText.text = text[0];
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
                        generalManager.time = 3;
                        generalManager.notificftionText.text = text[1];
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
                        generalManager.time = 3;
                        generalManager.notificftionText.text = text[1];
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
                generalManager.time = 3;
                generalManager.notificftionText.text = text[1];
                bodyName = "";
            }
        }
    }
}