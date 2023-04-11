using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchPlace : MonoBehaviour
{
    public GameObject building;
    public GameObject player;
    public GameObject home;
    public GameObject searchButton;
    public GameObject fishButton;
    public GameObject timerObject;
    public GameObject lakeHouse;
    public Animator animTimer;
    Animator animator;

    public float timer = 0.0f;
    public float searchTime = 2.0f;
    public float fishTime = 8.0f;
    public bool isSearching = false;
    public bool isFishing = false;

    // public PlayerInv playerInventory;

    // Start is called before the first frame update
    void Start()
    {
        searchButton.SetActive(false);
        
        fishButton.SetActive(false);
        animator = player.GetComponent<Animator>();
        // playerInventory = player.GetComponent<PlayerInv>();
    }

    // Update is called once per frame
    void Update()
    {
        if(building != null){
            Vector3 searchTimerPosition = Camera.main.WorldToScreenPoint(player.GetComponent<PlayerController>().building.transform.position);
            searchButton.transform.position = searchTimerPosition;
            fishButton.transform.position = Camera.main.WorldToScreenPoint(player.GetComponent<PlayerController>().building.transform.position);
        }
        
        if(isSearching){

            // Move searchButton off screen
            searchButton.transform.position = new Vector3(500000,0,-500000);
            startSearching();
        }
        if(isFishing){
            fishButton.transform.position = new Vector3(500000,0,-500000);
            player.SetActive(false);
            timer += Time.deltaTime;
            if(timer > searchTime){
                isFishing = false;
                timer = 0.0f;
                player.SetActive(true);
                player.GetComponent<PlayerController>().isFishing = false;
                // After searching, add resources
                AddResources("LakeHouse");
            }
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
                // isFishing = false;
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
            // add fish
        }
    }

    public void OnSearchClick(){
        if(!isSearching){
            player.GetComponent<PlayerController>().isSearching = true;
            isSearching = true;
        }
    }

    public void OnFishClick(){
        if(!isFishing){
            isFishing = true;
            player.GetComponent<PlayerController>().isFishing = true;
        }
    }
}
