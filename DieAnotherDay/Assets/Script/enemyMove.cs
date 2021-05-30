using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMove : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public float bulletSpeed;
    public bool shooter = false;
    public GameObject EnemyBullet;
    public Transform firePosition;
    private Vector2 enemyPosition;
    private float delayShootTime;
    private float ShootingCycle;
    private float wait;
    private float distanceShoot;
    private Rigidbody2D rig;
    void Start()
    {
        bulletSpeed = 8f;
        delayShootTime = 1f;
        ShootingCycle = 3f;
        wait = Time.time;
        distanceShoot = 15f;
        if (!shooter)
        {
            speed = 3.0f;
        }
        else
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
        if (shooter)
        {
            //enemyShoot
            if (distance(Gunner.playerPosition.x, Gunner.playerPosition.y, enemyPosition.x, enemyPosition.y) < distanceShoot)
            {
                if (Time.time > wait + ShootingCycle)
                {
                    rig.velocity = look * 0;
                    if (Time.time > wait + delayShootTime + ShootingCycle)
                    {
                        GameObject bullet = Instantiate(EnemyBullet);
                        Rigidbody2D rigBullet = bullet.GetComponent<Rigidbody2D>();
                        bullet.transform.position = firePosition.position;
                        rigBullet.velocity = look * bulletSpeed / look.magnitude;
                        Destroy(bullet, 7f);
                        wait = Time.time;

                    }

                }
            }
            else
            {
                wait = Time.time;
                rig.velocity = look * speed / look.magnitude;
            }
        }
    }
    float distance(float x1, float y1, float x2, float y2)
    {
        return Mathf.Sqrt(Mathf.Pow(x1 - x2, 2) + Mathf.Pow(y1 - y2, 2));
    }
}
