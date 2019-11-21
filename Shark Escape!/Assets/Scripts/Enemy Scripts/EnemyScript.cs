using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{
    public float health = StatDatabase.enemy1_health;
    public int points = StatDatabase.enemy1_points;
    public int touchdamage = StatDatabase.enemy1_touchdamage;
    public float speed = StatDatabase.enemy1_speed;

    private bool dirRight = true;
    private Vector3 leftBound;
    private Vector3 rightBound;
    private bool deathAnimating;
    private CamShake shake;

    public AudioSource deathSound;
    public Animator animator;

    void Awake()
    {
        
    }

    void Start(){
        leftBound = new Vector3(-4 + transform.position.x, transform.position.y, transform.position.z);
        rightBound = new Vector3(4 + transform.position.x, transform.position.y, transform.position.z);
        animator = GetComponent<Animator>();
        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<CamShake>();
    }
    // Update is called once per frame
    void Update(){
        Move();
    }

    void Move(){
        if (deathAnimating == false)
        {
            transform.position = Vector3.Lerp(leftBound, rightBound, (Mathf.Sin(speed * Time.time) + 1.0f) / 2.0f);
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
