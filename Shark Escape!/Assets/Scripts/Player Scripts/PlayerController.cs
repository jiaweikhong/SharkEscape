using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    public float charSpeed = 5f;    // f for float
    public float min_Y = -9.37f;
    public float max_Y = 320f;
    public float min_X = -17.35f;
    public float max_X = 10.52f;
    public int health = 100;
    public float current_Invin_Timer;
    public float invin_Time = 1.5f;
    public bool canBeDamaged;

    [SerializeField]
    private GameObject player_Torpedo;

    [SerializeField]
    private GameObject player_Laser;

    [SerializeField]
    private Transform attack_Point;

    public float attack_Timer = 0.35f;
    private float current_Attack_Timer;
    private bool canAttack;

    public static float bullet_X = 0f;
    public static float bullet_Y = 1f;
    public float torpedo_turn_rate = 0.01f;

    public static int torpedo_level = 1;
    public static int laser_level = 1;

    // Start is called before the first frame update
    void Start()
    {
        current_Attack_Timer = attack_Timer;
    }

    // Update is called once per frame
    void Update()
    {
        KeepSubInView();
        MoveSubmarine();
        MoveTorpedoAngle();
        Attack();
        HandleInvincibility();
    }

    void MoveSubmarine()
    {
        if (Input.GetAxisRaw("Vertical") > 0f)
        {
            Vector3 temp = transform.position;
            temp.y += charSpeed * Time.deltaTime;
            if (temp.y > max_Y)
            {
                temp.y = max_Y;
            }
            transform.position = temp;
        }
        else if (Input.GetAxisRaw("Vertical") < 0f)
        {
            Vector3 temp = transform.position;
            temp.y -= charSpeed * Time.deltaTime;
            if (temp.y < min_Y)
            {
                temp.y = min_Y;
            }
            transform.position = temp;
        }
        else if (Input.GetAxisRaw("Horizontal") > 0f)
        {
            Vector3 temp = transform.position;
            temp.x += charSpeed * Time.deltaTime;
            if (temp.x > max_X)
            {
                temp.x = max_X;
            }
            transform.position = temp;
        }
        else if (Input.GetAxisRaw("Horizontal") < 0f)
        {
            Vector3 temp = transform.position;
            temp.x -= charSpeed * Time.deltaTime;
            if (temp.x < min_X)
            {
                temp.x = min_X;
            }
            transform.position = temp;
        }
    }   // move submarine

    void Attack() {
        
        attack_Timer += Time.deltaTime;
        if (attack_Timer > current_Attack_Timer) {
            canAttack = true;
        }

        // GetKey is for holding down button. GetKeyDown is for pressing once.
        if (Input.GetKey(KeyCode.W)) {
            if (canAttack) {
                canAttack = false;
                attack_Timer = 0f;
                Instantiate (player_Torpedo, attack_Point.position, Quaternion.identity);
                // play the sound FX
            }
        }
        else if (Input.GetKey(KeyCode.S))
        {
            if (canAttack)
            {
                canAttack = false;
                attack_Timer = 0f;
                Instantiate(player_Laser, attack_Point.position, Quaternion.identity);
                // play the sound FX
            }
        }
    }   // attack

    void MoveTorpedoAngle() {
        if (Input.GetKey(KeyCode.A)) {
            if (bullet_X >= 0 & bullet_Y >= 0) {
                bullet_X -= torpedo_turn_rate;
                bullet_Y += torpedo_turn_rate;
            }
            else if (bullet_X <= 0 & bullet_Y >= 0) {
                bullet_X -= torpedo_turn_rate;
                bullet_Y -= torpedo_turn_rate;
            }
            else if (bullet_X <= 0 & bullet_Y <= 0) {
                bullet_X += torpedo_turn_rate;
                bullet_Y -= torpedo_turn_rate;
            }
            else if (bullet_X >= 0 & bullet_Y <= 0) {
                bullet_X += torpedo_turn_rate;
                bullet_Y += torpedo_turn_rate;
            }
        }
        else if (Input.GetKey(KeyCode.D)) {
            if (bullet_X >= 0 & bullet_Y >= 0) {
                bullet_X += torpedo_turn_rate;
                bullet_Y -= torpedo_turn_rate;
            }
            else if (bullet_X <= 0 & bullet_Y >= 0) {
                bullet_X += torpedo_turn_rate;
                bullet_Y += torpedo_turn_rate;
            }
            else if (bullet_X <= 0 & bullet_Y <= 0) {
                bullet_X -= torpedo_turn_rate;
                bullet_Y += torpedo_turn_rate;
            }
            else if (bullet_X >= 0 & bullet_Y <= 0) {
                bullet_X -= torpedo_turn_rate;
                bullet_Y -= torpedo_turn_rate;
            }
        }
    }   // move torpedo angle

    void TorpedoLevelUp()
    {
        torpedo_level += 1;
        TorpLvManager.torpLevel += 1;
    }

    void LaserLevelUp()
    {
        laser_level += 1;
        LaserLvManager.laserLevel += 1;
    }
    void checkHealth()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
            // Debug.Log("you died");
            SceneManager.LoadScene(2);
        }
    }   // check current health. if <0, destroy

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Laser_powerup")
        {
            LaserLevelUp();
            Debug.Log("Obtained Laser powerup!");
        }
        else if (collision.tag == "Torp_powerup")
        {
            TorpedoLevelUp();
            Debug.Log("Obtained Torpedo powerup!");
        }
        else if (collision.tag == "Enemy")
        {
            if (canBeDamaged)
            {
                canBeDamaged = false;
                current_Invin_Timer = 0f;
                var damageTaken = 10;
                health -= damageTaken;
                checkHealth();
                HealthManager.health -= damageTaken;
            }
        }
    }   // if sub touches enemy, receive 10 damage

    private void HandleInvincibility()
    {
        current_Invin_Timer += Time.deltaTime;
        if (current_Invin_Timer > invin_Time)
        {
            canBeDamaged = true;
        }
    }   // ensures i-frame after being hit

    private void KeepSubInView()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        pos.x = Mathf.Clamp01(pos.x);
        pos.y = Mathf.Clamp(pos.y, 0.038f, 1f);
        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }

}   // class
