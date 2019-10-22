using UnityEngine;
using UnityEngine.UI;

public class UpgradePanelScript : MonoBehaviour
{

    public Camera cameraView;
    public string turretTag = "Turret";

    public Text turretNameText;
    public Text turretDamageText;
    public Text turretFireRateText;
    public Text turretRangeText;

    public GameObject upgradeButton1;
    public GameObject upgradeButton2;
    public GameObject upgradeButton3;
   
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = cameraView.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                GameObject objectHit = hit.collider.gameObject;
                if (objectHit.tag.Equals(turretTag))
                {
                    TurretScript turret = objectHit.GetComponent<TurretScript>();
                    turretNameText.text = turret.turretName;
                    turretDamageText.text = "Damage: " + turret.damage;
                    turretFireRateText.text = "Fire rate / sec: " + turret.fireRatePerSec;
                    turretRangeText.text = "Range: " + turret.range;

                    upgradeButton1.GetComponentInChildren<Text>().text = turret.upgradeName1 + "(" + turret.upgradeCost1 + ")";
                    upgradeButton2.GetComponentInChildren<Text>().text = turret.upgradeName2 + "(" + turret.upgradeCost2 + ")";
                    upgradeButton3.GetComponentInChildren<Text>().text = turret.upgradeName3 + "(" + turret.upgradeCost3 + ")";
                }
            }
        }
    }
}
