using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraMovement : MonoBehaviour
{
    // set in inspector
    [SerializeField] private float zoomSpeed;
    [SerializeField] private float minimumCameraSize;
    [SerializeField] private float maximumCameraSize;
    // the below six variables are for defining the size of the map, so you can't scroll forever
    [SerializeField] private float minX;
    [SerializeField] private float maxX;
    [SerializeField] private float minY;
    [SerializeField] private float maxY;
    [SerializeField] private float minZ;
    [SerializeField] private float maxZ;
    [SerializeField] private float dragSpeed;
    // here just for testing and because it could be an option in the future
    [SerializeField] private bool controlsInverted;

    private Camera _camera;
    private Vector3 _cameraDirection;
    private Vector3 _dragOrigin;
    private void Awake()
    {   
        _camera = GetComponent<Camera>();
    }

    void Update()
    {
        HandleZoom();
        HandleMovement();
    }

    // handles having a small amount of zoom for a feeling of greater immersion
    private void HandleZoom()
    {
        float scrollWheel = Input.GetAxis("Mouse ScrollWheel");

        // subtract because as you scroll in you want the size to go down, which makes it look more zoomed in
        float newZoomSize = _camera.orthographicSize - (scrollWheel * zoomSpeed);

        _camera.orthographicSize = Mathf.Clamp(newZoomSize, minimumCameraSize, maximumCameraSize);
    }

    // right click to rotate around and left click to pan around a little bit
    private void HandleMovement()
    {
        // if the mouse is being held move the camera based on the original drag position and the current mouse position
        if(!Input.GetMouseButton(0)) return;
    
        Vector2 movement = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        // flip the axis around because of the orthographic rotation
        _cameraDirection.z = -movement.x * dragSpeed;
        _cameraDirection.x = movement.x * dragSpeed;
        _cameraDirection.y = movement.y * dragSpeed;

        transform.Translate(controlsInverted ? _cameraDirection : -_cameraDirection, Space.World);

        float x = Mathf.Clamp(transform.position.x, minX, maxX);
        float y = Mathf.Clamp(transform.position.y, minY, maxY);
        float z = Mathf.Clamp(transform.position.z, minZ, maxZ);

        transform.position = new Vector3(x, y, z);
    }
}
