using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject FlatMirror;
    public GameObject Soorakh;
    public GameObject Prism;

    private GameObject currentItemPickUp;
    private Vector3 mousePos;

    void Update()
    {
        mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);

        if (Input.GetMouseButtonUp(0))
        {
            if (currentItemPickUp != null)
            {
                currentItemPickUp.GetComponent<Item>().Drop();
                currentItemPickUp = null;
            }
        }

        if (Input.GetMouseButton(0))
        {
            if (currentItemPickUp != null)
            {
                currentItemPickUp.transform.position = Camera.main.ScreenToWorldPoint(mousePos);
            }
        }
    }
    public void PickUpFlatMirror()
    {
        currentItemPickUp = FlatMirror;
    }
    public void PickUpSoorakh()
    {
        currentItemPickUp = Soorakh;
    }
    public void PickUpPrism()
    {
        currentItemPickUp = Prism;
    }
}
