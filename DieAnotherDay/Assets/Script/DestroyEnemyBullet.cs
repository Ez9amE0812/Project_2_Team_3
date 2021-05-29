using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemyBullet : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bullet;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D other)
    {
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Player"))
        {
            Destroy(bullet);
            Debug.Log("asaasasas");
        }
        if (other.tag.Equals("Wall"))
        {
            Destroy(bullet);
            Debug.Log("vsvasvav");
        }
    }
}
