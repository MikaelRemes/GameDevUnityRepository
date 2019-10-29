using UnityEngine;
using UnityEngine.UI;

public class UpgradePanelScript : MonoBehaviour
{

    public Camera cameraView;
    public string turretTag = "Turret";
    TurretScript turret;

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
                    turret = objectHit.GetComponent<TurretScript>();
                    updateText();
                }
            }
        }
    }

    void updateText()
    {
        if (turret != null)
        {
            turretNameText.text = turret.turretName;
            turretDamageText.text = "Damage: " + turret.damage;
            turretFireRateText.text = "Fire rate / sec: " + turret.fireRatePerSec;
            turretRangeText.text = "Range: " + turret.range;

            upgradeButton1.GetComponentInChildren<Text>().text = turret.upgradeName1 + "(" + turret.upgradeCost1 + ")";
            if (turret.upgraded1)
            {
                var colors = upgradeButton1.GetComponent<Button>().colors;
                colors.normalColor = new Color(0, 255, 238, 255);
                colors.highlightedColor = new Color(0, 255, 238, 255);
                upgradeButton1.GetComponent<Button>().colors = colors;
            }
            else
            {
                var colors = upgradeButton1.GetComponent<Button>().colors;
                colors.normalColor = Color.red;
                colors.highlightedColor = Color.red;
                upgradeButton1.GetComponent<Button>().colors = colors;
            }
            upgradeButton2.GetComponentInChildren<Text>().text = turret.upgradeName2 + "(" + turret.upgradeCost2 + ")";
            if (turret.upgraded2)
            {
                var colors = upgradeButton2.GetComponent<Button>().colors;
                colors.normalColor = new Color(0, 255, 238, 255);
                colors.highlightedColor = new Color(0, 255, 238, 255);
                upgradeButton2.GetComponent<Button>().colors = colors;
            }
            else
            {
                var colors = upgradeButton2.GetComponent<Button>().colors;
                colors.normalColor = Color.red;
                colors.highlightedColor = Color.red;
                upgradeButton2.GetComponent<Button>().colors = colors;
            }
            upgradeButton3.GetComponentInChildren<Text>().text = turret.upgradeName3 + "(" + turret.upgradeCost3 + ")";
            if (turret.upgraded3)
            {
                var colors = upgradeButton3.GetComponent<Button>().colors;
                colors.normalColor = new Color(0, 255, 238, 255);
                colors.highlightedColor = new Color(0, 255, 238, 255);
                upgradeButton3.GetComponent<Button>().colors = colors;
            }
            else
            {
                var colors = upgradeButton3.GetComponent<Button>().colors;
                colors.normalColor = Color.red;
                colors.highlightedColor = Color.red;
                upgradeButton3.GetComponent<Button>().colors = colors;
            }
        }
    }

    public void UpgradeTurretX(int x)
    {
        if(turret != null)
        {
            turret.UpgradeTurret(x);
            updateText();
        }
    }
}
