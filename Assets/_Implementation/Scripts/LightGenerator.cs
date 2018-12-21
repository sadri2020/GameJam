using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[RequireComponent(typeof(LineRenderer))]
public class LightGenerator : MonoBehaviour
{
    public LineRenderer _lineRenderer;

    public int maxReflectionCount = 5;
    public float maxStepDistance = 200;

    public LightColor lightColor = LightColor.WHITE;
    
    public enum LightColor
    {
        WHITE,
        RED,
        DARK_BLUE,
        LIGHT_BLUE,
        PURPLE,
        YELLOW,
        ORANGE,
        GREEN,
    }
    // Use this for initialization
    void Start()
    {
        _lineRenderer.startWidth = 0.45f;
        _lineRenderer.endWidth = 0.45f;
    }

    // Update is called once per frame
    void Update()
    {
    }

    protected void OnDrawGizmos()
    {
        _lineRenderer.positionCount = maxReflectionCount;

        //_lineRenderer.startColor = color;
        //_lineRenderer.endColor = color;

        //float alpha = 1.0f;
        //Gradient gradient = new Gradient();
        //gradient.SetKeys(
        //	new GradientColorKey[] { new GradientColorKey(Color.green, 0.0f), new GradientColorKey(Color.red, 1.0f), new GradientColorKey(Color.red, 1.0f) },

        //new GradientAlphaKey[] { new GradientAlphaKey(alpha, 0.0f), new GradientAlphaKey(alpha, 1.0f), new GradientAlphaKey(alpha, 1.0f)  }

        //);
        //_lineRenderer.colorGradient = gradient;

        //Handles.color = Color.red;
        //Handles.ArrowHandleCap(0, this.transform.position + this.transform.forward * 0.25f, this.transform.rotation,
        //    0.5f, EventType.Repaint);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, 0.25f);

        _lineRenderer.SetPosition(0, this.transform.position);

        DrawPredictedReflectionPattern(this.transform.position  + this.transform.forward * 0.75f,
            this.transform.forward, maxReflectionCount-1);
    }

    private void DrawPredictedReflectionPattern(Vector3 position, Vector3 direction, int reflectionsRemaining)
    {
        if (reflectionsRemaining == 0)
        {
            return;
        }

        Ray ray = new Ray(position, direction);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, maxStepDistance))
        {
            if (hit.collider.gameObject.CompareTag("Flat_mirror"))
            {
                direction = Vector3.Reflect(direction, hit.normal);
                position = hit.point;
            }
            else if (hit.collider.gameObject.CompareTag("Block"))
            {
                DrawAllRemainedPositions(hit.point, reflectionsRemaining);
                return;
            }
            else if (hit.collider.gameObject.CompareTag("Soorakh"))
            {
                position += direction * maxStepDistance;
            }
            else if (hit.collider.gameObject.CompareTag("Prism"))
            {
                hit.collider.GetComponent<Pyramid>().ActivePyramid();
                DrawAllRemainedPositions(hit.point, reflectionsRemaining);
                return;
                //LightGeneratorManager.instance.SetNextLightActive(hit.point);
            }
        }
        else
        {
            position += direction * maxStepDistance;
        }

        Gizmos.color = Color.yellow;
        //Gizmos.DrawLine(startingPosition, position);
        _lineRenderer.SetPosition(maxReflectionCount - reflectionsRemaining, position);

        DrawPredictedReflectionPattern(position, direction, reflectionsRemaining - 1);
    }

    protected void DrawAllRemainedPositions(Vector3 pos, int reflectionsRemaining)
    {
        if (reflectionsRemaining == 0)
            return;

        _lineRenderer.SetPosition(maxReflectionCount - reflectionsRemaining, pos);

        DrawAllRemainedPositions(pos, reflectionsRemaining - 1);
    }
}