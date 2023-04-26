using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBox : MonoBehaviour
{
    float timer = 0.0f;
    float timeToRemain = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timer > timeToRemain){
            Destroy(gameObject);
        }
    }

    public void PlaceLootBox (Vector3 position){
        Instantiate(gameObject, position, gameObject.transform.rotation);
    }

     private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag =="Player"){
            float food_gain = Random.Range(0,2);
            float water_gain = Random.Range(0,1);
            float scrap_gain = Random.Range (1,4);

            PlayerInv.update_player_inv("food", food_gain);
            PlayerInv.update_player_inv("water", water_gain);
            PlayerInv.update_player_inv("Scrap", scrap_gain);

            Destroy(gameObject);
        }
    }
}
