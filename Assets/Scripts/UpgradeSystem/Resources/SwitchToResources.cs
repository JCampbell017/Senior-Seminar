using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchToResources : MonoBehaviour
{
    public GameObject ResourceCounters;
    public GameObject UpgradeBackpackPanel;
    public GameObject UpgradeGunPanel;
    public GameObject UpgradeFarmPanel;
    public GameObject UpgradeTurretPanel;

    public void onButtonClick(){
        ResourceCounters.SetActive(true);
        UpgradeBackpackPanel.SetActive(false);
        UpgradeGunPanel.SetActive(false);
        UpgradeFarmPanel.SetActive(false);
        UpgradeTurretPanel.SetActive(false);
    }
}
