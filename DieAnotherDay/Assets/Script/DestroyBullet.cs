using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullet : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bullet;
    public Animator ani; 
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
            ani.SetTrigger("kill");
            Destroy(bullet, 0.2f);
        }
        if (other.collider.tag.Equals("Alien"))
        {
            ani.SetTrigger("kill");
            Destroy(bullet, 0.2f);
        }
        if (other.collider.tag.Equals("Bullet"))
        {
            Destroy(bullet);
        }
        if (other.collider.tag.Equals("Wall"))
        {
            ani.SetTrigger("impact");
            Destroy(bullet, 0.2f);
        }
        // if (other.collider.tag.Equals("DestroyBullet"))
        // {
        //     Destroy(bullet);
        // }
    }
}
