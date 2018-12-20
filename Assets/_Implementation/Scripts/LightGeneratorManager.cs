using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightGeneratorManager : MonoBehaviour
{
    public static LightGeneratorManager instance;

    public LightGenerator[] lightGenerators;

    private int nextLightIndex = 1;

    void Awake()
    {
        if (instance == null)
            instance = this;
    }
    public void SetNextLightActive(Vector3 position)
    {
        if (nextLightIndex < lightGenerators.Length)
        {
            lightGenerators[nextLightIndex].gameObject.SetActive(true);
            lightGenerators[nextLightIndex].transform.position = position;
            nextLightIndex++;
        }
    }
}
