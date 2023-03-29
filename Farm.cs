using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farm : MonoBehaviour{
    public int farm_tier = 1;
    private int farm_event;

    // Start is called before the first frame update
    void Start(){
        // Gains food every 5 minutes
        InvokeRepeating("Food_Gain", 300.0f, 300.0f);
    }

    void Food_Gain(){
        // resource generation
        if(farm_tier == 3){
            Home.food += (20 - (World.season_farm_penalty/2)) * event_check();
        }
        else if(farm_tier == 2){
            Home.food += (15 - (World.season_farm_penalty/2)) * event_check();
        }
        else{
            Home.food += (10 - (World.season_farm_penalty/2)) * event_check();
        }
    }

    double event_check(){
        // current ideas: bug infestation, drought(world event), flood(world event)
        
        // check for world event

        //75% chance for nothing to happen
        //25% chance for test event to happen
        farm_event = Random.Range(1, 100);
        double modifier = 1;

        if(farm_event < 75){
            //do nothing
            modifier = 1;
            event_text.text = "All is good";
        }
        //Animals eat harvest - loose 3/4 crop yield
        else if(farm_event > 75 && farm_event < 80){
            modifier = .25;
            event_text.text = "Animals have gotten into your field and ate most of your crops";
        }
        //Drought - loose 1/2 crop yield
        else if(farm_event > 80 && farm_event < 85){
            modifier = .5;
            event_text.text = "Your farm couldn't get enough water, half your crops have withered";
        }
        //Rotten - loose 1/4 crop yield
        else if(farm_event > 85 && farm_event < 90){
            modifier = .75;
            event_text.text = "A quarter of your crops have rotted";
        }
        // //another event?
        // else if(farm_event > 90 && farm_event < 95){

        // }
        // //another event?
        // else if(farm_event > 95 && farm_event < 100){

        // }
        return modifier;
    }
}
