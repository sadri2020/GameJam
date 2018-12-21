using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

public class PyramidLight : LightGenerator
{
    private bool isGenerate;

    public bool IsGenerate
    {
        get { return isGenerate; }
        set { isGenerate = value; }
    }

    private void OnDrawGizmos()
    {
        if (isGenerate)
            base.OnDrawGizmos();

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