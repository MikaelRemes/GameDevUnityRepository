using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonRotator : MonoBehaviour
{
    public float rotateSpeed = 10f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, rotateSpeed * Time.deltaTime, 0), Space.Self);
    }
}
