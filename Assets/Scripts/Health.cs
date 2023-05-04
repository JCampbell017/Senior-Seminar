using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    // Had to temporarily make the health variable public for the saving progress
    [SerializeField] public int health = 100;

    private int MAX_HEALTH = 100;
    public HealthBar healthBar;
    public LootBox lootBox;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            //Damage(10);
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            Heal(10);
        }
    }

    public void SetHealth(int maxHealth, int health)
    {
        this.MAX_HEALTH = maxHealth;
        this.health = health;
        healthBar.setMaxHealth(maxHealth);
    }

    public int GetHealth(){
        return health;
    }

    public void Damage(int amount)
    {
        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot have negative Damage");
        }

        this.health -= amount;
        healthBar.setHealth(this.health);

        if (health <= 0)
        {
            Die();
        }
    }

    public void Heal(int amount)
    {
        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot have negative healing");
        }

        bool wouldBeOverMaxHealth = health + amount > MAX_HEALTH;

        if (wouldBeOverMaxHealth)
        {
            this.health = MAX_HEALTH;
        }
        else
        {
            this.health += amount;
        }
        healthBar.setHealth(this.health);
    }

    private void Die()
    {
        Debug.Log("I am Dead!");
        FindObjectOfType<AudioManager>().Play("Death");
        if(gameObject.tag == "Enemy")
            lootBox.PlaceLootBox(gameObject.transform.position);
        Destroy(gameObject);
    }
}