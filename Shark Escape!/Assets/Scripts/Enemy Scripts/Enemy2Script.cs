using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Script : MonoBehaviour
{
    // variables from static database
    public float health = StatDatabase.enemy2_health;
    public int points = StatDatabase.enemy2_points;
    public float attack_Timer = StatDatabase.enemy2_attack_timer;

    // variables
    private float current_Attack_Timer;
    private bool canAttack;
    private bool deathAnimating;

    // objects
    private CamShake shake;
    public Animator animator;
    public AudioSource deathSound;
    public Transform attack_Point;
    public GameObject enemy2_bullet;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<CamShake>();
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    void Attack()
    {
        attack_Timer += Time.deltaTime;
        if (attack_Timer > current_Attack_Timer)
        {
            canAttack = true;
        }
        if (deathAnimating == false && canAttack == true)
        {
            attack_Timer = 0f;
            Instantiate(enemy2_bullet, attack_Point.position, Quaternion.identity);
        }
    }

    void CheckHealth()
    {
        if (health <= 0 && deathAnimating == false)
        {
            StartCoroutine(Death());
        }
    }   // check current health. if <0, destroy

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("LaserBullet"))
        {
            var damagetaken = collision.gameObject.GetComponent<LaserScript>().damage;
            health -= damagetaken;
            CheckHealth();
            StartCoroutine(GetHitAnimate());
        }
        else if (collision.CompareTag("TorpBullet"))
        {
            var damagetaken = collision.gameObject.GetComponent<TorpedoScript>().damage;
            health -= damagetaken;
            CheckHealth();
            StartCoroutine(GetHitAnimate());
        }
    }   // apply collision logic with bullet

    IEnumerator Death()
    {
        ScoreManager.score += points;
        shake.CameraShake();
        deathAnimating = true;
        transform.gameObject.tag = "DyingEnemy";
        animator.SetBool("isAlive", false);
        AudioSource.PlayClipAtPoint(deathSound.clip, transform.position.normalized, 1.0f);
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }

    IEnumerator GetHitAnimate()
    {
        animator.SetBool("isHit", true);
        yield return new WaitForSeconds(0.1f);
        animator.SetBool("isHit", false);
    }
}
