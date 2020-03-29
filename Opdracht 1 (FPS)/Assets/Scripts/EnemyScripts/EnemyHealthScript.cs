using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthScript : MonoBehaviour
{
    public float health = 50f;

    public void takeDamage (float amount)
    {
        health -= amount;
        if(health <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Destroy(gameObject);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Bullet")
        {
            health  -= 15;
        }
        if (health <= 0)
        {
            Die();
        }
    }
}
