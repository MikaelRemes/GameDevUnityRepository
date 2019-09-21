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
        Vector3 handleRotationAngles = new Vector3(0,0,0);
        if (Input.GetKey("w"))
        {
            handleRotationAngles.x += rotateSpeed;
        }
        if (Input.GetKey("a"))
        {
            handleRotationAngles.y += rotateSpeed;
        }
        if (Input.GetKey("s"))
        {
            handleRotationAngles.x -= rotateSpeed;
        }
        if (Input.GetKey("d"))
        {
            handleRotationAngles.y -= rotateSpeed;
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
        transform.rotation = transform.rotation * Quaternion.Euler(handleRotationAngles);
        //transform.rotation = Quaternion.Euler(handleRotationAngles.x, handleRotationAngles.y, 0);
    }
}
