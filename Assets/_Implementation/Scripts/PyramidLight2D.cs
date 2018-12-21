using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

public class PyramidLight2D : LightGenerator2D
{
    private bool isGenerate;

    public bool IsGenerate
    {
        get { return isGenerate; }
        set { isGenerate = value; }
    }

    private void Update()
    {
        if (isGenerate)
            base.Update();

        isGenerate = false;

        StartCoroutine(ClearLines());
    }

    IEnumerator ClearLines()
    {
        yield return new WaitForSeconds(0.5f);
        if(isGenerate == false)
            DrawAllRemainedPositions(transform.position, maxReflectionCount);
    }
}