using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed = 5f;
    public float deactivate_Timer = 3f;

    private float torpedo_X;    // decided by PlayerController.cs
    private float torpedo_Y;

    // Start is called before the first frame update
    void Start()
    {
        torpedo_X = PlayerController.torpedo_X;
        torpedo_Y = PlayerController.torpedo_Y;
        SetAngle(torpedo_X, torpedo_Y);     // set the angle of the torpedo flying
        Invoke("DeactivateGameObject", deactivate_Timer);   // torpedo disappears after deactivate_Timer is up
    }

    // Update is called once per frame
    void Update()
    {
        Move();   
    }

    void Move()
    {
        Vector3 temp = transform.position;
        temp.x += speed * Time.deltaTime * torpedo_X;
        temp.y += speed * Time.deltaTime * torpedo_Y;
        transform.position = temp;
    }   // move

    void DeactivateGameObject() {
        gameObject.SetActive(false);
    }   // deactivate

    void SetAngle(float x, float y) {
        if (x >= 0 & y >= 0) {
            float val = 0 + 90 * -x;
            transform.rotation = Quaternion.Euler(0, 0, val);   // set rotation
        }
        else if (x <= 0 & y >= 0) {
            float val = 270 + 90 * -y;
            transform.rotation = Quaternion.Euler(0, 0, val);
        }
        else if (x <= 0 & y <= 0) {
            float val = 90 + 90 * -y;
            transform.rotation = Quaternion.Euler(0, 0, val);
        }
        else if (x >= 0 & y <= 0) {
            float val= 180 + 90 * x;
            transform.rotation = Quaternion.Euler(0, 0, val);
        }
    }   // set angle
}





