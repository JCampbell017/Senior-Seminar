using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapons : MonoBehaviour
{
    public GameObject bullets;
    private GameObject player;
    public Transform barrel;
    public float velocity = 10f;
    [SerializeField]
    private float timer;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        Vector3 enemyAim = player.transform.position - transform.position;
        float angle = Mathf.Atan2(enemyAim.y, enemyAim.x) * Mathf.Rad2Deg;
        bullets.transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        transform.rotation = bullets.transform.rotation;
        if (player != null)
        {
            float dis = Vector2.Distance(transform.position, player.transform.position);
            timer += Time.deltaTime;

            if (timer > 2)
            {
                timer = 0;
                Shoot();
            }
        }
    }
    public void Shoot()
    {
        GameObject bullet = Instantiate(bullets, barrel.position, barrel.rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce((player.transform.position - transform.position).normalized * velocity);
    }
}
