using UnityEngine;

public class Teleporting : MonoBehaviour
{
    public GameObject teleportPoint;
    public GeneralManager generalManager;
    public GameObject player;
    public Camera camera;
    public GameObject flat;

    public float speed = 0.05f;

    private bool f = false;
    private bool b = false;
    private bool r = false;
    private bool l = false;

    // Update is called once per frame
    void Update()
    {
        if (!generalManager.isTeleporting || !generalManager.movement)
        {
            teleportPoint.SetActive(false);
            return;
        }

        teleportPoint.SetActive(true);
        RaycastHit hit;

        float movX = Input.GetAxis("Horizontal");
        float movZ = Input.GetAxis("Vertical");

        //camera forward and right vectors:
        var forward = camera.transform.forward;
        var right = camera.transform.right;

        //project forward and right vectors on the horizontal plane (y = 0)
        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();

        if (Physics.Raycast(teleportPoint.transform.position, forward, out hit, 0.6f) && hit.collider.tag == "flat" && !Input.GetKeyDown(KeyCode.Space)) // проверка вперёд
        {

            if (!f)
            {
                print("no for");
                f = true;
                b = false;
                r = false;
                l = false;
            }

            if (movZ > 0)
            {
                movZ = 0;
            }

            if (forward.z > 0.715 || forward.z < -0.715)
            {
                right.z = 0;
            }
            if (forward.z < 0.715 && forward.z > -0.715)
            {
                right.x = 0;
            }

            if (Physics.Raycast(teleportPoint.transform.position, right, out hit, 0.61f) && hit.collider.tag == "flat")
            {
                if (movX> 0)
                    movX = 0;
            }
            if (Physics.Raycast(teleportPoint.transform.position, -right, out hit, 0.61f) && hit.collider.tag == "flat")
            {
                if (movX < 0)
                    movX = 0;
            }

            teleportPoint.transform.position += (right * movX + forward * movZ) * speed;

            if (!Input.GetKeyDown(KeyCode.LeftShift))
            {
                return;
            }
        }
        if (Physics.Raycast(teleportPoint.transform.position, -forward, out hit, 0.6f) && hit.collider.tag == "flat" && !Input.GetKeyDown(KeyCode.Space)) //проверка назад
        {
            if (!b)
            {
                print("no back");
                b = true;
                f = false;
                r = false;
                l = false;
            }

            if (movZ < 0)
            {
                movZ = 0;
            }

            if (forward.z > 0.715 || forward.z < -0.715)
            {
                right.z = 0;
            }
            if (forward.z < 0.715 && forward.z > -0.715)
            {
                right.x = 0;
            }

            if (Physics.Raycast(teleportPoint.transform.position, right, out hit, 0.61f) && hit.collider.tag == "flat")
            {
                if (movX > 0)
                    movX = 0;
            }
            if (Physics.Raycast(teleportPoint.transform.position, -right, out hit, 0.61f) && hit.collider.tag == "flat")
            {
                if (movX < 0)
                    movX = 0;
            }

            teleportPoint.transform.position += (right * movX + forward * movZ) * speed;

            if (!Input.GetKeyDown(KeyCode.LeftShift))
            {
                return;
            }
        }
        if (Physics.Raycast(teleportPoint.transform.position, right, out hit, 0.6f) && hit.collider.tag == "flat" && !Input.GetKeyDown(KeyCode.Space)) //проверка вправо
        {
            if (!r)
            {
                print("no right");
                r = true;
                b = false;
                f = false;
                l = false;
            }

            if (movX > 0)
            {
                movX = 0;
            }

            if (right.x > 0.715 || right.x < -0.715)
            {
                forward.x = 0;
            }
            if (right.x < 0.715 && right.x > -0.715)
            {
                forward.z = 0;
            }

            if (Physics.Raycast(teleportPoint.transform.position, forward, out hit, 0.61f) && hit.collider.tag == "flat")
            {
                if (movZ > 0)
                    movZ= 0;
            }
            if (Physics.Raycast(teleportPoint.transform.position, -forward, out hit, 0.61f) && hit.collider.tag == "flat")
            {
                if (movZ < 0)
                    movZ = 0;
            }

            teleportPoint.transform.position += (right * movX + forward * movZ) * speed;

            if (!Input.GetKeyDown(KeyCode.LeftShift))
            {
                return;
            }
        }
        if (Physics.Raycast(teleportPoint.transform.position, -right, out hit, 0.6f) && hit.collider.tag == "flat" && !Input.GetKeyDown(KeyCode.Space)) //проверка влево
        {
            if (!l)
            {                
                print("no left");
                l = true;
                b = false;
                r = false;
                f = false;
            }

            if (movX < 0)
            {
                movX = 0;
            }

            if (right.x > 0.715 || right.x < -0.715)
            {
                forward.x = 0;
            }
            if (right.x < 0.715 && right.x > -0.715)
            {
                forward.z = 0;
            }

            if (Physics.Raycast(teleportPoint.transform.position, forward, out hit, 0.61f) && hit.collider.tag == "flat")
            {
                if (movZ > 0)
                    movZ = 0;
            }
            if (Physics.Raycast(teleportPoint.transform.position, -forward, out hit, 0.61f) && hit.collider.tag == "flat")
            {
                if (movZ < 0)
                    movZ = 0;
            }

            teleportPoint.transform.position += (right * movX + forward * movZ) * speed;

            if (!Input.GetKeyDown(KeyCode.LeftShift))
            {
                return;
            }
        }

        teleportPoint.transform.position += (right * movX + forward * movZ) * speed;

        f = false;
        b = false;
        r = false;
        l = false;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            float x = teleportPoint.transform.position.x;
            float y = player.transform.position.y;
            float z = teleportPoint.transform.position.z;

            player.transform.position = new Vector3(x, y, z);
        }
    }
}