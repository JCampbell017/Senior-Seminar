using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchToBackpack : MonoBehaviour
{
    public GameObject ResourceCounters;
    public GameObject UpgradeBackpackPanel;
    public GameObject UpgradeGunPanel;
    public GameObject UpgradeFarmPanel;
    public GameObject UpgradeTurretPanel;

    public void onButtonClick(){
        ResourceCounters.SetActive(false);
        UpgradeBackpackPanel.SetActive(true);
        UpgradeGunPanel.SetActive(false);
        UpgradeFarmPanel.SetActive(false);
        UpgradeTurretPanel.SetActive(false);
    }
}
