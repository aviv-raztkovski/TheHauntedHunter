using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityHealthScript : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;

    public HealthBarScript healthBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.setMaxHealth(maxHealth);
        healthBar.setHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
            takeDamage(20);

        if (Input.GetKeyDown(KeyCode.O))
            heal(20);
    }

    public void takeDamage(float damage)
    {
        if (currentHealth > 0f)
        {
            if (currentHealth - damage < 0f)
                currentHealth = 0f;
            else
                currentHealth -= damage;
            healthBar.setHealth(currentHealth);

            if (currentHealth <= 0f)
                Die();
        }
    }

    public void heal(float healAmount)
    {
        if(currentHealth > 0f)
        {
            if (currentHealth + healAmount > maxHealth)
                currentHealth = maxHealth;
            else
                currentHealth += healAmount;
            healthBar.setHealth(currentHealth);
        }
    }

    void Die()
    {
        Debug.Log(transform.name + " is dead");
    }
}
