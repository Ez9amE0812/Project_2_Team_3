using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour
{
    // Start is called before the first frame update
    public int HP;
    public GameObject enemy;
    public GameObject checkBox;
    public float speed;
    public float bulletSpeed;
    public GameObject EnemyBullet;
    public Transform firePosition;
    private Vector2 enemyPosition;
    public bool isScratch = false;
    private float delayShootTime;
    private float ShootingCycle;
    private float wait;
    private float distanceShoot;
    private Rigidbody2D rig;
    public Animator ani;
    void Start()
    {
        HP = 200;
        bulletSpeed = 15f;
        delayShootTime = 0.35f;
        ShootingCycle = 3f;
        wait = Time.time;
        distanceShoot = 20f;
        speed = 1.5f;
        rig = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {

        enemyPosition.x = transform.position.x;
        enemyPosition.y = transform.position.y;
        Vector2 look = Gunner.playerPosition - enemyPosition;
        float Angle = Mathf.Atan2(look.y, look.x) * Mathf.Rad2Deg - 90f;
        rig.rotation = Angle;
        rig.velocity = look * speed / look.magnitude;

        isScratch = checkBox.GetComponent<AlienScratch>().isScratch;
        //enemyShoot
        if (!isScratch)
        {
            ani.SetBool("scratch", false);
        }
        else if (isScratch)
        {
            Debug.Log("scratch");
            ani.SetBool("scratch", true);
        }
        if (distance(Gunner.playerPosition.x, Gunner.playerPosition.y, enemyPosition.x, enemyPosition.y) < distanceShoot && !isScratch)
        {
            if (Time.time > wait + ShootingCycle)
            {
                ani.SetTrigger("shoot");
                if (Time.time > wait + delayShootTime + ShootingCycle)
                {
                    GameObject bullet = Instantiate(EnemyBullet);
                    Rigidbody2D rigBullet = bullet.GetComponent<Rigidbody2D>();
                    bullet.transform.position = firePosition.position;
                    rigBullet.velocity = look * bulletSpeed / look.magnitude;
                    Destroy(bullet, 7f);
                    wait = Time.time;
                    ani.ResetTrigger("shoot");
                }

            }
        }
        //Enemy scratch
        else
        {
            wait = Time.time;
            rig.velocity = look * speed / look.magnitude;
        }
        if (HP <= 0)
            Destroy(enemy);
    }
    float distance(float x1, float y1, float x2, float y2)
    {
        return Mathf.Sqrt(Mathf.Pow(x1 - x2, 2) + Mathf.Pow(y1 - y2, 2));
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag.Equals("Bullet"))
        {
            takeDmg(10);
        }
    }
    public void takeDmg(int dmg)
    {
        HP -= dmg;
    }

}
