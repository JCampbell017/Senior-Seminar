using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Enemy", order = 1)]

public class EnemyData : ScriptableObject
{
    public int hp;
    public int damage;
    public float speed;
    public float[] position;
    // public int id;

    public EnemyData(GameObject enemy){
        // this.id = id;
        position = new float[3];
        position[0] = enemy.transform.position.x;
        position[1] = enemy.transform.position.y;
        position[2] = enemy.transform.position.z;
    }

    
}