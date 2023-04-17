using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree
{   // Attributes
    public int health;
    public Vector3 position;
    public GameObject tree;
    // Constructor
    public Tree(Vector3 position, GameObject tree){
        health = 100;
        this.position = position;
    }
    
}