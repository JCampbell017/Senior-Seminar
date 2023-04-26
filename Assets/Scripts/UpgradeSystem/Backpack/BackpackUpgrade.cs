using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class BackpackUpgrade : MonoBehaviour
{
    public Button button;
    public Color goodColor = new Color(0,1,0,1);
    public Color badColor = new Color(1,0,0,1);
    public GameObject scrapCounter;
    public GameObject woodCounter;
    TextMeshProUGUI RequiredWood;
    TextMeshProUGUI RequiredScrap;
    private bool enabled = false;
    
    void Start(){
        RequiredScrap = scrapCounter.GetComponent<TextMeshProUGUI> ();
        RequiredWood = woodCounter.GetComponent<TextMeshProUGUI> ();
    }
    void Update(){
        RequiredWood.text = "Wood: " + PlayerInv.max_limit * .75f;
        RequiredScrap.text = "Scrap: " + PlayerInv.max_limit * .75f;
        if(Home.wood >= float.Parse(RequiredWood.text.Substring(7)) && Home.scrap >= float.Parse(RequiredScrap.text.Substring(7))){
            enabled = true;

            ColorBlock cb = button.colors;
		    cb.normalColor = goodColor;
		    button.colors = cb;
        }
        else{
            ColorBlock cb = button.colors;
		    cb.normalColor = badColor;
		    button.colors = cb;
        }
    }

    public void onButtonClick(){
        if(enabled){
            PlayerInv.upgrade_backpack("all", PlayerInv.max_limit*1.5f);
        }
    }
}
