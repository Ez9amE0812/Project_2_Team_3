using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullet : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bullet;
    void Start()
    {
        // bullet = GameObject.FindGameObjectWithTag("Bullet");
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag.Equals("Enemy"))
        {
            Destroy(bullet);
        }
        if (other.collider.tag.Equals("Bullet"))
        {
            Destroy(bullet);
        }
        // if (other.collider.tag.Equals("DestroyBullet"))
        // {
        //     Destroy(bullet);
        // }
    }
}
