using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLookScript : MonoBehaviour
{
    [SerializeField] private Transform cam;

    private float xWorldAxisRotation; // rotates around the x axis
    private Vector3 yWorldAxisRotation; // rotates around the y axis
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Locks the cursor so it doesn't go offscreen
    }

    // Update is called once per frame
    void Update()
    {
        // Gets the X + Y axes
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // Determines the rotation based on mousemovement, but caps mouse movement so they don't look behind themselves vertically
        xWorldAxisRotation -= mouseY;
        xWorldAxisRotation = Mathf.Clamp(xWorldAxisRotation, -90f, 90f);

        // Creates a Vector for the mouse movement so they can look to the left and right
        yWorldAxisRotation = Vector3.up * mouseX;

        //Applies xRotation to the camera
        cam.localRotation = Quaternion.Euler(xWorldAxisRotation, 0f, 0f);
        //Applies yRotation to the entire player object, which includes the camera
        transform.Rotate(yWorldAxisRotation);
    }
}
