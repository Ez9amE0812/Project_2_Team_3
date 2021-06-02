using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    public GameObject Bullet;
    public Transform firePosition;
    public Transform lazerPosition;

    public Animator ani;
    public LineRenderer lazer;

    private float speed = 20;
    private float wait;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            ani.SetBool("firer", true);
            ani.SetBool("lazer", false);
            wait = Time.time;

            //Create bullet
            GameObject bullet = Instantiate(Bullet);
            Rigidbody2D rig = bullet.GetComponent<Rigidbody2D>();
            bullet.transform.position = firePosition.position;
            Vector2 look = Gunner.mousePosition - Gunner.playerPosition;
            rig.rotation = Mathf.Atan2(look.y, look.x) * Mathf.Rad2Deg - 90f;
            rig.velocity = look * speed / look.magnitude;
            Destroy(bullet, 2.5f);
        }
        if (Input.GetMouseButton(1))
        {
            ani.SetBool("firer", false);
            ani.SetBool("lazer", true);
            lazer.SetPosition(0, lazerPosition.position);

            wait = Time.time;
            //create lazer
            Vector2 direction = Gunner.mousePosition - (Vector2)lazerPosition.position;
            RaycastHit2D hitInfo = Physics2D.Raycast(lazerPosition.position, direction / direction.magnitude);
            if (hitInfo)
            {
                EnemyTakeDmg enemy = hitInfo.transform.GetComponent<EnemyTakeDmg>();
                Alien alien = hitInfo.transform.GetComponent<Alien>();
                if (enemy != null)
                {
                    enemy.takeDmg(1);
                }
                if (alien != null)
                {
                    alien.takeDmg(1);
                }
                lazer.SetPosition(1, hitInfo.point);
            }


        }
        else
        {
            lazer.SetPosition(0, new Vector3(0, 0, -1));
            lazer.SetPosition(1, new Vector3(0, 0, -1));
        }

        if (Time.time > (wait + 0.5f))
        {
            ani.SetBool("firer", false);
            ani.SetBool("lazer", false);

        }

    }
}
