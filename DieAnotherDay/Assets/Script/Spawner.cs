using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform Portal;
    public GameObject Alien;
    Vector2 PortalCircle;
    int T = 0; 
    void Start()
    {
        PortalCircle = Portal.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (T % 500 == 0)
        {
            Vector2 spawnPos = PortalCircle + Random.insideUnitCircle * 4;
            Instantiate(Alien, spawnPos, Quaternion.identity);
        }
        T++;
    }
}
