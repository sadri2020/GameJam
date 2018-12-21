using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pyramid : MonoBehaviour
{
    public PyramidLight[] pyramidLights;
    
    public void ActivePyramid()
    {
        for (int i = 0; i < pyramidLights.Length; i++)
        {
            pyramidLights[i].IsGenerate = true;
        }
    }
}
