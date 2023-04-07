using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timepass : MonoBehaviour
{
    public Light sun;
    
    // Start is called before the first frame update
    void Start()
    {
        sun = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        // DateTime dawn = dawn.Second(60);
        // DateTime midday = midday.Second(120);
        // DateTime afternoon = afternoon.Second(180);
        // DateTime evening = evening.Second();

        //when night lower light intensity
        if(World.day_or_night == 2){
            sun.intensity = .5f;
        }
        if(World.day_or_night == 1){
            sun.intensity = 2f;
        }
        //Dawn
        if(World.counter < dawn){
            float angle = Mathf.MoveTowardsAngle(transform.eulerAngles.x, 45f, 10f * Time.deltaTime); 
            transform.eulerAngles = new Vector3(angle, -90, 0);
        }
        //Midday
        if(World.counter < midday && World.counter > dawn){
            float angle = Mathf.MoveTowardsAngle(transform.eulerAngles.x, 90f, 10f * Time.deltaTime);
            transform.eulerAngles = new Vector3(angle, -90, 0);
        }
        //Afternoon
        if(World.counter < afternoon && World.counter > midday){
            float angle = Mathf.MoveTowardsAngle(transform.eulerAngles.x, 135f, 10f * Time.deltaTime);
            transform.eulerAngles = new Vector3(angle, -90, 0);
        }
        //Evening
        if(World.counter < evening && World.counter > afternoon){
            float angle = Mathf.MoveTowardsAngle(transform.eulerAngles.x, 180f, 10f * Time.deltaTime); 
            transform.eulerAngles = new Vector3(angle, -90, 0);
        }

    }
}
