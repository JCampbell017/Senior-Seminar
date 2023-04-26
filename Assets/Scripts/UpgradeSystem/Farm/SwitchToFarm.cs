using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchToFarm : MonoBehaviour
{
    public GameObject ResourceCounters;
    public GameObject UpgradeBackpackPanel;
    public GameObject UpgradeGunPanel;
    public GameObject UpgradeFarmPanel;
    public GameObject UpgradeTurretPanel;

    public void onButtonClick(){
        ResourceCounters.SetActive(false);
        UpgradeBackpackPanel.SetActive(false);
        UpgradeGunPanel.SetActive(false);
        UpgradeFarmPanel.SetActive(true);
        UpgradeTurretPanel.SetActive(false);
    }
}
