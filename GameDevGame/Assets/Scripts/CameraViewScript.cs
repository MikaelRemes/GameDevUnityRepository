using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraViewScript : MonoBehaviour
{
    public Vector3 planetViewPosition = new Vector3(0,5,-52);
    public Quaternion planetViewRotation =  Quaternion.Euler(5, 0, 0);
    public Vector3 orbitViewPosition = new Vector3(0,170,-170);
    public Quaternion orbitViewRotation = Quaternion.Euler(45,0,0);
    public int cameraState = 0;

    // Start is called before the first frame update
    void Start()
    {
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
