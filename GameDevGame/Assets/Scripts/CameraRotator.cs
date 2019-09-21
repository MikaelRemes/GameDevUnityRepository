using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotator : MonoBehaviour
{
    public float rotateSpeed = 1f;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w"))
        {
            transform.Rotate(Vector3.right, rotateSpeed);
        }
        if (Input.GetKey("a"))
        {
            transform.Rotate(Vector3.up, rotateSpeed);
        }
        if (Input.GetKey("s"))
        {
            transform.Rotate(Vector3.right, -rotateSpeed);
        }
        if (Input.GetKey("d"))
        {
            transform.Rotate(Vector3.up, -rotateSpeed);
        }
    }
}
