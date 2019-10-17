﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorpedoScript : BulletScript
{
    public TorpedoScript() {
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
        switch (torp_level)
        {
            case 1:
                damage = 10f;
                bulletSpeed = 5f;
                break;
            case 2:
                damage = 20f;
                bulletSpeed = 5f;
                break;
            case 3:
                damage = 20f;
                bulletSpeed = 8f;
                // upgrade bullet behaviour
                break;
            case 4:
                damage = 30f;
                bulletSpeed = 8f;
                break;
            case 5:
                damage = 30f;
                bulletSpeed = 10f;
                // upgrade bullet behaviour
                break;
            case 6:
                damage = 30f;
                bulletSpeed = 12f;
                // introduce ulti weapon
                break;
        }
    }
}
