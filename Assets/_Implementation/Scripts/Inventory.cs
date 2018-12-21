using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;

    [Header("Items")]
    //public int maxOfItem;
    public GameObject flatMirror;
    public GameObject soorakh;
    public GameObject prism;

    [Header("Warns")]
    public GameObject cross;

    //private GameObject[] flatMirrors;
    //private GameObject[] soorakhs;
    //private GameObject[] prisms;

    private GameObject currentItemPickUp;
    private Vector3 mousePos;

    void Awake()
    {
        if (instance == null)
            instance = this;
    }
    void Start()
    {
        //flatMirrors = new GameObject[maxOfItem];
        //for(int i = 0; i<maxOfItem; i++)
        //{
        //    flatMirrors[i] = Instantiate(flatMirror);
        //}

        //soorakhs = new GameObject[maxOfItem];
        //for (int i = 0; i < maxOfItem; i++)
        //{
        //    soorakhs[i] = Instantiate(soorakh);
        //}

        //prisms = new GameObject[maxOfItem];
        //for (int i = 0; i < maxOfItem; i++)
        //{
        //    prisms[i] = Instantiate(prism);
        //}
    }
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
        var clone = Instantiate(flatMirror);
        currentItemPickUp = clone;
    }
    public void PickUpSoorakh()
    {
        //var clone = Instantiate(soorakh);
        currentItemPickUp = soorakh;
    }
    public void PickUpPrism()
    {
        //var clone = Instantiate(prism);
        currentItemPickUp = prism;
    }
    public void SetCrossPosition(Vector3 position)
    {
        cross.transform.position = position;
        StartCoroutine(CrossFade());
    }
    IEnumerator CrossFade()
    {
        yield return new WaitForSeconds(1);
        cross.transform.position = new Vector3(-1000, -1000, 0);
    }
}
