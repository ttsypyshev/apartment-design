using UnityEngine;

public class SlantObjects : MonoBehaviour
{
    public GeneralManager generalManager;
    public NotificationManager notificationManager;
    public ChoiceObjects choiceObjects;

    public GameObject body;

    private float speed = 15f;
    private Transform bodyTransform;
    private RaycastHit hit;

    private void Update()
    {
        if (!generalManager.isSlantObjects || !generalManager.edit)
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
        SlantObject();
    }

    private void SlantObject()
    {
        float movX = Input.GetAxis("Horizontal") * speed;
        float movZ = Input.GetAxis("Vertical") * speed;
        float movY = Input.GetAxis("Submit") * speed;

        body.transform.localEulerAngles += new Vector3(movZ, movX, movY) * Time.fixedDeltaTime;
    }
}