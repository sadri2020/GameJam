using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pyramid2D : MonoBehaviour
{
    public PyramidLight2D[] pyramidLights;
    
    public void ActivePyramid()
    {
        for (int i = 0; i < pyramidLights.Length; i++)
        {
            pyramidLights[i].IsGenerate = true;
        }
    }
}
