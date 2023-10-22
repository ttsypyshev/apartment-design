using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using System.Collections;
public class spownObject : MonoBehaviour
{
    public void OnClick()
    {
        string buttonName = gameObject.transform.name;
        print(buttonName);
    }
}
