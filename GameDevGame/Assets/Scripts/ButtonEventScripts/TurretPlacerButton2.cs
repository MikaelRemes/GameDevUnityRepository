using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretPlacerButton2 : MonoBehaviour
{
    private bool placingTurret=false;
    
    public string planetTag = "Planet";
    public string moonTag="Moon";
    public GameObject basicTurret;
    public int cost=25;
    public Camera cameraView;
    public string shopButtonTag = "ShopButton";

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
            GameObject[] buttons = GameObject.FindGameObjectsWithTag("ShopButton");
            foreach (GameObject button in buttons)
            {
                //disable turret placement
                button.GetComponent<TurretPlacerButton2>().DisableTurretPlacement();
            }
        }
        else
        {
            GameObject[] buttons = GameObject.FindGameObjectsWithTag("ShopButton");
            foreach (GameObject button in buttons)
            {
                //disable turret placement
                button.GetComponent<TurretPlacerButton2>().DisableTurretPlacement();
            }
            EnableTurretPlacement();
        }
    }

    public void DisableTurretPlacement()
    {
        GetComponent<Image>().color = Color.red;
        placingTurret = false;
    }

    public void EnableTurretPlacement()
    {
        GetComponent<Image>().color = Color.green;
        placingTurret = true;
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
                    //POSSIBLE TODO: ignore moon if planet is hit or vice versa
                    //TODO: check if enough monies
                    //TODO: disable placement of turrets on top of one another
                    GameObject objectHit = hit.collider.gameObject;
                    if (objectHit.tag.Equals(planetTag))
                    {
                        placeTurret(hit.point, hit.normal, objectHit);
                    }
                    else if (objectHit.tag.Equals(moonTag))
                    {
                        placeTurret(hit.point, hit.normal, objectHit);
                    }
                }
            }
        }
    }

    private void placeTurret(Vector3 hitPos, Vector3 hitNormal, GameObject parentCelestial)
    {
        GameObject currentTurret = Instantiate(basicTurret);
        currentTurret.transform.position = hitPos;
        currentTurret.transform.rotation = Quaternion.FromToRotation(Vector3.up, hitNormal);
        currentTurret.transform.parent = parentCelestial.transform;
        Player.monies -= cost;
        Debug.Log("Placed turret, cost: " + cost);
    }
}
