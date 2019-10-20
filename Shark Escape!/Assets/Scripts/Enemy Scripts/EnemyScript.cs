using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
	public float speed = 1.0f;

	private bool dirRight = true;

    private Vector3 leftBound = new Vector3(-4,0,0);
    private Vector3 rightBound = new Vector3(4, 0, 0);
    public float health = 10;

	public GameObject enemyPrefab;

	//Free to add sounds and animations later here


    void Awake()
    {
        
    }

    void Start(){

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
            Destroy(enemyPrefab);
            Destroy(this);
        }
    }

    // when the GameObjects collider arrange for this GameObject to be destroyed
    
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    Debug.Log(collision.gameObject.name + " : " + gameObject.name + " : " + Time.time);
        //Need to add the interaction with the bullet. If Debug.Log prints out the name for Enemy and Bullet, then next step is to activate destroy. Then the checkhealth not needed.

    //}

}
