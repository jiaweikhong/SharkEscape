using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{
	public float min_X = -6.0f, max_X = 6.0f;

	public GameObject[] enemy_Prefabs;

	public float timer = 2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void SpawnEnemies(){

    	float pos_X = Random.Range(min_X,max_X);
    	Vector3 temp = transform.position;
    	temp.x = pos_X;
		Instantiate(enemy_Prefabs[Random.Range(0, 4)],temp, Quaternion.identity);
    	Invoke("SpawnEnemies", timer);
    }
}
