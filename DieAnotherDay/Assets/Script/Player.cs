using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 3f;
    public Rigidbody2D rb;

    Vector2 movement;


    public int currentHealth;
    
    public Health healthbar;
    
    private int maxHealth = 100;
    public static bool died;
    private float wait;

    void Start()
    {
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
        died = false;
        wait = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        /*
        if (currentHealth < maxHealth)
        {
            currentHealth++;
            healthbar.SetHealth(currentHealth);
        }
        */

    }
    private void FixedUpdate()
    {
        if (!died) rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        if (currentHealth < maxHealth && Time.time > wait+1f)
        {
            currentHealth++;
            healthbar.SetHealth(currentHealth);
            wait = Time.time;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag.Equals("Enemy"))
        {
            TakeDamage(15);
        }
        if (other.collider.tag.Equals("Alien"))
        {
            TakeDamage(10);
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("EnemyBullet"))
        {
            TakeDamage(15);
        }
    }
    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0) died = true;
        healthbar.SetHealth(currentHealth);
    }
}
