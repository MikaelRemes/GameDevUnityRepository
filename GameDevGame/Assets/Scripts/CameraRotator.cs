using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotator : MonoBehaviour
{
    public float rotateSpeed = 1f;
    public Camera playerCamera;
    public Vector3 planetViewPosition = new Vector3(0, 0, -70);
    public Vector3 orbitViewPosition = new Vector3(0, 0, -260);

    private int cameraState = 0;

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
            //currently changing view resets position
            transform.rotation = Quaternion.Euler(0, 0, 0);
            playerCamera.transform.position = planetViewPosition;
            playerCamera.transform.rotation = Quaternion.Euler(0, 0, 0);
            cameraState = 0;
        }
        if (Input.GetKey("e"))
        {
            //currently changing view resets positions
            transform.rotation = Quaternion.Euler(0, 0, 0);
            playerCamera.transform.position = orbitViewPosition;
            playerCamera.transform.rotation = Quaternion.Euler(0, 0, 0);
            cameraState = 1;
        }
        if (Input.GetKeyDown("r"))
        {
            Debug.Log("" + (transform.localEulerAngles.y <= 90));
        }
    }
}
