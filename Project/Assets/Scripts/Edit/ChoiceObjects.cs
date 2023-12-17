using UnityEngine;

public static class Tags
{
    public const string Draggable = "draggable";
}

public class ChoiceObjects : MonoBehaviour
{
    public GeneralManager generalManager;
    public NotificationManager notificationManager;

    public Camera camera;

    public GameObject body;

    private RaycastHit hit;

    private void Update()
    {
        if (!generalManager.isChoiceObjects || !generalManager.edit)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            ChoiceObject();
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            DeleteObject();
        }
    }

    private void ChoiceObject()
    {
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit) && hit.collider != null)
        {
            string objectTag = hit.collider.gameObject.tag;

            if (objectTag == Tags.Draggable)
            {
                body = hit.collider.gameObject;
                notificationManager.inputText = "Объект выбран";
                Debug.Log("Нашли объект: " + body.name);
            }
        }
    }

    private void DeleteObject()
    {
        if (body == null)
        {
            ChoiceObject();
        }

        if (body != null)
        {
            Destroy(body);
            notificationManager.inputText = "Объект удалён";
            Debug.Log("Удалили объект: " + body.name);
            body = null;
        }
    }
}