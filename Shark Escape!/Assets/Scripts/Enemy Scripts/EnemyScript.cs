using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
	public float speed = 1.0f;

	private bool dirRight = true;

    private Vector3 leftBound;
    private Vector3 rightBound;
    public float health = 30;

	public GameObject enemyPrefab;

	//Free to add sounds and animations later here


    void Awake()
    {
        
    }

    void Start(){
        leftBound = new Vector3(-4 + transform.position.x, transform.position.y, transform.position.z);
        rightBound = new Vector3(4 + transform.position.x, transform.position.y, transform.position.z);
    }
    // Update is called once per frame
    void Update(){
        Move();
    }

    void Move(){
        transform.position = Vector3.Lerp(leftBound,rightBound, (Mathf.Sin(speed * Time.time) + 1.0f)/2.0f);
    }

    void checkHealth()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }   // check current health. if <0, destroy
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "LaserBullet")
        {
            var damagetaken = collision.gameObject.GetComponent<LaserScript>().damage;
            health -= damagetaken;
            checkHealth();
        }
        else if (collision.tag == "TorpBullet")
        {
            var damagetaken = collision.gameObject.GetComponent<TorpedoScript>().damage;
            health -= damagetaken;
            checkHealth();
        }
    }   // apply collision logic with bullet

}
