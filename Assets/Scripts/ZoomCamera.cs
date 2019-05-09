using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomCamera : MonoBehaviour
{
    [SerializeField]
    private Camera characterCamera;
    [SerializeField]
    private MovementInputController movInController;
    [SerializeField]
    private float smooth;
    private int zoom;
    private int normal;

    private void Awake()
    {
       
        zoom = 50;
        normal = 60;
    }

    public void OnEnable()
    {
        movInController.speedZoomingOn += Zoom;
        movInController.speedZoomingOff += Unzoom;
    }
    public void OnDisable()
    {
        movInController.speedZoomingOn -= Zoom;
        movInController.speedZoomingOff -= Unzoom;
    }

    private void Zoom()
    {
        characterCamera.fieldOfView = Mathf.Lerp(characterCamera.fieldOfView, zoom, smooth * Time.deltaTime);
    }

    private void Unzoom()
    {
        characterCamera.fieldOfView = Mathf.Lerp(characterCamera.fieldOfView, normal, smooth * Time.deltaTime);
    }
}
