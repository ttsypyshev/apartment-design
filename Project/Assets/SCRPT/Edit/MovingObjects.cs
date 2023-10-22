using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MovingObjects : MonoBehaviour
{
    public ChoiceObjects choiceObjects;
    public GeneralManager generalManager;
    public Camera camera;
    public float xR;
    public float yR;
    public float zR;

    public float speed = 0.01f;

    private bool f = false;
    private bool b = false;
    private bool r = false;
    private bool l = false;

    void Update()
    {
        if (!generalManager.isMovingObjects || !generalManager.edit || !choiceObjects.condition)
        {
            return;
        }

        GameObject body = choiceObjects.body;
        RaycastHit hit;

        float movX = Input.GetAxis("Horizontal");
        float movZ = Input.GetAxis("Vertical");
        float height = Input.GetAxis("Submit");

        xR = body.GetComponent<BoxCollider>().size.x / 2;
        yR = body.GetComponent<BoxCollider>().size.y / 2;;
        zR = body.GetComponent<BoxCollider>().size.z / 2;

        //camera forward and right vectors:
        var forward = camera.transform.forward;
        var right = camera.transform.right;

        //project forward and right vectors on the horizontal plane (y = 0)
        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();

        if (Physics.Raycast(body.transform.position, Vector3.up, out hit, yR) && hit.collider.tag == "flat")
        {
            if (height > 0)
                height = 0;

            body.transform.position += new Vector3(0, height, 0) * speed / 2;
        }
        if (Physics.Raycast(body.transform.position, Vector3.down, out hit, yR) && hit.collider.tag == "flat")
        {
            if (height < 0)
                height = 0;

            body.transform.position += new Vector3(0, height, 0) * speed / 2;
        }

        if (Physics.Raycast(body.transform.position, forward, out hit, xR) && hit.collider.tag == "flat") // проверка вперёд
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

            if (Physics.Raycast(body.transform.position, right, out hit, zR + 0.1f) && hit.collider.tag == "flat")
            {
                if (movX > 0)
                    movX = 0;
            }
            if (Physics.Raycast(body.transform.position, -right, out hit, zR + 0.1f) && hit.collider.tag == "flat")
            {
                if (movX < 0)
                    movX = 0;
            }

            body.transform.position += (right * movX + forward * movZ ) * speed;
            body.transform.position += new Vector3(0, height, 0) * speed / 2;

            return;
        }
        if (Physics.Raycast(body.transform.position, -forward, out hit, xR) && hit.collider.tag == "flat") //проверка назад
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

            if (Physics.Raycast(body.transform.position, right, out hit, zR + 0.1f) && hit.collider.tag == "flat")
            {
                if (movX > 0)
                    movX = 0;
            }
            if (Physics.Raycast(body.transform.position, -right, out hit, zR + 0.1f) && hit.collider.tag == "flat")
            {
                if (movX < 0)
                    movX = 0;
            }

            body.transform.position += (right * movX + forward * movZ) * speed;
            body.transform.position += new Vector3(0, height, 0) * speed / 2;

            return;
        }
        if (Physics.Raycast(body.transform.position, right, zR)) //проверка вправо
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

            if (Physics.Raycast(body.transform.position, forward, out hit, xR + 0.1f) && hit.collider.tag == "flat")
            {
                if (movZ > 0)
                    movZ = 0;
            }
            if (Physics.Raycast(body.transform.position, -forward, out hit, xR + 0.1f) && hit.collider.tag == "flat")
            {
                if (movZ < 0)
                    movZ = 0;
            }

            body.transform.position += (right * movX + forward * movZ) * speed;
            body.transform.position += new Vector3(0, height, 0) * speed / 2;

            return;
        }
        if (Physics.Raycast(body.transform.position, -right, out hit, zR) && hit.collider.tag == "flat") //проверка влево
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

            if (Physics.Raycast(body.transform.position, forward, out hit, xR + 0.1f) && hit.collider.tag == "flat")
            {
                if (movZ > 0)
                    movZ = 0;
            }
            if (Physics.Raycast(body.transform.position, -forward, out hit, xR + 0.1f) && hit.collider.tag == "flat")
            {
                if (movZ < 0)
                    movZ = 0;
            }

            body.transform.position += (right * movX + forward * movZ) * speed;
            body.transform.position += new Vector3(0, height, 0) * speed / 2;

            return;
        }

        body.transform.position += (right * movX + forward * movZ) * speed;
        body.transform.position += new Vector3(0, height, 0) * speed / 2;

        f = false;
        b = false;
        r = false;
        l = false;
    }
}