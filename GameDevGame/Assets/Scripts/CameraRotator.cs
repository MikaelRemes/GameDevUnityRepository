using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotator : MonoBehaviour
{
    public float rotateSpeed = 1f;
    public float zoomSpeed = 1f;
    public Camera playerCamera;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w"))
        {
            transform.Rotate(Vector3.right, rotateSpeed, Space.Self);
        }
        if (Input.GetKey("a"))
        {
            if(Vector3.Dot(transform.up, Vector3.down) <= 0)transform.Rotate(Vector3.up, rotateSpeed, Space.World);
            else transform.Rotate(Vector3.up, -rotateSpeed, Space.World);
        }
        if (Input.GetKey("s"))
        {
            transform.Rotate(Vector3.right, -rotateSpeed, Space.Self);
        }
        if (Input.GetKey("d"))
        {
            if (Vector3.Dot(transform.up, Vector3.down) <= 0) transform.Rotate(Vector3.up, -rotateSpeed, Space.World);
            else transform.Rotate(Vector3.up, rotateSpeed, Space.World);
        }
        if (Input.GetKey("q"))
        {
            //currently changing zoom
            Vector3 direction = transform.position - playerCamera.transform.position;
            direction.Normalize();
            playerCamera.transform.position -= direction;
        }
        if (Input.GetKey("e"))
        {
            //currently changing zoom
            Vector3 direction = transform.position - playerCamera.transform.position;
            direction.Normalize();
            playerCamera.transform.position += direction;
        }
    }
}
