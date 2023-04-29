using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.UI;

public class UpgradeItem : MonoBehaviour
{
    // Gui components
    public Button itemUpgradeButton;
    public GameObject itemUpgradeCanvas;
    // Text
    public GameObject requiredFoodCounter;
    public GameObject requiredWaterCounter;
    public GameObject requiredScrapCounter;
    public GameObject requiredWoodCounter;
    TextMeshProUGUI requiredFood;
    TextMeshProUGUI requiredWater;
    TextMeshProUGUI requiredScrap;
    TextMeshProUGUI requiredWood;

    // Button color
    public Color goodColor = new Color(0,1,0,1);
    public Color badColor = new Color(1,0,0,1);
    private bool enabled = false;

    // values
    float upgradeAmount = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        if(requiredFoodCounter != null)
            requiredFood = requiredFoodCounter.GetComponent<TextMeshProUGUI>();
        if(requiredWaterCounter != null)
            requiredWater = requiredWaterCounter.GetComponent<TextMeshProUGUI>();
        if(requiredFoodCounter != null)
            requiredScrap = requiredScrapCounter.GetComponent<TextMeshProUGUI>();
        if(requiredWoodCounter != null)
            requiredWood = requiredWoodCounter.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if(itemUpgradeCanvas.tag == "Backpack"){
            UpgradeBackpack();
        }else if(itemUpgradeCanvas.tag == "Turret"){
            UpgradeTurret();
        }
        
    }

    void UpgradeBackpack(){
        upgradeAmount = 0.75f;
        requiredWood.text = "Wood: " + PlayerInv.max_limit * upgradeAmount;
        requiredScrap.text = "Scrap: " + PlayerInv.max_limit * upgradeAmount;

        if(Home.wood >= float.Parse(requiredWood.text.Substring(7)) && Home.scrap >= float.Parse(requiredScrap.text.Substring(7))){
            enabled = true;

            ColorBlock cb = itemUpgradeButton.colors;
		    cb.normalColor = goodColor;
		    itemUpgradeButton.colors = cb;
        }
        else{
            ColorBlock cb = itemUpgradeButton.colors;
		    cb.normalColor = badColor;
		    itemUpgradeButton.colors = cb;
        }

    }

    void UpgradeTurret(){
        upgradeAmount = 0.5f;
        requiredWood.text = "Wood: " + PlayerInv.max_limit * upgradeAmount;
        requiredScrap.text = "Scrap: " + PlayerInv.max_limit * upgradeAmount;

        if(Home.wood >= float.Parse(requiredWood.text.Substring(7)) && Home.scrap >= float.Parse(requiredScrap.text.Substring(7))){
            enabled = true;

            ColorBlock cb = itemUpgradeButton.colors;
		    cb.normalColor = goodColor;
		    itemUpgradeButton.colors = cb;
        }
        else{
            ColorBlock cb = itemUpgradeButton.colors;
		    cb.normalColor = badColor;
		    itemUpgradeButton.colors = cb;
        }
    }


    public void onButtonClick(){
        if(enabled && itemUpgradeCanvas.tag == "Backpack"){
            PlayerInv.upgrade_backpack("all", PlayerInv.max_limit*upgradeAmount);
        }
        if(enabled && itemUpgradeCanvas.tag == "Turret"){
            Bullets.damage += 1;
        }
    }

}
