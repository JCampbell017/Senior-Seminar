using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private int damage = 5;
    [SerializeField]
    private float speed = 0.75f;
    [SerializeField]
    private float range = -1f;

    [SerializeField]
    private EnemyData data;

    private GameObject player;


    public float offset = 0.05f;
    public Rigidbody2D rbPlayer;

    public Collider2D tmcTrees;
    private bool isTouchingPlayer = false;
    private bool isMoving = false;

    Animator animEnemy; 

    float timer = 0.0f;

    [SerializeField]
    float timeToSpawn = 20.0f;

    // Start is called before the first frame update
    void Start()
    {
        rbPlayer = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        animEnemy = GetComponent<Animator>();
        SetEnemyValues();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(player != null && timer > timeToSpawn)
            LightEnemy();
        
    }

    private void SetEnemyValues()
    {
        GetComponent<Health>().SetHealth(data.hp, data.hp);
        damage = data.damage;
        speed = data.speed;
    }

    private void LightEnemy()
    {
        if(Vector2.Distance(transform.position, player.transform.position) >= range)
        {
            isMoving = true;
            animEnemy.SetBool("IsMoving", true);
            Debug.Log("Enemy Moving");
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            if(transform.position.x > player.transform.position.x){
                GetComponent<SpriteRenderer> ().flipX = true;
            }else{
                GetComponent<SpriteRenderer> ().flipX = false;
            }
        }else{
            isMoving = false;
            animEnemy.SetBool("IsMoving", false);
        }
        
    }

    //This method will make the enemy inflict damage.
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            if (collider.GetComponent<Health>() != null)
            {
                collider.GetComponent<Health>().Damage(damage);
                this.GetComponent<Health>().Damage(3);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag =="Player"){
            isTouchingPlayer = true;
        }else{
            isTouchingPlayer = false;
        }
    }

    // private void OnCollisionExit2D(Collision2D collision){
    //     if(collision.gameObject.tag =="Player"){
    //         isTouchingPlayer = false;
    //     }
    // }
}
