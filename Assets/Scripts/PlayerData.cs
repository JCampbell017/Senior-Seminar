using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public float food;
    public float water;
    public float scrap;
    public float wood;
    public int health;
    public float[] position;

    public PlayerData(PlayerController player){
        food = Home.food;
        water = Home.water;
        scrap = Home.scrap;
        wood = Home.wood;
        health = player.GetComponent<Health>().GetHealth();
        
        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;
    }
    
}
