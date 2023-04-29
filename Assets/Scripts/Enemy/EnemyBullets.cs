using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullets : MonoBehaviour
{
    [SerializeField]
    private int damage = 3;
    [SerializeField]
    private float timer;


    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > 1.5)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Health health = other.GetComponent<Health>();
            health.Damage(damage);
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("Environment"))
        {
            Destroy(gameObject);
        }
    }

}
