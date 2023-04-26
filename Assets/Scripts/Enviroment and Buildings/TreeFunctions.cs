
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
    public int maxNumTrees = 8;
    GameObject[] neighbors;
    GameObject[] stores;
    GameObject[] trees;
    GameObject[] map;
    public GameObject player;
    public GameObject house;
    public GameObject garden;
    public GameObject windmill;
    public GameObject lakehouse;

    GameObject[] nonSpawnZones;

    // 1. Store the output of GameObject.FindGameObjectsWithTag("your tag") in an array
    // 2. In a while loop, pick a random point on the map
    // 3. Check if any of the objects in the array are within a certain distance of your point
    // 4. If not, place a tree and break the loop. Otherwise keep going


    // Start is called before the first frame update
    void Start(){
        Vector3 treeTopPosition = topBoundary.transform.position;
        Vector3 treeBotPosition = bottomBoundary.transform.position;
        Debug.Log("tree new position (" + treeTopPosition);
        Debug.Log("tree new position (" + treeBotPosition);

        neighbors = GameObject.FindGameObjectsWithTag("Neighbor");
        stores = GameObject.FindGameObjectsWithTag("Store");
        trees = GameObject.FindGameObjectsWithTag("Tree");
        map = GameObject.FindGameObjectsWithTag("Environment");
        GenerateNonSpawnZone();

    }

    void GenerateNonSpawnZone(){
        int len = neighbors.Length + stores.Length + trees.Length + map.Length + 5;
        nonSpawnZones = new GameObject[len];
        int j = 0;
    
        for(int i = 0; i < neighbors.Length; i++){
           nonSpawnZones[j] = neighbors[i];
           j++;
        }
        for(int i = 0; i < stores.Length; i++){
           nonSpawnZones[j] = stores[i];
           j++;
        }
        for(int i = 0; i < trees.Length; i++){
           nonSpawnZones[j] = trees[i];
           j++;
        }
        for(int i = 0; i < map.Length; i++){
           nonSpawnZones[j] = neighbors[i];
           j++;
        }
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
        Vector3 newPos = new Vector3(0,0,0);
        bool positionFound =  false;
        float x_pos = 0;
        float y_pos = 0;

        if(!positionFound){
            x_pos = Random.Range(-10.85f, 5.63f);
            y_pos = Random.Range(-3.36f, 2.46f);
            newPos = new Vector3(x_pos, y_pos, 0);

            for(int i = 0; i < nonSpawnZones.Length; i++){
                if(nonSpawnZones[i] != null){
                    Debug.Log("Object "+ i + " : " + nonSpawnZones[i].transform.position);
                    Vector3 lowerOffset = new Vector3(nonSpawnZones[i].transform.position.x-0.5f, nonSpawnZones[i].transform.position.y-0.05f, nonSpawnZones[i].transform.position.z);
                    Vector3 upperOffset = new Vector3(nonSpawnZones[i].transform.position.x+0.5f, nonSpawnZones[i].transform.position.y+0.05f, nonSpawnZones[i].transform.position.z);
                    if((newPos.x >= upperOffset.x || newPos.x <= lowerOffset.x)&& (newPos.y <= lowerOffset.y || newPos.y >= upperOffset.y)){
                        continue;
                    }else{
                        positionFound = true;
                        
                    }
                }
            }

           

        }
        if(positionFound){
                tree = Instantiate(tree, new Vector3(x_pos, y_pos, 0), tree.transform.rotation) as GameObject;
                numTrees += 1;
                is_broke = false;
                Debug.Log("Found new position: " + newPos);
        }

    
    }

    private void OnCollisionEnter2D(Collision2D collision){
        this.collision = collision;
    
    }
}
