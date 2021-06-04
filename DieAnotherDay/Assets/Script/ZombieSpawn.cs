using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawn : MonoBehaviour
{
    public Transform Portal;
    public GameObject Zombie1;
    public GameObject Zombie2;
    public GameObject Zombie3;
    Vector2 PortalCircle;
    int T = 0;
    void Start()
    {
        PortalCircle = Portal.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (T % 420 == 0 && !Player.died)
        {
            Vector2 spawnPos = PortalCircle + Random.insideUnitCircle;
            Instantiate(Zombie1, spawnPos, Quaternion.identity);
        }
        if (T % 420 == 140 && !Player.died)
        {
            Vector2 spawnPos = PortalCircle + Random.insideUnitCircle;
            Instantiate(Zombie2, spawnPos, Quaternion.identity);
        }
        if (T % 420 == 280 && !Player.died)
        {
            Vector2 spawnPos = PortalCircle + Random.insideUnitCircle;
            Instantiate(Zombie3, spawnPos, Quaternion.identity);
        }
        T++;
    }
}
