using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public GameObject bullets;
    private GameObject enemy;
    public Transform barrel;
    public float velocity = 10f;
    [SerializeField]
    private float timer;

    private void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy");
    }

    private void Update()
    {
        Vector3 enemyAim = enemy.transform.position - transform.position;
        float angle = Mathf.Atan2(enemyAim.y, enemyAim.x) * Mathf.Rad2Deg;
        bullets.transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        transform.rotation = bullets.transform.rotation;

        if (enemy != null)
        {
            float dis = Vector2.Distance(transform.position, enemy.transform.position);
            if (dis < 1)
            {
                timer += Time.deltaTime;

                if (timer > 2)
                {
                    timer = 0;
                    Shoot();
                }
            }
        }
    }
    public void Shoot()
    {
        GameObject bullet = Instantiate(bullets, barrel.position, barrel.rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce((enemy.transform.position - transform.position).normalized * velocity);
    }
}
