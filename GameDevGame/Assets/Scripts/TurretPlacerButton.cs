using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretPlacerButton : MonoBehaviour
{
    private bool placingTurret=false;
    
    public GameObject planet;
    public GameObject basicTurret;
    public Camera cameraView;

    void Awake()
    {
        GetComponent<Image>().color = Color.red;
        if (!placingTurret) GetComponent<Image>().color = Color.red;
        else GetComponent<Image>().color = Color.green;
    }

    public void PressedButton()
    {
        if (placingTurret)
        {
            GetComponent<Image>().color = Color.red;
        }
        else
        {
            GetComponent<Image>().color = Color.green;
        }
        placingTurret = !placingTurret;
    }

    public void DisableTurretPlacement()
    {
        GetComponent<Image>().color = Color.red;
        placingTurret = false;
    }

    void Update()
    {
        if (placingTurret)
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray ray = cameraView.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit))
                {
                    GameObject objectHit = hit.collider.gameObject;
                    if (objectHit.Equals(planet))
                    {
                        placeTurret(hit.transform);
                    }
                }
            }
        }
    }

    private void placeTurret(Transform spot)
    {
        GameObject currentTurret = Instantiate(basicTurret);
        currentTurret.transform.position = spot.position;
        currentTurret.transform.rotation = spot.rotation;
    }
}
