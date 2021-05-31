using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 3f;
    public Rigidbody2D rb;

    Vector2 movement;

    public int maxHealth = 100;
    public int currentHealth;

    public Health healthbar;

    void Start()
    {
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);

    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag.Equals("Enemy"))
        {
            TakeDamage(10);
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("EnemyBullet"))
        {
            TakeDamage(5);
        }
    }
    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0) currentHealth = 0;
        healthbar.SetHealth(currentHealth);
    }
}
