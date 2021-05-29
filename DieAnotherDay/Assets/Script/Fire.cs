using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public GameObject Bullet;
    public Transform firePosition;
    public Animator ani;

    private float speed = 10;
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
        if (Time.time > (wait + 0.5f))
            ani.SetBool("firer", false);
    }
}
