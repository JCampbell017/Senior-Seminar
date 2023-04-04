using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farm : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Gains food every 5 minutes
        InvokeRepeating("Food_Gain", 300.0f, 300.0f);
    }

    void Food_Gain()
    {
        if(World.season == "Summer"){
            Home.food += 10;
        }

        if(World.season == "Spring"){
            Home.food += 10;
        }

        if(World.season == "Fall"){
            Home.food += 7;
        }

        if(World.season == "Winter"){
            Home.food += 5;
        }
    }

}
