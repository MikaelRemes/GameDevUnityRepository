using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikerRotator : MonoBehaviour
{
    public float rotateSpeed = 200f;

    void Update()
    {
        float rotateAmount = Time.deltaTime * rotateSpeed;
        transform.Rotate(new Vector3(rotateAmount, rotateAmount * 0.7f, rotateAmount * 0.3f), Space.World);
    }
}
