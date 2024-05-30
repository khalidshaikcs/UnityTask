using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour
{
    public Transform target; // Reference to the target
    public float rotationSpeed = 15.0f;
    public float zoomSpeed = 2.0f;//zoom speed
    public float minZoomDistance = 2.0f;//Max zoom distance
    public float maxZoomDistance = 10.0f;//Min Zoom distance
    public float zoomVal = 0.2f;//zoom value for button click

    bool isRotRightPressed = false;
    bool isRotLeftPressed = false;

    private float currentZoom = 5.0f;

    void Update()
    {
        // Camera Zoom
        float zoomInput = Input.GetAxis("Mouse ScrollWheel");
        currentZoom -= zoomInput * zoomSpeed;
        currentZoom = Mathf.Clamp(currentZoom, minZoomDistance, maxZoomDistance);
        transform.position = target.position - transform.forward * currentZoom;


        //Camera Rotation
        transform.LookAt(target);//Looking at same target while rotating

        if(isRotRightPressed)
        {
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        }

        if (isRotLeftPressed)
        {
            transform.Rotate(Vector3.down * rotationSpeed * Time.deltaTime);
        }

    }



    //Event Triggers to check the Press of buttons continuously
    public void RotateRightPressed()
    {
        isRotRightPressed = true;
    }

    public void RotateRightReleased()
    {
        isRotRightPressed = false;
    }

    public void RotateLeftPressed()
    {
        isRotLeftPressed = true;
    }

    public void RotateLeftReleased()
    {
        isRotLeftPressed = false;
    }

    //Zoom Buttons
    public void ZoomIn()
    {
        currentZoom -= zoomVal * zoomSpeed;
        currentZoom = Mathf.Clamp(currentZoom, minZoomDistance, maxZoomDistance);
        transform.position = target.position - transform.forward * currentZoom;
    }

    public void ZoomOut()
    {
        currentZoom += zoomVal * zoomSpeed;
        currentZoom = Mathf.Clamp(currentZoom, minZoomDistance, maxZoomDistance);
        transform.position = target.position - transform.forward * currentZoom;
    }

    public void HomeBtn()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
