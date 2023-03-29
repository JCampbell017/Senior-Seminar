using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    private int damage = 3;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.GetComponent<Health>() != null)
        {
            Health health = collider.GetComponent<Health>();
            health.Damage(damage);
        }
        
    }

    
    private void OnCollisionEnter2D(Collision2D collision){
        Debug.Log(collision.gameObject.name + " : " + gameObject.name + " : " + Time.time);
        // if(collision.CompareTag("Tree")){
        //     // animator.Play("swing");
        //     // animator.SetFloat("Magnitude", rbPlayer.velocity.magnitude);
        //     Debug.Log(collision.gameObject.name + " : " + gameObject.name + " : " + Time.time);

        // }
    }
}
