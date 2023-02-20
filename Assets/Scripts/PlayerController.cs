using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D rbPlayer;
    // public Collider2D tmcTrees;
    public Collider2D colPlayer;
    public float speed = 5.0f;
    public string sideCollision = "";
    
    // Bounds of player on map
    public Transform topLeft;
    public Transform bottomRight;
    private float xMin, xMax, yMin, yMax;

    public bool isTouchingTree = false;
    public GameObject tree;
    // public bool choppingTree = false;
    // private float timeToChop = 0.25f;
    // private float timer = 0f;
    public ButtonController btn;

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

        rbPlayer.velocity = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f)*speed;
        animator.SetFloat("Horizontal", rbPlayer.velocity.x);
        animator.SetFloat("Vertical", rbPlayer.velocity.y);
        animator.SetFloat("Magnitude", rbPlayer.velocity.magnitude);
        this.transform.position = new Vector3(Mathf.Clamp(transform.position.x, xMin, xMax),Mathf.Clamp(transform.position.y, yMin, yMax), this.transform.position.z);

    }

    private void OnCollisionEnter2D(Collision2D collision){
        // Debug.Log(collision.gameObject.name + " : " + gameObject.name + " : " + Time.time);
        if(collision.gameObject.tag == "Tree"){
           Debug.Log("Touching tree");
           tree = collision.gameObject;
            
            btn.tree = collision.gameObject;
            btn.button.SetActive(true);
            CheckCollidingSide(btn.tree);
      
        }
    }

    private void CheckCollidingSide(GameObject obj){
        if(transform.position.x > obj.transform.position.x){
            Debug.Log("Right side collision");
            sideCollision = "right";
        }else{
            Debug.Log("Left side collision");
            sideCollision = "left";
        }
    }

    private void OnCollisionExit2D(Collision2D collision){
        // Debug.Log(collision.gameObject.name + " : " + gameObject.name + " : " + Time.time);
        if(collision.gameObject.tag == "Tree"){
           Debug.Log("Touching tree");
           
            ButtonController btn = Camera.main.GetComponent<ButtonController>();
            btn.button.SetActive(false);
        }
    }

    

}
