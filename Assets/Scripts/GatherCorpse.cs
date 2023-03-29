using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatherCorpse : MonoBehaviour
{
    
    // Generates random values for the amount of food, water, and scrap each corpse contains
    private static float food_gain = Random.Range(0, 10);
    private static float water_gain = Random.Range(0, 10);
    private static float scrap_gain = Random.Range(0, 10);

    // Start is called before the first frame update
    void Start()
    {

    }

    // When the player collides with the entity, the home immedieatly gaines the amount of carried suplies 
    void OnCollisionEnter(Collision collision){
        if(collision.gameObject.tag == "Player"){
            PlayerInv.update_player_inv("food", food_gain);
            PlayerInv.update_player_inv("water", water_gain);
            PlayerInv.update_player_inv("scrap", scrap_gain);
        }
    }
}
