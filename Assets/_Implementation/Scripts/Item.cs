using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private GameObject targetPlaceHolder;

    void OnTriggerEnter2D(Collider2D collider)
    {
        targetPlaceHolder = collider.gameObject;
    }
    void OnTriggerExit2D()
    {
        targetPlaceHolder = null;
    }
    public void Drop()
    {
        if (targetPlaceHolder != null)
            transform.position = targetPlaceHolder.transform.position;
        else
            transform.position = new Vector3(-1000, -1000, 0);
    }
}
