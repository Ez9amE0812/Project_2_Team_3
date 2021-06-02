using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTakeDmg : MonoBehaviour
{
    // Start is called before the first frame update
    public int HP;
    public GameObject enemy;
    void Start()
    {
        HP = 100;
        // enemy = GameObject.FindGameObjectWithTag("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        if (HP <= 0)
            Destroy(enemy);
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
