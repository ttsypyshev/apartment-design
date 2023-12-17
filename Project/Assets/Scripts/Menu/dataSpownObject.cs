using UnityEngine;
using System.Collections.Generic;

public class dataSpownObject : MonoBehaviour
{
    public ChoiceObjects choiceObjects;
    public SpownObject spownObject;
    public GeneralManager generalManager;
    public GameObject player;
    public Camera camera;
    public bool act = false;


    public string bodyName;
    public GameObject body;

    public List<GameObject> prefab;

    public Vector3 forward;
    public Vector3 right;
    public Vector3 up;


    // Update is called once per frame
    void Update()
    {
        if (act)
        {
            choiceObjects.condition = true;
            choiceObjects.body = body;
            choiceObjects.bodyName = bodyName;
            act = false;
        }

        forward = player.transform.forward;
        right = player.transform.right;
        up = player.transform.up;

        forward.y = 0f;
        right.y = 0f;
        up.y = 0f;
        forward.Normalize();
        right.Normalize();
        up.Normalize();
    }
}
