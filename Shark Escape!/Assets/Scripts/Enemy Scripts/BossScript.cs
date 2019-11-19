using System.Collections;
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
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void bossMechanismFlow()
    {
        //Fn activates when fight commences or we can instantiate object when boss fight commences
        //Timer runs for 1.5 seconds
        //Once timer ups, run bossAttacks
        //Then boss stops and reveals hitbox for head
        //Restart flow!
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void checkHealth()
    {
        adjustThreshold();

        if (health <= 0)
        {
            ScoreManager.score += points;
            // Debug.Log(ScoreManager.score);
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
        if (health < 0.9 * (baseHealth))
        {
            threshold = 2;
        }
        else if (health < 0.8 * (baseHealth))
        {
            threshold = 3;
        }
        else if (health < 0.4 * (baseHealth))
        {
            threshold = 4;
        }
    }
    // 7 States for boss

    // 1. Rest state
    // 2. Attack 1: Track and return to spot
    void attackOne()
    {
        // 1. posToGo = currentPlayerPosition
        // 2. wait 0.5 seconds
        // 3. While not at posToGo
        // 4. move to posToGo at speed
        // 5. resolved
    }
    // 3. Attack 2: Disappear. Mob of sharks appear then boss reappear
    void attackTwo()
    {
        // 1. Boss fades
        // 2. Generate shark mobs that moves from top to bottom of screen
        // 3. Boss appears
    }

    void attackThree()
    {
        //1. Boss animation
        //2. Boss launches bullets in a circle
    }

    void attackFour()
    {
        // 1. Boss disappears
        // 2. Take camera position & size( these two shld be fixed)
        // 3. RNG ranges between the x axis and either at top or bottom of screen(2 y axis values) (startPos)
        // 4. Generate a new position within the screen (endPos)
        // 5. Signal appearance for 1 second
        // 6. Shark moves from startPos to endPos at speed multiplied by some value 
        // 7. Repeat step 2 to 6 for 4 times
        // 8. Boss reappear again within screen

    }
    // 4. Attack 3. Shoot bullets in a circle
    // 5. Attack 4. Dash through screen for a few seconds
    // 6. Death state
    // 7. Move to 3 of the spots state
    void bossAttacks()
    {
        int atkDecision = Random.Range(1, threshold);
        switch (atkDecision)
        {
            case 1:
                attackOne();
                break;
            case 2:
                attackTwo();
                break;
            case 3:
                attackThree();
                break;
            case 4:
                attackFour();
                break;
        }
    }
}
