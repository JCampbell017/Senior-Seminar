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

    // Start is called before the first frame update
    void Start()
    {
        food = foodCounter.GetComponent<TextMeshProUGUI> ();
        water = waterCounter.GetComponent<TextMeshProUGUI> ();
        scrap = scrapCounter.GetComponent<TextMeshProUGUI> ();
        wood = woodCounter.GetComponent<TextMeshProUGUI> ();
    }

    // Update is called once per frame
    void Update()
    {
        food.text = "Food: " + Home.food;
        water.text = "Water: " + Home.water;
        scrap.text = "Scrap: " + Home.scrap;
        wood.text = "Wood: " + Home.wood;
    }
}
