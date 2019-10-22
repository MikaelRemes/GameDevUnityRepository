using UnityEngine;
using UnityEngine.UI;

public class UpgradePanelScript : MonoBehaviour
{

    public Camera cameraView;
    public string turretTag = "Turret";

    public Text turretNameText;
    public Text turretPowerText;
    public Text turretFireRateText;
    public Text turretRangeText;

    public GameObject upgradeButton1;
    public GameObject upgradeButton2;
    public GameObject upgradeButton3;

    // Start is called before the first frame update
    void Start()
    {

    }

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

                }
            }
        }
    }
}
