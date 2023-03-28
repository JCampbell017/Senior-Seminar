using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{   
    public GameObject player;
    // Player Components
    public Animator animator;
    public Rigidbody2D rbPlayer;
    public Collider2D colPlayer;
     public PlayerWeapons rweapon;
    public float speed = 5.0f;

    public string sideCollision = "";
    public string collisionTag = "";

    //Mouse data for aiming weapon
    Vector2 moveDirect;
    Vector2 mousePos;
    
    // Bounds of player on map
    public Transform topLeft;
    public Transform bottomRight;
    private float xMin, xMax, yMin, yMax;
    // Tree Chopping Vars
    public GameObject tree;
    public ButtonController btn;
    //Search
    public GameObject building;
    public SearchPlace searchbtn;
    public bool isSearching = false;

    void Start(){
        animator = GetComponent<Animator>();
        rbPlayer = GetComponent<Rigidbody2D>();
        colPlayer = GetComponent<Collider2D>();

        xMin = topLeft.position.x;
        xMax = bottomRight.position.x;
        yMin = topLeft.position.y;
        yMax = bottomRight.position.y;
        Debug.Log("Hello World");

    }

    void Update(){
        //Data for shooting a ranged weapon
        //Data for shooting a ranged weapon
        float mX = Input.GetAxisRaw("Horizontal");
        float mY = Input.GetAxisRaw("Vertical");
        if (Input.GetMouseButtonDown(0))
        {
            rweapon.Shoot();
        }
        moveDirect = new Vector2(mX, mY).normalized;
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //Player Movement
        rbPlayer.velocity = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f)*speed;
        animator.SetFloat("Horizontal", rbPlayer.velocity.x);
        animator.SetFloat("Vertical", rbPlayer.velocity.y);
        animator.SetFloat("Magnitude", rbPlayer.velocity.magnitude);
        this.transform.position = new Vector3(Mathf.Clamp(transform.position.x, xMin, xMax),Mathf.Clamp(transform.position.y, yMin, yMax), this.transform.position.z);

    }

    // attach to buttons to save 
    public void SavePlayer(){
        Save.SavePlayer(this);
    }

    // attach to button to load game on start up
    public void LoadPlayer(){
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

    }
    // Performed when player collides with an object
    private void OnCollisionEnter2D(Collision2D collision){
        
        collisionTag = collision.gameObject.tag;

        if(collisionTag == "Tree"){ // Did player hit a tree
           Debug.Log("Touching tree");
           tree = collision.gameObject;
            
            btn.tree = collision.gameObject;
            btn.button.SetActive(true);
            CheckCollidingSide(btn.tree);
      
        }else if(collisionTag == "Neighbor"){ // Did player hit a neighboring house
            building = collision.gameObject;
            searchbtn.button.SetActive(true);
            searchbtn.building = building;

        }else if(collisionTag == "LakeHouse"){ // Did player hit lakehouse
          
            building = collision.gameObject;
            
        }else if(collisionTag == "Wind"){ //  Did player hit the windmill
           
            building = collision.gameObject;
            searchbtn.button.SetActive(true);

        }

    }

    // Check which side a tree object collides with the character
    private void CheckCollidingSide(GameObject tree){
        if(transform.position.x > tree.transform.position.x){
            Debug.Log("Right side collision");
            sideCollision = "right";
        }else{
            Debug.Log("Left side collision");
            sideCollision = "left";
        }
    }

    // Performed when the player stops colliding with an object
    private void OnCollisionExit2D(Collision2D collision){
        // Debug.Log(collision.gameObject.name + " : " + gameObject.name + " : " + Time.time);
        if(collision.gameObject.tag == "Tree"){
           Debug.Log("Touching tree");
           
            ButtonController btn = Camera.main.GetComponent<ButtonController>();
            btn.button.SetActive(false);
        }else if(collision.gameObject.tag == "Neighbor"){
              // Disable search button if player isn't searching
            if(!isSearching)
                searchbtn.button.SetActive(false);
        }else if(collision.gameObject.tag == "LakeHouse"){
            //Fish (food, water)
            //No more than +3 fish 
        }else if(collision.gameObject.tag == "Wind"){
            // Disable search button if player isn't searching
            if(!isSearching)
                searchbtn.button.SetActive(false);
        }
    }

    

}
