using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherShipAwakeRotation : MonoBehaviour
{

    public GameObject Mothership;
    public GameObject RedLight;
    private int Timer = 0;
    
    // Start is called before the first frame update
    void Awake()
    {
        //Hide objects during randomize
        Mothership.SetActive(false);
        RedLight.SetActive(false);
        GetComponent<LineRenderer>().enabled = false;

        //Destroy this script after rotation is randomized and secured
        InvokeRepeating("TimerFunction", 0.5f, 0.5f);
        RandomRotation();
    }

    // Update is called once per frame
    void RandomRotation()
    {
        transform.parent.rotation = Quaternion.Euler(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Mothership")
        {
            Timer = 0;
            RandomRotation();
        }
    }

    void TimerFunction()
    {
        Timer = Timer + 1;
        if (Timer > 3)
        {
            DestroyMyself();
        }
    }

    void DestroyMyself()
    {
        //Set objects visible
        Mothership.SetActive(true);
        RedLight.SetActive(true);
        GetComponent<LineRenderer>().enabled = true;

        Destroy(this);
    }
}
