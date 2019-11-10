using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float bulletSpeed = 1.5f;
    public float deactivate_Timer = 10f;
    public float bullet_X;    // decided by PlayerController.cs
    public float bullet_Y;
    public float damage;
    public int torp_level;
    public int laser_level;

    public Sprite L2_sprite;
    public Sprite L3_sprite;
    public Sprite L4_sprite;
    public Sprite L5_sprite;
    public Sprite L6_sprite;

    // Start is called before the first frame update
    void Start()
    {}

    // Update is called once per frame
    void Update()
    {}

    public void InstantiateBullet()
    {
        bullet_X = PlayerController.bullet_X;
        bullet_Y = PlayerController.bullet_Y;
        torp_level = PlayerController.torpedo_level;
        laser_level = PlayerController.laser_level;
        SetAngle(bullet_X, bullet_Y);     // set the angle of the torpedo flying
        Invoke("DestroyGameObject", deactivate_Timer);   // torpedo disappears after deactivate_Timer is up
    }

    public void Move()
    {
        Vector3 temp = transform.position;
        temp.x += bulletSpeed * Time.deltaTime * bullet_X;
        temp.y += bulletSpeed * Time.deltaTime * bullet_Y;
        transform.position = temp;
    }   // move

    void DestroyGameObject() {
        gameObject.SetActive(false);
        Destroy(gameObject);
    }   // deactivate

    void SetAngle(float x, float y) {
        if (x >= 0 & y >= 0) {
            float val = 0 + 90 * -x;
            transform.rotation = Quaternion.Euler(0, 0, val);   // set rotation
        }
        else if (x <= 0 & y >= 0) {
            float val = 90 + 90 * -y;
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

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy" || collision.tag == "Frame")
        {
            DestroyGameObject();
        }
    }   // destroy bullet when collide

}





