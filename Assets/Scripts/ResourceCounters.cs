using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResourceCounters : MonoBehaviour
{
    // Player inventory
    public GameObject playerFoodCounter;
    public GameObject playerWaterCounter;
    public GameObject playerScrapCounter;
    public GameObject playerWoodCounter;
    TextMeshProUGUI playerFood;
    TextMeshProUGUI playerWater;
    TextMeshProUGUI playerScrap;
    TextMeshProUGUI playerWood;

    // Start is called before the first frame update
    void Start()
    {
        playerFood = playerFoodCounter.GetComponent<TextMeshProUGUI> ();
        playerWater = playerWaterCounter.GetComponent<TextMeshProUGUI> ();
        playerScrap = playerScrapCounter.GetComponent<TextMeshProUGUI> ();
        playerWood = playerWoodCounter.GetComponent<TextMeshProUGUI> ();
    }

    // Update is called once per frame
    void Update()
    {
        playerFood.text = "Food: " + PlayerInv.carrying_food;
        playerWater.text = "Water: " + PlayerInv.carrying_water;
        playerScrap.text = "Scrap: " + PlayerInv.carrying_scrap;
        playerWood.text = "Wood: " + PlayerInv.carrying_wood;
    }
}
