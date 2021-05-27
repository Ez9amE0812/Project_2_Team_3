using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMove : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    private Vector2 enemyPosition;
    private Rigidbody2D rig;
    void Start()
    {
        speed = 6.0f;
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
    }
}
