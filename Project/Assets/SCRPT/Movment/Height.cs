using UnityEngine;

public class Height : MonoBehaviour
{
    public GameObject player;
    public GeneralManager generalManager;
    public float hspeed = 0.5f;

    void Update()
    {
        if (!generalManager.isHeight || !generalManager.movement)
        {
            return;
        }

        RaycastHit hit;

        float height = Input.GetAxis("Submit");

        if (Physics.Raycast(player.transform.position, Vector3.up, out hit, 0.45f) && hit.collider.tag == "flat")
        {
            if (height > 0)
                height = 0;
        }
        if (Physics.Raycast(player.transform.position, Vector3.down, out hit, 0.6f) && hit.collider.tag == "flat")
        {
            if (height < 0)
                height = 0;
        }

        player.transform.position += new Vector3(0, height, 0) * hspeed;

    }
}
