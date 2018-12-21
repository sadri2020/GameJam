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
        {
            if (targetPlaceHolder.tag == "Block" && tag != "Soorakh")
            {
                Inventory.instance.SetCrossPosition(transform.position);
                transform.position = new Vector3(-1000, -1000, 0);
            }
        }
    }
    //void OnTriggerEnter2D(Collider2D collider)
    //{
    //    if (targetPlaceHolder != null)
    //        targetPlaceHolder.GetComponent<SpriteRenderer>().color = Color.white;

    //    if (collider.gameObject.GetComponent<Item>() == null)
    //        targetPlaceHolder = collider.gameObject;
    //    else
    //        targetPlaceHolder = null;

    //    if (targetPlaceHolder != null)
    //    {
    //        targetPlaceHolder.GetComponent<SpriteRenderer>().color = Color.gray;
    //        if (targetPlaceHolder.tag == "Block" && tag != "Soorakh")
    //            targetPlaceHolder.GetComponent<SpriteRenderer>().color = Color.red;
    //    }
    //}
    //void OnTriggerExit2D()
    //{
    //    if (targetPlaceHolder != null)
    //        targetPlaceHolder.GetComponent<SpriteRenderer>().color = Color.white;

    //    targetPlaceHolder = null;
    //}
    //public void Drop()
    //{
    //    if (targetPlaceHolder == null || (targetPlaceHolder.tag == "Block" && tag != "Soorakh"))
    //        transform.position = new Vector3(-1000, -1000, 0);
    //    else
    //        transform.position = targetPlaceHolder.transform.position;
    //}
}
