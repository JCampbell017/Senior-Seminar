using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Home : MonoBehaviour
{
    public static double food = 0;
    public static double water = 0;
    public static double scrap = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Food= " + food + " and Scrap= " + scrap);
        // Calls the method to change the amount of resources to simulate passive change. Calls the method after 60 seconds, then repeats every 60 seconds
        InvokeRepeating("Passive_Resource_Change", 60.0f, 60.0f);

        // For testing purposes only, shows the amount of current resources every 5 seconds
        InvokeRepeating("Show", 5.0f, 5.0f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    //Method to control the amount of food, water, and scrap gain/loss. Default is 1 per method call
    void Passive_Resource_Change(){
        food -= 1;
        water -= 1;
        scrap += 1;
    }

    void Show(){
        Debug.Log("Food = " + food + " && Scrap = " + scrap);
    }
}
