using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraController : MonoBehaviour
{
    // Speed at which the camera moves and rotates
    // Speed at which the camera rotates

    public float movementSpeed = 10.0f;

    public float edgeSensitivity = 10.0f;

    public float maxMovementSpeed = 50.0f;

    public GameObject targetObject;
    public float rotationSpeed = 100.0f;

    // Zoom settings
    public float minZoom = 1.0f;
    public float maxZoom = 10.0f;
    public float zoomSpeed = 1.0f;

    // Update is called once per frame
    void Update()
    {

        // Rotate the camera with the right mouse button
        if (Input.GetMouseButton(1))
        {
            float mouseX = Input.mousePosition.x;
            float mouseY = Input.mousePosition.y;
            transform.RotateAround(targetObject.transform.position, transform.up, mouseX * rotationSpeed );
            transform.RotateAround(targetObject.transform.position, transform.right, mouseY * -rotationSpeed);
        }

    

        if (!EventSystem.current.IsPointerOverGameObject())
        {
            Zoom();
        }
    }

    void Zoom()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        scroll = -scroll;
        // Check if the zoom level is within the specified range
        float currentZoom = transform.position.y;
        float targetZoom = currentZoom + scroll * zoomSpeed;
        if (targetZoom < minZoom || targetZoom > maxZoom)
        {
            // Adjust the scroll input to keep the zoom level within the range
            scroll = (targetZoom < minZoom) ? minZoom - currentZoom : maxZoom - currentZoom;
        }

        // Update the camera's position based on the scroll input
        transform.position += new Vector3(0, scroll * zoomSpeed,0);
    }

}