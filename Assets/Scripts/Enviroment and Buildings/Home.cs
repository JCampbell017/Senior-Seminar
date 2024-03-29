using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Home : MonoBehaviour
{
    public static float food = 0f;
    public static float water = 0f;
    public static float scrap = 0f;
    public static float wood = 0f; 
    public GameObject house;

    public static float max_food = 100f;
    public static float max_water = 100f;
    public static float max_scrap = 100f;
    public static float max_wood = 100f;

    public static int tier = 0;
    public GameObject button;
   
    // Start is called before the first frame update
    void Start()
    {
        // Calls the method to change the amount of resources to simulate passive change. Calls the method after 60 seconds, then repeats every 60 seconds
        InvokeRepeating("Passive_Resource_Change", 300.0f, 300.0f);

        // For testing purposes only, shows the amount of current resources every 5 seconds
        // InvokeRepeating("Show", 5.0f, 5.0f);
    }

    //Method to control the amount of food, water, and scrap gain/loss. Default is 1 per method call
    void Passive_Resource_Change(){
        if(food > 0)
            food -= 1f;
        if(water >0)
            water -= 1f;
        scrap += 1f;
        if(wood > 0)
            wood -=1f;
    }

    //method to deposit resources here

    private void OnCollisionEnter2D(Collision2D coll){
        PlayerInv.deposit_resources();
        button.transform.position = new Vector3(735f, 400f, 0f);
    }

    private void OnCollisionExit2D(Collision2D coll){
        button.transform.position = new Vector3(-600f, -600f, -600f);
    }
}
