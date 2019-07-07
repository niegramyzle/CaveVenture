using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

public class MirrorReflection : MonoBehaviour
{
    [SerializeField] private int maxReflectionCount;
    [SerializeField] private float maxStepDistance;
    [SerializeField] List<GameObject> reflectingObjects;
    [SerializeField] GameObject mainTarget;

    private LineRenderer lineRenderer;
    private int pointIndex;

    private void Start()
    {
        pointIndex = 0;
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, transform.position + transform.forward * 0.75f);
        foreach(var elem in reflectingObjects)
        {
            var obj = elem.GetComponent<HorizontalRotating>();
            if(obj!=null)
            {
                obj.updateDependentMethod += laserFire;
            }
        }
        laserFire();
    }

    //void Update()
    //{
    //        lineRenderer.positionCount = 1;
    //        pointIndex = 0;
    //        lineRenderer.SetPosition(0, transform.position + transform.forward * 0.75f);
    //        DrawPredictedReflectionPatternLoop(transform.position+ transform.forward, transform.forward);
    //}

    void laserFire()
    {
        lineRenderer.positionCount = 1;
        pointIndex = 0;
        lineRenderer.SetPosition(0, transform.position + transform.forward * 0.75f);
        DrawPredictedReflectionPatternLoop(transform.position + transform.forward, transform.forward);
    }

    //private void OnDrawGizmos()
    //{
    //    Handles.color = Color.red;
    //    Handles.ArrowHandleCap(0, transform.position + transform.forward * 0.25f, transform.rotation, 0.5f, EventType.Repaint);
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawWireSphere(transform.position, 0.25f);

    //    DrawPredictedReflectionPatternLoopGizmo(transform.position + transform.forward, transform.forward);
    //}

    //private void DrawPredictedReflectionPatternLoopGizmo(Vector3 position, Vector3 direction)
    //{
    //    Vector3 startingPosition;
    //    Ray ray;
    //    RaycastHit hit;
    //    for (int i = maxReflectionCount; i > 0; i--)
    //    {
    //        startingPosition = position;
    //        ray = new Ray(position, direction);

    //        if (Physics.Raycast(ray, out hit, maxStepDistance))
    //        {
    //            var target = reflectingObjects.Find(elem => hit.collider.gameObject == elem);
    //            if (target != null)
    //            {
    //                direction = Vector3.Reflect(direction, hit.normal);
    //                position = hit.point;
    //                Gizmos.color = Color.yellow;
    //                Gizmos.DrawLine(startingPosition, hit.point);
    //            }
    //        }
    //        else
    //        {
    //            position += direction * maxStepDistance;
    //            Gizmos.color = Color.yellow;
    //            Gizmos.DrawLine(startingPosition, hit.point);
    //            break;
    //        }
    //        Gizmos.color = Color.yellow;
    //        Gizmos.DrawLine(startingPosition, hit.point);
    //    }
    //}

    private void DrawPredictedReflectionPatternLoop(Vector3 position, Vector3 direction)
    {
        Ray ray;
        RaycastHit hit;
        for (int i = maxReflectionCount; i > 0; i--)
        {
            ray = new Ray(position, direction);

            if (Physics.Raycast(ray, out hit, maxStepDistance))
            {
                var target = reflectingObjects.Find(elem => hit.collider.gameObject == elem);
                if (target != null)
                {
                    if (target == mainTarget)
                    {
                        mainTarget.GetComponent<LaserContact>().makeCommunication();
                        break;
                    }
                    direction = Vector3.Reflect(direction, hit.normal);
                    position = hit.point;
                    lineRenderer.positionCount++;
                    pointIndex++;
                    lineRenderer.SetPosition(pointIndex, position);
                }
                else
                {
                    lineRenderer.positionCount++;
                    pointIndex++;
                    lineRenderer.SetPosition(pointIndex, hit.point);
                    break;
                }
            }
            else
            {
                position += direction * maxStepDistance;
                lineRenderer.positionCount++;
                pointIndex++;
                lineRenderer.SetPosition(pointIndex, position);
                break;
            }
        }
    }
   
}
