using UnityEngine;

public class TargetScript : MonoBehaviour
{
    public float health = 100f;

    public void takeDamage(float damage)
    {
        health -= damage;

        if(health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log(transform.name + " is dead");
    }
}
