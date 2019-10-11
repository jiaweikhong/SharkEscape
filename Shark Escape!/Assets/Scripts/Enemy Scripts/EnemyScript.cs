using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
	public float speed = 5f;
	public float rotate_Speed = 50f;

	private bool canMove = true;

	public float bound_Y = -11f;
	public GameObject enemyPrefab;

	//Free to add sounds and animations later here


    void Awake()
    {
        
    }

    void Start(){

    }
    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move(){
    	if(canMove) {
    		Vector3 temp = transform.position;
    		temp.y -= speed * Time.deltaTime;
    		transform.position = temp;

    		if(temp.y < bound_Y){
    			enemyPrefab.SetActive(false);
    		}
    	}
    }


}
