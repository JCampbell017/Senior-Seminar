using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private int damage = 5;
    [SerializeField]
    private float speed = 0.75f;
    [SerializeField]
    private float range = 0.05f;

    [SerializeField]
    private EnemyData data;

    private GameObject player;

    public float offset = 0.05f;
    public Rigidbody2D rbPlayer;

    public Collider2D tmcTrees;

    // Start is called before the first frame update
    void Start()
    {
        rbPlayer = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        SetEnemyValues();
    }

    // Update is called once per frame
    void Update()
    {
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
        if(Vector2.Distance(transform.position, player.transform.position) <= range)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
        //transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        //  Vector3 dir = (player.transform.position - rbPlayer.transform.position).normalized;
        //  rbPlayer.MovePosition(rbPlayer.transform.position + dir * speed * Time.fixedDeltaTime);
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
}