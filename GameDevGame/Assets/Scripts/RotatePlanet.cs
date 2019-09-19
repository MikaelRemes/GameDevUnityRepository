﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlanet : MonoBehaviour
{
    public float rotateSpeed=40f;
    public static bool rotateEnabled = false;
    
    void OnMouseDrag()
    {
        if (rotateEnabled)
        {
            float rotateX = Input.GetAxis("Mouse X") * rotateSpeed * Mathf.Deg2Rad;
            float rotateY = Input.GetAxis("Mouse Y") * rotateSpeed * Mathf.Deg2Rad;

            transform.Rotate(Vector3.up, -rotateX);
            transform.Rotate(Vector3.right, rotateY);
        }
    }
}