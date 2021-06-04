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
    public bool isScratch = false;
    private Rigidbody2D rig;
    public Animator ani;
    public AudioSource shoot_sound;
    void Start()
    {
        HP = 3;
        speed = 4f;
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
            ani.SetTrigger("died");
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
