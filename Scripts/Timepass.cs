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
        //when night lower light intensity
        if(day_or_night == 2){
            sun.intensity = .5;
        }
        if(day_or_night == 1){
            sun.intensity = 2;
        }
        //Dawn
        if(counter < 60){
            float angle = Mathf.MoveTowardsAngle(transform.eulerAngles.x, 45f, 10f * Time.deltaTime); 
            transform.eulerAngles = new Vector3(angle, -90, 0);
        }
        //Midday
        if(counter < 120 && counter > 60){
            float angle = Mathf.MoveTowardsAngle(transform.eulerAngles.x, 90f, 10f * Time.deltaTime);
            transform.eulerAngles = new Vector3(angle, -90, 0);
        }
        //Afternoon
        if(counter < 180 && counter > 120){
            float angle = Mathf.MoveTowardsAngle(transform.eulerAngles.x, 135f, 10f * Time.deltaTime);
            transform.eulerAngles = new Vector3(angle, -90, 0);
        }
        //Evening
        if(counter < 240 && counter > 180){
            float angle = Mathf.MoveTowardsAngle(transform.eulerAngles.x, 180f, 10f * Time.deltaTime); 
            transform.eulerAngles = new Vector3(angle, -90, 0);
        }

    }
}
