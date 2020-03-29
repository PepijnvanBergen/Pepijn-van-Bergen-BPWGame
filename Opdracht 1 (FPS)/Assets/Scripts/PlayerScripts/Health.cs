using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float health = 100f;
    private SliderScript SC;
    public Transform player;


    private void Awake()
    {
        SC = GameObject.FindObjectOfType<SliderScript>();
    }
    public void takeDamage(float amount)
    {
        health -= amount;
    }
    public void Gordel(float amount)
    {
        health += amount;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "EnemyBullet" || collision.transform.tag == "Enemy")
        {
            health -= 15f;
            SC.UpdateHealth(health);
        }
        if (collision.transform.tag == "Gordel")
        {
            health += 10f;
            SC.UpdateHealth(health);
        }
    }

    private void Update()
    {
        if (player.transform.position.y < -25)
        {
            Die();
        }
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}

