using UnityEngine;

public class MovingObjects : MonoBehaviour
{
    public GeneralManager generalManager;
    public NotificationManager notificationManager;
    public ChoiceObjects choiceObjects;

    public Camera camera;
    public GameObject body;

    private float speed = 0.05f;
    private Transform bodyTransform;
    private RaycastHit hit;

    private void Update()
    {
        if (!generalManager.isMovingObjects || !generalManager.edit)
        {
            return;
        }

        body = choiceObjects.body;

        if (body == null)
        {
            notificationManager.inputText = "Объект не выбран";
            return;
        }

        if (!Physics.Raycast(body.transform.position, Vector3.down, out hit, 3f) &&
            !Physics.Raycast(body.transform.position, Vector3.up, out hit, 3f))
        {
            Debug.Log("Удалили объект (выход за пределы): " + body.name);
            Destroy(body);
            body = null;
            return;
        }

        bodyTransform = choiceObjects.body.transform;
        MovingObject();
    }

    private void MovingObject()
    {
        float movX = Input.GetAxis("Horizontal");
        float movZ = Input.GetAxis("Vertical");
        float height = Input.GetAxis("Submit");

        // Camera forward and right vectors:
        if (camera != null)
        {
            var forward = camera.transform.forward;
            var right = camera.transform.right;

            // Project forward and right vectors on the horizontal plane (y = 0)
            forward.y = 0f;
            right.y = 0f;
            forward.Normalize();
            right.Normalize();

            bodyTransform.position += (right * movX + forward * movZ) * speed;
            bodyTransform.position += new Vector3(0, height, 0) * speed; // Adjusted this line
        }
    }
}