using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gunner : MonoBehaviour
{
    // Public GameObject 
    // Start is called before the first frame update
    // public GameObject obj;
    Transform trans;
    private Vector2 mousePosition;
    private Vector2 playerPosition;
    private Rigidbody2D rig;
    void Start()
    {
        trans = GetComponent<Transform>();
        rig = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        playerPosition.x = trans.position.x;
        playerPosition.x = trans.position.y;
        Vector2 look = mousePosition - playerPosition;
        float Angle = Mathf.Atan2(look.y, look.x) * Mathf.Rad2Deg - 90f;
        if (distance(mousePosition.x, mousePosition.y, trans.position.x, trans.position.y) > 1)
            rig.rotation = Angle;
    }
    float distance(float x1, float y1, float x2, float y2)
    {
        return Mathf.Sqrt(Mathf.Pow(x1 - x2, 2) + Mathf.Pow(y1 - y2, 2));
    }

}
