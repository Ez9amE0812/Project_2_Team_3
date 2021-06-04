using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMove : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public Animator animator;
    private Vector2 enemyPosition;
    private Rigidbody2D rig;
    private float wait;
    void Start()
    {
        wait = Time.time;
        speed = 3.0f;
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        enemyPosition.x = transform.position.x;
        enemyPosition.y = transform.position.y;
        Vector2 look = Gunner.playerPosition - enemyPosition;
        float Angle = Mathf.Atan2(look.y, look.x) * Mathf.Rad2Deg;
        rig.rotation = Angle;
        rig.velocity = look * speed / look.magnitude;
        rig.velocity = look * speed / look.magnitude;
        if (Time.time > wait + 1.5f)
        {
            animator.SetBool("attack", false);
            wait = Time.time;
        }
    }
    float distance(float x1, float y1, float x2, float y2)
    {
        return Mathf.Sqrt(Mathf.Pow(x1 - x2, 2) + Mathf.Pow(y1 - y2, 2));
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag.Equals("Player"))
        {
            animator.SetBool("attack", true);
            wait = Time.time;
        }
    }
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.collider.tag.Equals("Player"))
        {
            animator.SetBool("attack", true);
            wait = Time.time;
        }
    }
}
