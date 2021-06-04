using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    public int HP;
    public GameObject enemy;
    public GameObject checkBox;
    public float speed;
    private Vector2 enemyPosition;
    private bool isScratch = false;
    private float wait;
    private Rigidbody2D rig;
    private bool died;
    public Animator ani;
    public AudioSource sound;
    void Start()
    {
        HP = 3;
        died = false;
        speed = 4f;
        rig = GetComponent<Rigidbody2D>();
        wait = Time.time;
    }
    // Update is called once per frame
    void Update()
    {
        if (Time.time > wait + 0.5f && !died) sound.Play(); 
        enemyPosition.x = transform.position.x;
        enemyPosition.y = transform.position.y;
        Vector2 look = Gunner.playerPosition - enemyPosition;
        float Angle = Mathf.Atan2(look.y, look.x) * Mathf.Rad2Deg;
        rig.rotation = Angle;
        rig.velocity = look * speed / look.magnitude;

        isScratch = checkBox.GetComponent<ZombieAttack>().isScratch;
        //enemyShoot
        if (!isScratch)
        {
            ani.SetBool("attack", false);
            rig.velocity = look * speed / look.magnitude;
        }
        else if (isScratch)
        {
            Debug.Log("attack");
            ani.SetBool("attack", true);
        }
        if (HP <= 0)
        {
            ani.SetTrigger("die");
            Score.playerScore += 5;
            died = true;
            Destroy(enemy, 0.5f);
        }
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag.Equals("Bullet"))
        {
            takeDmg(1);
        }
    }
    public void takeDmg(int dmg)
    {
        HP -= dmg;
    }
}
