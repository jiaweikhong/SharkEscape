using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{
    public float bulletSpeed = 1.5f;
    public float deactivate_Timer = 10f;
    public float damage;

    public float bullet_speed = StatDatabase.enemy2_attack_speed;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Attack());
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Frame"))
        {
            Destroy(gameObject);
        }
    }   // destroy bullet when collide

    IEnumerator Attack()
    {
        // Ensure Submarine exists (i.e. Not dead and destroyed)
        var playerObject = GameObject.Find("Submarine");
        if (playerObject)
        {
            // 1. posToGo = currentPlayerPosition
            var posToGo = playerObject.transform.position;
            // 2. wait 1 seconds
            yield return new WaitForSeconds(1);
            var t = 0f;
            // 3. While not at posToGo
            while (t < 1)
            {
                // 4. move to posToGo at speed
                var distance = Vector3.Distance(posToGo, transform.position);
                var timeToMove = distance / bullet_speed;
                t += Time.deltaTime / timeToMove;
                transform.position = Vector3.Lerp(transform.position, posToGo, t);
                yield return null;
                //yield return new WaitForSeconds(3);
                // 5. resolved
            }

        }
    }
}
