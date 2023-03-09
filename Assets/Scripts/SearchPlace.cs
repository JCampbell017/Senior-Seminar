using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchPlace : MonoBehaviour
{
    public GameObject building;
    public GameObject player;
    public GameObject home;
    public GameObject button;
    public GameObject timerObject;
    public Animator animTimer;
    Animator animator;

    public float timer = 0.0f;
    public float searchTime = 2.0f;
    public bool isSearching = false;

    // Start is called before the first frame update
    void Start()
    {
        button.SetActive(false);
        animator = player.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(building != null){
            Vector3 searchTimerPosition = Camera.main.WorldToScreenPoint(player.GetComponent<PlayerController>().building.transform.position);
            button.transform.position = searchTimerPosition;
        }
        
        if(isSearching){

            // Move button off screen
            button.transform.position = new Vector3(500000,0,-500000);
            // Make Timer visible
            timerObject.SetActive(true);
            timerObject.transform.position = player.GetComponent<PlayerController>().building.transform.position;
            // Start Timer animation
            animTimer.SetBool("isSearching", true);
            // Make the player invisible
            player.SetActive(false);
            // Increment timer each frame
            timer += Time.deltaTime;
            
            if(timer > searchTime){
                isSearching = false;
                timer = 0.0f;
                animTimer.SetBool("isSearching", false);
                timerObject.SetActive(false);
                player.SetActive(true);
                player.GetComponent<PlayerController>().isSearching = false;
                // After searching, add resources
                AddResources(player.GetComponent<PlayerController>().collisionTag);
            }
        }
        
    }

    void AddResources(string building){
        float food_gain = Random.Range(0, 10);
        float water_gain = Random.Range(0, 10);
        float scrap_gain = Random.Range(0, 10);
        
        if(building == "Neighbor"){
            Home.food += food_gain;
            Home.water += water_gain;
            Home.scrap += scrap_gain;
        }else if(building == "Store"){
            Home.food += food_gain;
            Home.water += water_gain;
        }else if(building == "Wind"){
            Home.water += Random.Range(5, 10);
        }else if(building == "LakeHouse"){
            // add fish
        }
    }

    public void OnClick(){
        if(!isSearching){
            player.GetComponent<PlayerController>().isSearching = true;
            isSearching = true;
        }
    }
}
