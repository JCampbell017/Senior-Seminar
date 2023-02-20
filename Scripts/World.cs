using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour
{

    public static string season = "";

    // Start is called before the first frame update
    void Start()
    {
        //Picks a season to start in
        int season_picker = Random.Range(0, 4);

        if(season_picker == 0){
            season = "Summer";
        }

        if(season_picker == 1){
            season = "Fall";
        }

        if(season_picker == 2){
            season = "Winter";
        }

        if(season_picker == 3){
            season = "Spring";
        }
    }

    // Update is called once per frame
    void Update()
    {
        //After x amount of time, switch seasons
    }
}
