using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Home : MonoBehaviour
{
<<<<<<< Updated upstream:Senior-Seminar-main/Scripts/Home.cs
    public static double food = 0;
    public static double water = 0;
    public static double scrap = 0;
    
=======
    public static float food = 0f;
    public static float water = 0f;
    public static float scrap = 0f;
    public static float wood = 0f; 
    public GameObject house;

    private static float max_food = 100f;
    private static float max_water = 100f;
    private static float max_scrap = 100f;
    private static float max_wood = 100f;

    public static int house_tier = 0;

    public PlayerInv pinv;
    public GameObject btn;
    public GameObject btnTxt;
   
>>>>>>> Stashed changes:Assets/Scripts/Enviroment and Buildings/Home.cs
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

    void Update(){
        if(food > max_food){
            food = max_food;
        }
        if(water > max_water){
            water = max_water;
        }
        if(scrap > max_scrap){
            scrap = max_scrap;
        }
        if(wood > max_wood){
            wood = max_wood;
        }
    }


    //Method to control the amount of food, water, and scrap gain/loss. Default is 1 per method call
<<<<<<< Updated upstream:Senior-Seminar-main/Scripts/Home.cs
    void Passive_Resource_Change(){
        food -= 1;
        water -= 1;
        scrap += 1;
    }

    void Show(){
        Debug.Log("Food = " + food + " && Scrap = " + scrap);
=======
    void Passive_Resource_Change(int tier){
        if(food > 0)
            food -= 1f;
        if(water >0)
            water -= 1f;
        if(wood > 0)
            wood -=1f;
        scrap += 1f + tier;
        water += .5f + tier;
    }

    public static void change_resource_limit(string type, float amount){
        if(type == "food"){
            max_food = amount;
        }
        else if(type == "water"){
            max_water = amount;
        }
        else if(type == "scrap"){
            max_scrap = amount;
        }
        else if(type == "wood"){
            max_wood = amount;
        }
    }

    void OnCollisionEnter2D(Collision2D col){
        //pinv.deposit_resources();
        Vector3 newPos = new Vector3(850, 350, 0);
        btn.transform.position = newPos;
        btnTxt.transform.position = newPos;
    }

    void OnCollisionExit2D(Collision2D col){
        Vector3 newPos = new Vector3(-500, -500, 0);
        btn.transform.position = newPos;
        btnTxt.transform.position = newPos;
>>>>>>> Stashed changes:Assets/Scripts/Enviroment and Buildings/Home.cs
    }
}
