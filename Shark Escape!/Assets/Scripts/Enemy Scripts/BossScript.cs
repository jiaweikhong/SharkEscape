﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    public float health = StatDatabase.boss1_health;
    public float baseHealth = StatDatabase.boss1_health;
    public int points = StatDatabase.boss1_points;
    public int touchdamage = StatDatabase.boss1_touchdamage;
    public float speed = StatDatabase.boss1_speed;
    public int threshold = 1;
    private bool canAttack = true;
    public int minWPs = 2;
    public int maxWPs = 4;
    public GameObject whirlpool;
    public GameObject shark;
    public float normalizeRatio;

    [SerializeField] private BossHealthBarScript healthBar;
    // Start is called before the first frame update
    void Start()
    {
        healthBar = GameObject.Find("HealthBar").GetComponent<BossHealthBarScript>();
        healthBar.SetSize(.4f);
        normalizeRatio = baseHealth / .4f;
    }
    // Update is called once per frame
    void Update()
    {

        if (StatDatabase.boss1_isAwake == true)
        {
            if(canAttack == true)
            {
                Debug.Log("Boss Attacks!");
                StartCoroutine(bossAttacks());
            }
        }
    }
    void checkHealth()
    {
        adjustThreshold();
        if (health <= 0)
        {
            ScoreManager.score += points;
            // Debug.Log(ScoreManager.score);
            Debug.Log("Dead!");
            //Change this to a death sequence ba
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
    void adjustThreshold()
    {
        
        healthBar.SetSize(normalizeRatio * health);
        if (health < 0.9 * (baseHealth) && health > 0.7 * (baseHealth))
        {
            threshold = 2;
        }
        else if (health < 0.7 * (baseHealth) && health > 0.5 * (baseHealth))
        {
            threshold = 3;
        }
        else if (health < 0.5 * (baseHealth))
        {
            threshold = 4;
        }
    }

    IEnumerator attackOne()
    {
        Debug.Log("Attack 1!");
        // Ensure Submarine exists (i.e. Not dead and destroyed)
        var playerObject = GameObject.Find("Submarine");
        if (playerObject)
        {
            // 1. posToGo = currentPlayerPosition
            var posToGo = playerObject.transform.position;
            // 2. wait 1 seconds
            StartCoroutine(timer(1));
            var t = 0f;
            // 3. While not at posToGo
            while (t < 1)
            {
                // 4. move to posToGo at speed
                var distance = Vector3.Distance(posToGo, transform.position);
                var timeToMove = distance / StatDatabase.boss1_speed;
                t += Time.deltaTime / timeToMove;
                transform.position = Vector3.Lerp(transform.position, posToGo, t);
                yield return null;
                //yield return new WaitForSeconds(3);
                // 5. resolved
            }

        }


    }
    // 3. Attack 2: Disappear. Mob of sharks appear then boss reappear
    IEnumerator attackTwo()
    {
        Debug.Log("Attack 2!");
        // Whirlpool attack!

        int noOfWPs = Random.Range(minWPs, maxWPs + 1); //maxWPs + 1 because Range excludes the right value
        for (int i = 0; i< noOfWPs; i++)
        {
            Instantiate(whirlpool);
        }
        yield return null;
    }


    IEnumerator attackThree()
    {
        Debug.Log("Attack 3!");
        int noOfMobstoSpawn = Random.Range(1,  6);
        for (int i = 0; i < noOfMobstoSpawn; i++)
        {
            float xPos = Random.Range(-20, 20);
            float yPos = Random.Range(60, 80);
            Vector3 sharkPos = new Vector3(xPos, yPos, 0);
            Instantiate(shark, sharkPos, Quaternion.identity);
        }

        yield return null;

    }

    IEnumerator attackFour()
    {
        StartCoroutine(timer(1));
        var t = 0f;
        // 3. While not at posToGo
        float new_y = Random.Range(60, 75);
        Vector3 initPos = new Vector3(23, new_y, 0);
        Vector3 finalPos = new Vector3(-23, new_y, 0);
        while (t < 1)
        {
            // 4. move to posToGo at speed
            var distance = Vector3.Distance(finalPos, initPos);
            var timeToMove = distance / (speed * 15.0f);
            t += Time.deltaTime / timeToMove;
            transform.position = initPos;
            transform.position = Vector3.Lerp(transform.position, finalPos, t);
            yield return null;
            // 5. resolved
        }
    }

    // 4. Attack 3. Shoot bullets in a circle
    // 5. Attack 4. Dash through screen for a few seconds
    // 6. Death state
    // 7. Move to 3 of the spots state
    IEnumerator timer(float num)
    {
        yield return new WaitForSeconds(num);
    }
    IEnumerator bossAttacks()
    {
        //Fn activates when fight commences or we can instantiate object when boss fight commences
        //run bossAttacks
        canAttack = false;
        Debug.Log("Boss Attack commences!");
        //int atkDecision = Random.Range(1, threshold+1);
        int atkDecision = 1;
        switch (atkDecision)
        {
            case 1:
                StartCoroutine(attackOne());
                break;
            case 2:
                StartCoroutine(attackTwo());
                break;
            case 3:
                StartCoroutine(attackThree());
                break;
            case 4:
                StartCoroutine(attackFour());
                break;
        }
        //Timer runs for 2 seconds
        //Then boss stops and reveals hitbox for head ( If adding, might have to change the mechanism for the yield below
        //Restart flow!
        yield return new WaitForSeconds(5);
        canAttack = true;

    }
}
