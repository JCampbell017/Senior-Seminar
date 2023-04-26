using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    public PlayerController player;
    public GameObject loadCanvas;
    public GameObject enemy;

    // attach to buttons to save 
    public void SavePlayer(){
        Save.SavePlayer(player);
       
    }

    // attach to button to load game on start up
    public void LoadPlayer(){
        loadCanvas.SetActive(false);
        PlayerData data = Save.LoadPlayer();
        Home.food = data.food;
        Home.water = data.water;
        Home.scrap = data.scrap;
        Home.wood = data.wood;
        player.GetComponent<Health>().health = data.health; 
        
        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];

        player.transform.position = position;
        LoadEnemy(Save.LoadEnemies());
        

    }

    void LoadEnemy(EnemySave[] enemies){

        for(int i = 0; i < enemies.Length; i++){
            
            Vector3 position;
            position.x = enemies[i].position[0];
            position.y = enemies[i].position[1];
            position.z = enemies[i].position[2];
            Instantiate(enemy, position, enemy.transform.rotation);
        }
    }

    public void LoadNewPlayer(){
        loadCanvas.SetActive(false);
        Home.food = 0;
        Home.water = 0;
        Home.scrap = 0;
        Home.wood = 0;
        player.GetComponent<Health>().health = 100; 
        
        Vector3 position;
        position.x = 0.5f;
        position.y = -0.8f;
        position.z = 0;

        player.transform.position = position;
        

    }
    


    // Update is called once per frame
    void Update()
    {
        
    }
}
