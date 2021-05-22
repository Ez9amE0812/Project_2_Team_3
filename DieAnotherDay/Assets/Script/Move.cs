using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rig;
    public float v;
    void Start()
    {
        v = 2;
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            if (Input.GetKey("w"))
            {
                rig.velocity = new Vector2(0f, 1f) * v;
            }
            else if (Input.GetKey("a"))
            {
                rig.velocity = new Vector2(-1f, 0f) * v;
            }
            else if (Input.GetKey("s"))
            {
                rig.velocity = new Vector2(0f, -1f) * v;
            }
            else if (Input.GetKey("d"))
            {
                rig.velocity = new Vector2(1f, 0f) * v;
            }
        }
        else rig.velocity = new Vector2(0f, 0f);
    }

}
