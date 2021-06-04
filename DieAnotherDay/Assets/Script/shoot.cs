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
    private float waitPower;
    public Health powerBar;
    private int maxPower = 20;
    private int currentPower;
    public AudioSource GunSound;
    public AudioSource LazerSound;
    // Start is called before the first frame update
    void Start()
    {
        currentPower = 0;
        powerBar.SetMaxHealth(maxPower);
        waitPower = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        powerBar.SetHealth(currentPower);

        if (Input.GetMouseButtonDown(0) && !Player.died)
        {
            ani.SetBool("firer", true);
            ani.SetBool("lazer", false);
            wait = Time.time;

            //Create bullet
            GunSound.Play();
            GameObject bullet = Instantiate(Bullet);
            Rigidbody2D rig = bullet.GetComponent<Rigidbody2D>();
            bullet.transform.position = firePosition.position;
            Vector2 look = Gunner.mousePosition - Gunner.playerPosition;
            rig.rotation = Mathf.Atan2(look.y, look.x) * Mathf.Rad2Deg - 90f;
            rig.velocity = look * speed / look.magnitude;
            Destroy(bullet, 2.5f);
        }
        if (Input.GetMouseButton(1) && !Player.died)
        {
            ani.SetBool("firer", false);
            ani.SetBool("lazer", true);
            wait = Time.time;

            //create lazer
            if (currentPower > 0)
            {
                if (Time.time > waitPower + 0.1f)
                {
                    currentPower -= 1;
                    waitPower = Time.time;
                    LazerSound.Play();
                    lazer.SetPosition(0, lazerPosition.position);
                    Vector2 direction = Gunner.mousePosition - (Vector2)lazerPosition.position;
                    RaycastHit2D hitInfo = Physics2D.Raycast(lazerPosition.position, direction / direction.magnitude);
                    if (hitInfo)
                    {
                        Alien alien = hitInfo.transform.GetComponent<Alien>();
                        Zombie zombie = hitInfo.transform.GetComponent<Zombie>();
                        if (alien != null)
                        {
                            alien.takeDmg(3);
                        }
                        if (zombie != null)
                        {
                            zombie.takeDmg(3);
                        }
                        lazer.SetPosition(1, hitInfo.point);
                    }
                }
            }
            else
            {
                lazer.SetPosition(0, new Vector3(0, 0, -1));
                lazer.SetPosition(1, new Vector3(0, 0, -1));
            }
        }
        else
        {
            if (Time.time > waitPower + 0.3f)
            {
                currentPower += 1;
                if (currentPower > maxPower) currentPower = maxPower;
                waitPower = Time.time;
            }

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
