using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchToGun : MonoBehaviour
{
    public GameObject ResourceCounters;
    public GameObject UpgradeBackpackPanel;
    public GameObject UpgradeGunPanel;
    public GameObject UpgradeGunBtn;
    public GameObject UpgradeFarmPanel;
    public GameObject UpgradeTurretPanel;

    public void onButtonClick(){
        ResourceCounters.SetActive(false);
        UpgradeBackpackPanel.SetActive(false);
        UpgradeGunPanel.SetActive(true);
        UpgradeGunBtn.SetActive(true);
        UpgradeFarmPanel.SetActive(false);
        UpgradeTurretPanel.SetActive(false);
    }
}
