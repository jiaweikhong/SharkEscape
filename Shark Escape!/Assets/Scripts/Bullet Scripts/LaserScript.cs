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
                bulletSpeed = 14f;
                break;
            case 2:
                damage = 14.2f;
                bulletSpeed = 14f;
                this.GetComponent<SpriteRenderer>().sprite = L2_sprite;
                break;
            case 3:
                damage = 14.5f;
                bulletSpeed = 22f;
                this.GetComponent<SpriteRenderer>().sprite = L3_sprite;
                // upgrade bullet behaviour
                break;
            case 4:
                damage = 21.8f;
                bulletSpeed = 22f;
                this.GetComponent<SpriteRenderer>().sprite = L4_sprite;
                break;
            case 5:
                damage = 21.8f;
                bulletSpeed = 28f;
                this.GetComponent<SpriteRenderer>().sprite = L5_sprite;
                // upgrade bullet behaviour
                break;
            case 6:
                damage = 22.5f;
                bulletSpeed = 32f;
                this.GetComponent<SpriteRenderer>().sprite = L6_sprite;
                // introduce ulti weapon
                break;
        }
    }

}
