using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretPlacerV2 : MonoBehaviour
{
    public static bool placingTurret = false;

    public GameObject planet;
    public GameObject basicTurret;
    public Camera cameraView;

    void OnMouseDown()
    {
        if (placingTurret)
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
    private void placeTurret(Transform spot)
    {
        Instantiate(basicTurret, spot.position, spot.rotation);
    }
}
