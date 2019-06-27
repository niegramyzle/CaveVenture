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
    private LineRenderer lr;
    private int pointIndex;

    private void Start()
    {
        pointIndex = 0;
        lr = GetComponent<LineRenderer>();
        lr.positionCount = 1;
        lr.SetPosition(0, transform.position + transform.forward * 0.75f);
    }

    void Update()
    {
        //resetBeams();
        lr.positionCount = 1;
        pointIndex = 0;
        lr.SetPosition(0, transform.position + transform.forward * 0.75f);
        DrawPredictedReflectionPattern2(transform.position + transform.forward * 0.75f, transform.forward, maxReflectionCount);
    }

  /*  private void OnDrawGizmos()
    {
        Handles.color = Color.red;
        Handles.ArrowHandleCap(0, transform.position + transform.forward * 0.25f, transform.rotation, 0.5f, EventType.Repaint);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 0.25f);

        DrawPredictedReflectionPattern(transform.position+transform.forward*0.75f, transform.forward, maxReflectionCount);
    }*/

//    private void resetBeams()
//    {
//        foreach(var beam in beams)
//        {
//            beam.SetActive(false);
//        }
//    }

//    private void DrawPredictedReflectionPattern(Vector3 position, Vector3 direction, int reflectionsRemaining)
//    {
//        if (reflectionsRemaining == 0)
//            return;

//        Vector3 startingPosition = position;
//        Ray ray = new Ray(position, direction);
//        RaycastHit hit;

//        if(Physics.Raycast(ray,out hit, maxStepDistance))
//        {
//            var target = reflectingObjects.Find(elem=>hit.collider.gameObject==elem);
//            Debug.Log("11111u");
//            if (target!=null)
//            {

//                direction = Vector3.Reflect(direction, hit.normal);
//                position = hit.point;
//                beams[reflectionsRemaining - 1].SetActive(true);
//                beams[reflectionsRemaining - 1].transform.position = position;
//                beams[reflectionsRemaining - 1].transform.rotation = Quaternion.LookRotation(direction);
//            }
//            else
//            {
//              //  Gizmos.color = Color.yellow;
//               // Gizmos.DrawLine(startingPosition, hit.point);
//                return;
//            }
//        }
//        else
//        {
//            position += direction * maxStepDistance;
//        }
//      //  Gizmos.color = Color.yellow;
////Gizmos.DrawLine(startingPosition, position);
//        DrawPredictedReflectionPattern(position, direction, reflectionsRemaining - 1);

//    }

    private void DrawPredictedReflectionPattern2(Vector3 position, Vector3 direction, int reflectionsRemaining)
    {
        if (reflectionsRemaining == 0)
            return;

        Vector3 startingPosition = position;
        Ray ray = new Ray(position, direction);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, maxStepDistance))
        {
            var target = reflectingObjects.Find(elem => hit.collider.gameObject == elem);
            Debug.Log("11111u");
            if (target != null)
            {
                direction = Vector3.Reflect(direction, hit.normal);
                position = hit.point;
                lr.positionCount++;
                pointIndex++;
                lr.SetPosition(pointIndex, position);
            }
            else
            {
                lr.positionCount++;
                pointIndex++;
                lr.SetPosition(pointIndex, hit.transform.position);
                return;
            }
        }
        else
        {
            position += direction * maxStepDistance;
            lr.positionCount++;
            pointIndex++;
            lr.SetPosition(pointIndex, position);
        }
        DrawPredictedReflectionPattern2(position, direction, reflectionsRemaining - 1);
    }
}
