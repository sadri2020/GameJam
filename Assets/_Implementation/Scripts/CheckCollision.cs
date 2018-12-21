using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollision : MonoBehaviour
{
    public bool isCollide = false;
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Block"))
            isCollide = true;
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.CompareTag("Block"))
            isCollide = false;
    }
}
