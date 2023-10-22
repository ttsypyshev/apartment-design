using UnityEngine;

public class ChoiceObjects : MonoBehaviour
{
    public GeneralManager generalManager;
    public Camera camera;
    public GameObject body;
    public string bodyName;

    public bool condition = false;

    void Update()
    {
        if (!generalManager.isChoiceObjects || !generalManager.edit)
        {
            return;
        }

        RaycastHit hit;

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.tag == "body")
                {
                    bodyName = hit.collider.gameObject.name;
                    body = GameObject.Find(hit.collider.gameObject.name);
                    condition = true;
                    print(bodyName);
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
                        body = hit.collider.gameObject;
                        print("Удаление объекта");
                        print(hit.collider.gameObject.name);
                        condition = false;
                        Destroy(body);
                    }
                }
            }
            else
            {
                print("Удаление объекта");
                print(bodyName);
                condition = false;
                Destroy(body);
            }
        }
    }
}