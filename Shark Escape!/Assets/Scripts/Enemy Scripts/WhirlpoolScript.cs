using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhirlpoolScript : EnemyScript
{
    public float leftLimit = -20.0f;
    public float rightLimit = 16.0f;
    public bool isActive = false;
    public float deactivate_Timer = 10f;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyGameObject", deactivate_Timer);
        float rand_x = Random.Range(leftLimit, rightLimit);
        transform.position = new Vector3(rand_x, transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }


    public void Move()
    {
        Vector3 temp = transform.position;
        //temp.x += speed * Time.deltaTime * Random.Range(-10f,10f);
        temp.y -= speed * Time.deltaTime * 7.0f;
        transform.position = temp;
    }   // move

    private void OnTriggerEnter2D(Collider2D collision)
    {

    }
    void DestroyGameObject()
    {
        gameObject.SetActive(false);
        Destroy(gameObject);
    }   //
}
