using UnityEngine;

public class Moving : MonoBehaviour
{
    public GeneralManager generalManager;
    public GameObject player;
    public Camera camera;

    public float speed = 0.05f;

    private bool f = false;
    private bool b = false;
    private bool r = false;
    private bool l = false;

    // Update is called once per frame
    void Update()
    {
        if (!generalManager.isMoving || !generalManager.movement)
        {
            return;
        }

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

        RaycastHit hit;

        if (Physics.Raycast(player.transform.position, forward, out hit, 0.6f) && hit.collider.tag == "flat") // проверка вперёд
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

            if (Physics.Raycast(player.transform.position, right, out hit, 0.61f) && hit.collider.tag == "flat")
            {
                if (movX > 0)
                    movX = 0;
            }
            if (Physics.Raycast(player.transform.position, -right, out hit, 0.61f) && hit.collider.tag == "flat")
            {
                if (movX < 0)
                    movX = 0;
            }

            player.transform.position += (right * movX + forward * movZ) * speed;

            return;
        }
        if (Physics.Raycast(player.transform.position, -forward, out hit, 0.6f) && hit.collider.tag == "flat") //проверка назад
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

            if (Physics.Raycast(player.transform.position, right, out hit, 0.61f) && hit.collider.tag == "flat")
            {
                if (movX > 0)
                    movX = 0;
            }
            if (Physics.Raycast(player.transform.position, -right, out hit, 0.61f) && hit.collider.tag == "flat")
            {
                if (movX < 0)
                    movX = 0;
            }

            player.transform.position += (right * movX + forward * movZ) * speed;

            return;
        }
        if (Physics.Raycast(player.transform.position, right, out hit, 0.6f) && hit.collider.tag == "flat") //проверка вправо
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

            if (Physics.Raycast(player.transform.position, forward, out hit, 0.61f) && hit.collider.tag == "flat")
            {
                if (movZ > 0)
                    movZ = 0;
            }
            if (Physics.Raycast(player.transform.position, -forward, out hit, 0.61f) && hit.collider.tag == "flat")
            {
                if (movZ < 0)
                    movZ = 0;
            }

            player.transform.position += (right * movX + forward * movZ) * speed;

            return;
        }
        if (Physics.Raycast(player.transform.position, -right, out hit, 0.6f) && hit.collider.tag == "flat") //проверка влево
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

            if (Physics.Raycast(player.transform.position, forward, out hit, 0.61f) && hit.collider.tag == "flat")
            {
                if (movZ > 0)
                    movZ = 0;
            }
            if (Physics.Raycast(player.transform.position, -forward, out hit, 0.61f) && hit.collider.tag == "flat")
            {
                if (movZ < 0)
                    movZ = 0;
            }

            player.transform.position += (right * movX + forward * movZ) * speed;

            return;
        }
        player.transform.position += (right * movX + forward * movZ) * speed;

        f = false;
        b = false;
        r = false;
        l = false;
    }
}