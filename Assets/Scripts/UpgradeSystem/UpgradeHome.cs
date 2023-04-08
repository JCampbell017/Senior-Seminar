using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeHome : MonoBehaviour
{
    public GameObject player;
    public TMP_Text upgrade_title;
    public TMP_Text requirements;

    public bool in_upgrade_menu = false;
    void start(){

    }
 
    void update(){
        if(in_upgrade_menu){
            player.SetActive(false);
        }
    }
    public void upgrade_Home(int tier){
        //upgrade the maximum amount of supplies the home can contain
        //upgrade the scrap and water return rates (handled in Home)
        //take away resources from the player

        if(tier == 1){
            Home.scrap -= 75f;
            Home.wood -= 75f;
            
            Home.house_tier = 1;

            Home.change_resource_limit("food", 150f);
            Home.change_resource_limit("water", 150f);
            Home.change_resource_limit("scrap", 150f);
            Home.change_resource_limit("wood", 150f);

        
            //change model/looks?
        }
    }

    void TaskOnClick(){
    }
}
