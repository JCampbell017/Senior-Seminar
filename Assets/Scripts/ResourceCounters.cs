using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResourceCounters : MonoBehaviour
{

    public GameObject foodCounter;
    public GameObject waterCounter;
    public GameObject scrapCounter;
    public GameObject woodCounter;
    TextMeshProUGUI food;
    TextMeshProUGUI water;
    TextMeshProUGUI scrap;
    TextMeshProUGUI wood;

    public GameObject cfoodCounter;
    public GameObject cwaterCounter;
    public GameObject cscrapCounter;
    public GameObject cwoodCounter;
    TextMeshProUGUI carried_food;
    TextMeshProUGUI carried_water;
    TextMeshProUGUI carried_scrap;
    TextMeshProUGUI carried_wood;

    // Start is called before the first frame update
    void Start()
    {
        food = foodCounter.GetComponent<TextMeshProUGUI> ();
        water = waterCounter.GetComponent<TextMeshProUGUI> ();
        scrap = scrapCounter.GetComponent<TextMeshProUGUI> ();
        wood = woodCounter.GetComponent<TextMeshProUGUI> ();
        carried_food = cfoodCounter.GetComponent<TextMeshProUGUI>();
        carried_water = cwaterCounter.GetComponent<TextMeshProUGUI>();
        carried_scrap = cscrapCounter.GetComponent<TextMeshProUGUI>();
        carried_wood =  cwoodCounter.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        food.text = "Stored Food: " + Home.food;
        water.text = "Stored Water: " + Home.water;
        scrap.text = "Stored Scrap: " + Home.scrap;
        wood.text = "Stored Wood: " + Home.wood;
        carried_food.text = "Carried Food: " + PlayerInv.carrying_food;
        carried_water.text = "Carried Water: " + PlayerInv.carrying_water;
        carried_scrap.text = "Carried Scrap: " + PlayerInv.carrying_scrap;
        carried_wood.text = "Carried Wood: " + PlayerInv.carrying_wood;
    }
}
