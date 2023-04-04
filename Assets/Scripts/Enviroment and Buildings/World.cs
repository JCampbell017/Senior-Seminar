using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour{
    //600 seconds in a day, aka 10 minutes
    public const float seconds_per_day = 600;
    public static int current_day;
    //1 for day, 2 for night
    public static int day_or_night;
    public static string season;
    public static int season_farm_penalty;

    public DateTime current_time;
    public DateTime last_day_time;
    public static DateTime counter;

    public static int tree_count = 5;
    public static int max_tree_count = 10;

    [SerializeField] [Range(0, seconds_per_day)] private float _realtimeDayLength = 60;

    // Start is called before the first frame update
    void Start(){
        current_day = 1;
        day_or_night = 1;
        //Picks a random season to start with
        season = get_random_season(UnityEngine.Random.Range(0, 4));
        current_time = DateTime.Now + TimeSpan.FromHours(0);
        last_day_time = current_time;
    }

    //uses Random.Range to get numbers 1, 2, 3, or 4 and picks the season based off of that
    private string get_random_season(int season_picker){
        if(season_picker == 0){
            season = "Summer";
            season_farm_penalty = 0;
        }

        else if(season_picker == 1){
            season = "Fall";
            season_farm_penalty = 3;
        }

        else if(season_picker == 2){
            season = "Winter";
            season_farm_penalty = 5;
        }

        else{
            season = "Spring";
            season_farm_penalty = 0;
        }
        return season;
    }

    //currently handles day/night cycle
    private void update(){
        //calculate the time that needs to be added to the current day
        float timestep = seconds_per_day / _realtimeDayLength * Time.deltaTime;
        //add to the current day
        current_time = current_time.AddSeconds(timestep);

        counter = current_time - last_day_time;
        //first 5 minutes are considered day time, last 5 minutes are considered night
        if((counter).Second >= seconds_per_day/2){
            day_or_night = 2;
        }
        else{
            day_or_night = 1;
        }
        if((counter).Second >= seconds_per_day){
            last_day_time = current_time;
            current_day++;
        }
    }
}
