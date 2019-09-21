using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraViewScript : MonoBehaviour
{
    public Vector3 planetViewPosition = new Vector3(0,0,-70);
    public Quaternion planetViewRotation =  Quaternion.Euler(0, 0, 0);
    public Vector3 orbitViewPosition = new Vector3(0,0,-260);
    public Quaternion orbitViewRotation = Quaternion.Euler(45,0,0);
    public int cameraState = 0;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = planetViewPosition;
        transform.SetPositionAndRotation(planetViewPosition, planetViewRotation);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("q"))
        {
            transform.SetPositionAndRotation(planetViewPosition, planetViewRotation);
            cameraState = 0;
        }
        if (Input.GetKeyDown("e"))
        {
            transform.SetPositionAndRotation(orbitViewPosition, orbitViewRotation);
            cameraState = 1;
        }
    }
}
