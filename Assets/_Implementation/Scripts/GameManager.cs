using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject Apolo;

    void Awake()
    {
        if (instance == null)
            instance = this;
    }
    public void ReachGoal()
    {
        Apolo.GetComponent<Rigidbody2D>().gravityScale = -.5f;
    }
}
