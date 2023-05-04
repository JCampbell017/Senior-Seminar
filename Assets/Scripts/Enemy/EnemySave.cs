using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemySave {
     public float[] position;
    public int health;
    public GameObject enemy;
    // public int id;

    public EnemySave(GameObject enemy){
        // this.id = id;
        this.enemy = enemy;
        health = enemy.GetComponent<Health>().GetHealth();
        position = new float[3];
        position[0] = enemy.transform.position.x;
        position[1] = enemy.transform.position.y;
        position[2] = enemy.transform.position.z;
    }
}
