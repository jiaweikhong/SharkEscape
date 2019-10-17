using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : BulletScript
{
    public LaserScript()
    {
        deactivate_Timer = 3f;
    }

    // Start is called before the first frame update
    void Start()
    {
        InstantiateBullet();
        SetLevelStats();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    void SetLevelStats()
    {
        switch (laser_level)
        {
            case 1:
                damage = 7.1f;
                bulletSpeed = 7f;
                break;
            case 2:
                damage = 14.2f;
                bulletSpeed = 7f;
                break;
            case 3:
                damage = 14.5f;
                bulletSpeed = 11f;
                // upgrade bullet behaviour
                break;
            case 4:
                damage = 21.8f;
                bulletSpeed = 11f;
                break;
            case 5:
                damage = 21.8f;
                bulletSpeed = 14f;
                // upgrade bullet behaviour
                break;
            case 6:
                damage = 22.5f;
                bulletSpeed = 16f;
                // introduce ulti weapon
                break;
        }
    }

}
