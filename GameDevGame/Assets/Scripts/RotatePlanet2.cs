using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlanet2 : MonoBehaviour
{
    public GameObject RotateTemp;
    public GameObject CameraHandle;
    public float rotateSpeed = 40f;
    public static bool rotateEnabled2 = true;

    void OnMouseDrag()
    {
        if (rotateEnabled2)
        {
            float rotateX = Input.GetAxis("Mouse X") * rotateSpeed * Mathf.Deg2Rad;
            float rotateY = Input.GetAxis("Mouse Y") * rotateSpeed * Mathf.Deg2Rad;

            RotateTemp.transform.LookAt(CameraHandle.transform);
            CameraHandle.transform.parent = RotateTemp.transform;

            RotateTemp.transform.Rotate(Vector3.up, rotateX);
            RotateTemp.transform.Rotate(Vector3.right, -rotateY);

            CameraHandle.transform.parent = null;
        }
    }
}
