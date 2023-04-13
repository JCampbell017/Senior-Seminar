using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInv : MonoBehaviour
{
    private static float max_food = 50;
    private static float max_water = 50;
    private static float max_scrap = 50;
    private static float max_wood = 25;

    public static float carrying_food;
    public static float carrying_water;
    public static float carrying_scrap;
    public static float carrying_wood; 

    // Start is called before the first frame update
    void Start()
    {
        carrying_food = 0;
        carrying_water = 0;
        carrying_scrap = 0;
        carrying_wood = 0;
    }

    public static void update_player_inv(string material, float count){
        if(material.Equals("food")){
            carrying_food += count;
            if(carrying_food > max_food){
                float dropped = carrying_food - max_food;
                //output that you dropped food
                carrying_food = max_food;
            }
        }
        else if(material.Equals("water")){
            carrying_water += count;
            if(carrying_water > max_water){
                float dropped = carrying_water - max_water;
                //output that you dropped food
                carrying_water = max_water;
            }
        }
        else if(material.Equals("scrap")){
            carrying_scrap += count;
            if(carrying_scrap > max_scrap){
                float dropped = carrying_scrap - max_scrap;
                //output that you dropped scrap
                carrying_scrap = max_scrap;
            }
        }
        else if(material.Equals("wood")){
            carrying_wood += count;
            if(carrying_wood > max_wood){
                float dropped = carrying_wood - max_wood;
                //output that you dropped scrap
                carrying_wood = max_wood;
            }
        }
    }

    public static void deposit_resources(){
        Home.food += carrying_food;
        carrying_food = 0;
        Home.water += carrying_water;
        carrying_water = 0;
        Home.scrap += carrying_scrap;
        carrying_scrap = 0;
        Home.wood += carrying_wood;
        carrying_wood = 0;
    }

    public void upgrade_backpack(string resource, float limit){
        if(resource.Equals("food")){
            max_food = limit;
        }
        else if(resource.Equals("water")){
            max_water = limit;
        }
        else if(resource.Equals("scrap")){
            max_scrap = limit;
        }
        else if(resource.Equals("wood")){
            max_wood = limit;
        }
        else if(resource.Equals("all")){
            max_food = limit;
            max_water = limit;
            max_scrap = limit;
            max_wood = limit;
        }
    }
}
