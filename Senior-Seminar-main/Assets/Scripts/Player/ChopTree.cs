using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChopTree : MonoBehaviour
{
     public float damage = 3.0f;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        // if(collider.GetComponent<Health>() != null)
        // {
        //     Health health = collider.GetComponent<Health>();
        //     health.Damage(damage);
        // }
       
        Debug.Log("chopping: " + Time.time);
        
    }
}
