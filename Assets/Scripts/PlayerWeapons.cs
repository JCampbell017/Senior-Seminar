using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapons : MonoBehaviour
{
    public GameObject bullets;
    public Transform barrel;
    public float velocity = 10f;

    private void Update()
    {
        Vector2 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        transform.rotation = rotation;
    }
    public void Shoot()
    {
        GameObject bullet = Instantiate(bullets, barrel.position, barrel.rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(barrel.up * velocity, ForceMode2D.Impulse);
    }
}
