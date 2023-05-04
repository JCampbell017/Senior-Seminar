using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchPlace : MonoBehaviour
{
    public GameObject building;
    public GameObject player;
    public GameObject home;
    public GameObject searchButton;
    public GameObject timerObject;
    public Animator animTimer;
    Animator animator;

    public float timer = 0.0f;
    public float searchTime = 2.0f;
    public bool isSearching = false;

    // Start is called before the first frame update
    void Start()
    {
        searchButton.SetActive(false);
        animator = player.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(building != null){
            Vector3 searchTimerPosition = Camera.main.WorldToScreenPoint(player.GetComponent<PlayerController>().building.transform.position);
            searchButton.transform.position = searchTimerPosition;
        }
        
        if(isSearching){

            // Move searchButton off screen
            searchButton.transform.position = new Vector3(500000,0,-500000);
            startSearching();
        }
    
        
    }

    private void startSearching(){
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

    void AddResources(string building){
        float food_gain = Random.Range(0, 10);
        float water_gain = Random.Range(0, 10);
        float scrap_gain = Random.Range(0, 10);
        
        if(building == "Neighbor"){
            PlayerInv.update_player_inv("food", food_gain);
            PlayerInv.update_player_inv("water", water_gain);
            PlayerInv.update_player_inv("scrap", scrap_gain);

        }else if(building == "Store"){
            PlayerInv.update_player_inv("food", food_gain);
            PlayerInv.update_player_inv("water", water_gain);
        }else if(building == "Wind"){
            PlayerInv.update_player_inv("water", Random.Range(5, 10));
        }else if(building == "LakeHouse"){
           PlayerInv.update_player_inv("food", Random.Range(1, 3));
        }
    }

    public void OnSearchClick(){
        if(!isSearching){
            player.GetComponent<PlayerController>().isSearching = true;
            isSearching = true;
        }
    }

}