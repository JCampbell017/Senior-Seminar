using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeFunctions : MonoBehaviour {

    public bool is_broke = false;
    public GameObject tree;
    Collision2D collision;
    public GameObject topBoundary;
    public GameObject bottomBoundary;
    public int numTrees = 7;
    public int maxNumTrees = 7;



    // Start is called before the first frame update
    void Start(){
        Vector3 treeTopPosition = topBoundary.transform.position;
        Vector3 treeBotPosition = bottomBoundary.transform.position;
        Debug.Log("tree new position (" + treeTopPosition);
        Debug.Log("tree new position (" + treeBotPosition);
    }

    // Update is called once per frame
    void Update(){
        if(numTrees < maxNumTrees){
            generate_position();
        }
    }

    public void SetTree(GameObject tree){
        this.tree = tree;
    }

    public void RemoveTree(){
        numTrees -=1;
    }

    public void setIsBroke(bool b){
        is_broke = b;
    }

    void generate_position(){
      
        
        Vector3 treeTopPosition = topBoundary.transform.position;
        Vector3 treeBotPosition = bottomBoundary.transform.position;
        
        // temp hard coded spawn point
        float x_pos = Random.Range(-1.5f, 0.5f);
        float y_pos = Random.Range(-1.5f, 0.5f);
        
        tree = Instantiate(tree, new Vector3(x_pos, y_pos, 0), tree.transform.rotation) as GameObject;
        numTrees += 1;
        Debug.Log("tree new position (" + x_pos + ", " + y_pos + ")");
    
        // tree.transform.position = new Vector3(x_pos, y_pos, 0);
        is_broke = false;
    
    }

    private void OnCollisionEnter2D(Collision2D collision){
        this.collision = collision;
    
    }
}
