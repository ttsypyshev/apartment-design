using UnityEngine;

public class MovingObjects : MonoBehaviour
{
    public ChoiceObjects choiceObjects;
    public GeneralManager generalManager;
    public GameObject body;
    public Camera camera;
    public float xR;
    public float yR;
    public float zR;
    public float speed = 0.05f;

    public string[] text = new string[1] { "Объект не выбран"};

    void Update()
    {
        if (!generalManager.isMovingObjects || !generalManager.edit)
        {
            return;
        }
        if (!choiceObjects.condition)
        {
            generalManager.time = 3;
            generalManager.notificftionText.text = text[0];
            return;
        }

        RaycastHit hit;
        body = choiceObjects.body;

        if (!Physics.Raycast(body.transform.position, Vector3.down, out hit, 3f) || !Physics.Raycast(body.transform.position, Vector3.up, out hit, 3f))
        {
            print("Удаление объекта");
            print(choiceObjects.bodyName);
            Destroy(body);
            choiceObjects.condition = false;
            return;
        }

        float movX = Input.GetAxis("Horizontal");
        float movZ = Input.GetAxis("Vertical");
        float height = Input.GetAxis("Submit");

        //camera forward and right vectors:
        var forward = camera.transform.forward;
        var right = camera.transform.right;

        //project forward and right vectors on the horizontal plane (y = 0)
        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();

        body.transform.position += (right * movX + forward * movZ) * speed;
        body.transform.position += new Vector3(0, height, 0) * speed / 2;
    }
}