using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
    public Rigidbody2D rig;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            if (Input.GetKey("w"))
            {
                rig.rotation = 90f;
            }
            else if (Input.GetKey("a"))
            {
                rig.rotation = 180f;
            }
            else if (Input.GetKey("s"))
            {
                rig.rotation = -90f;
            }
            else if (Input.GetKey("d"))
            {
                rig.rotation = 0f;
            }
        }
    }
}
