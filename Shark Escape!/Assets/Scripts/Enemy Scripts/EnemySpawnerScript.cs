using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{
	public float min_X = -5.0f, max_X = 5.0f;

	public GameObject enemy_prefab;

	public float timer = 2f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnEnemies",timer);
    }

    void SpawnEnemies(){

    	float pos_X = Random.Range(min_X,max_X);
    	Vector3 temp = transform.position;
    	temp.x = pos_X;
		Instantiate(enemy_prefab,temp, Quaternion.Euler(0f,0f,0f));
    	Invoke("SpawnEnemies", timer);
    }
}
