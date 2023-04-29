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

    // Home inventory
    public GameObject homeFoodCounter;
    public GameObject homeWaterCounter;
    public GameObject homeScrapCounter;
    public GameObject homeWoodCounter;
    TextMeshProUGUI homeFood;
    TextMeshProUGUI homeWater;
    TextMeshProUGUI homeScrap;
    TextMeshProUGUI homeWood;

    // Start is called before the first frame update
    void Start()
    {
        playerFood = playerFoodCounter.GetComponent<TextMeshProUGUI> ();
        playerWater = playerWaterCounter.GetComponent<TextMeshProUGUI> ();
        playerScrap = playerScrapCounter.GetComponent<TextMeshProUGUI> ();
        playerWood = playerWoodCounter.GetComponent<TextMeshProUGUI> ();

        homeFood = homeFoodCounter.GetComponent<TextMeshProUGUI> ();
        homeWater = homeWaterCounter.GetComponent<TextMeshProUGUI> ();
        homeScrap = homeScrapCounter.GetComponent<TextMeshProUGUI> ();
        homeWood = homeWoodCounter.GetComponent<TextMeshProUGUI> ();
    }

    // Update is called once per frame
    void Update()
    {
        playerFood.text = "Food: " + PlayerInv.carrying_food;
        playerWater.text = "Water: " + PlayerInv.carrying_water;
        playerScrap.text = "Scrap: " + PlayerInv.carrying_scrap;
        playerWood.text = "Wood: " + PlayerInv.carrying_wood;

        homeFood.text = "Food: " + Home.food;
        homeWater.text = "Water: " + Home.water;
        homeScrap.text = "Scrap: " + Home.scrap;
        homeWood.text = "Wood: " + Home.wood;


    }
}
