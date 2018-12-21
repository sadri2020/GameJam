using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[RequireComponent(typeof(LineRenderer))]
public class LightGenerator2D : MonoBehaviour
{
    public LineRenderer _lineRenderer;

    public int maxReflectionCount = 5;
    public float maxStepDistance = 200;

    public LightColor lightColor = LightColor.WHITE;
    public LightDirection lightDirection = LightDirection.DOWN;

    Vector3 direction;

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

    public enum LightDirection
    {
        UP,
        DOWN,
        RIGHT,
        LEFT,
        FORWARD,
        BACK
    }

    // Use this for initialization
    void Start()
    {
        SetDirection();

        _lineRenderer.positionCount = maxReflectionCount;

    }

    // Update is called once per frame
    protected void Update()
    {
        _lineRenderer.SetPosition(0, this.transform.position);

        DrawPredictedReflectionPattern(this.transform.position + direction * 0.75f,
            direction, maxReflectionCount - 1);
    }

    void SetDirection()
    {
        switch (lightDirection)
        {
            case LightDirection.UP:
                direction = transform.up;
                break;
            case LightDirection.DOWN:
                direction = -transform.up;
                break;
            case LightDirection.RIGHT:
                direction = transform.right;
                break;
            case LightDirection.LEFT:
                direction = -transform.right;
                break;
            case LightDirection.FORWARD:
                direction = transform.forward;
                break;
            case LightDirection.BACK:
                direction = -transform.forward;
                break;
        }
    }

    protected void OnDrawGizmos()
    {

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
        //Handles.ArrowHandleCap(0, this.transform.position + direction * 0.25f, this.transform.rotation,
        //    0.5f, EventType.Repaint);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, 0.25f);
    }

    private void DrawPredictedReflectionPattern(Vector2 position, Vector2 direction, int reflectionsRemaining)
    {
        if (reflectionsRemaining == 0)
        {
            return;
        }

        Ray2D ray = new Ray2D(position, direction);
        RaycastHit2D[] hits;
        hits = Physics2D.RaycastAll(position, direction);
        if (hits.Length > 0)
        {
            RaycastHit2D hit = hits[0];
            if (hits[0].collider.gameObject.CompareTag("Soorakh")
                && hits[1].collider.gameObject.CompareTag("Block"))
            {
                if (hits[0].collider.GetComponent<CheckCollision>().isCollide == false)
                {
                    hit = hits[1];
                }
                else if (hits.Length >= 3)
                    hit = hits[2];
                else
                    position += direction * maxStepDistance;
            }
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
            else if (hit.collider.gameObject.CompareTag("Prism"))
            {
                hit.collider.GetComponent<Pyramid2D>().ActivePyramid();
                DrawAllRemainedPositions(hit.point, reflectionsRemaining);
                return;
            }
            else if (hit.collider.gameObject.CompareTag("Goal"))
            {
                position = hit.point;
                if (lightColor == LightColor.RED)
                    GameManager.instance.ReachGoal();
            }
        }
        else
        {
            position += direction * maxStepDistance;
        }

        //Gizmos.color = Color.yellow;
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