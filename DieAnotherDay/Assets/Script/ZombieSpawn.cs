using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawn : MonoBehaviour
{
    public Transform Portal;
    public GameObject Zombie;
    Vector2 PortalCircle;
    int T = 0;
    void Start()
    {
        PortalCircle = Portal.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (T % 100 == 0 && !Player.died)
        {
            Vector2 spawnPos = PortalCircle + Random.insideUnitCircle;
            Instantiate(Zombie, spawnPos, Quaternion.identity);
        }
        T++;
    }
}
