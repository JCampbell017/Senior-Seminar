using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeFunctions : MonoBehaviour {

    public bool is_broke = false;

    // Start is called before the first frame update
    void Start(){
        Component Tree = GetComponent<tree>();
        generate_position();
    }

    // Update is called once per frame
    void Update(){
        if(is_broke == true && World.tree_count < World.max_tree_count){
            generate_position();
        }
    }

    void generate_position(){
        //generate a random x and y position
        bool finding_pos = true;
        float x_pos = UnityEngine.Random.Range(-2, 2);
        float y_pos = UnityEngine.Random.Range(-2, 2);
        //if tree colliding with another collision box generate new x and y positions
        while(finding_pos){
            if(collision.collider == BoxCollider2D){
                x_pos = UnityEngine.Random.Range(-2, 2);
                y_pos = UnityEngine.Random.Range(-2, 2);
            }
            //if no collision detected, end
            else{
                finding_pos = false;
            }
        }
        
        //create a new vector to store position
        Vector3 position = new Vector3(x_pos, y_pos, 0);
        //assign tree's position and make tree visible
        Tree.transform.position = position;
        Tree.SetActive(true);
    }
}
