using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;    // f for float
    public float min_Y, max_Y, min_X, max_X;

    [SerializeField]
    private GameObject player_Torpedo;

    [SerializeField]
    private Transform attack_Point;

    public float attack_Timer = 0.35f;
    private float current_Attack_Timer;
    private bool canAttack;

    public static float torpedo_X = 0f;
    public static float torpedo_Y = 1f;
    public float torpedo_turn_rate;

    // Start is called before the first frame update
    void Start()
    {
        current_Attack_Timer = attack_Timer;
    }

    // Update is called once per frame
    void Update()
    {
        MoveSubmarine();
        MoveTorpedoAngle();
        Attack();
    }

    void MoveSubmarine()
    {
        if (Input.GetAxisRaw("Vertical") > 0f)
        {
            Vector3 temp = transform.position;
            temp.y += speed * Time.deltaTime;
            if (temp.y > max_Y)
            {
                temp.y = max_Y;
            }
            transform.position = temp;
        }
        else if (Input.GetAxisRaw("Vertical") < 0f)
        {
            Vector3 temp = transform.position;
            temp.y -= speed * Time.deltaTime;
            if (temp.y < min_Y)
            {
                temp.y = min_Y;
            }
            transform.position = temp;
        }
        else if (Input.GetAxisRaw("Horizontal") > 0f)
        {
            Vector3 temp = transform.position;
            temp.x += speed * Time.deltaTime;
            if (temp.x > max_X)
            {
                temp.x = max_X;
            }
            transform.position = temp;
        }
        else if (Input.GetAxisRaw("Horizontal") < 0f)
        {
            Vector3 temp = transform.position;
            temp.x -= speed * Time.deltaTime;
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
    }   // attack

    void MoveTorpedoAngle() {
        if (Input.GetKey(KeyCode.A)) {
            if (torpedo_X >= 0 & torpedo_Y >= 0) {
                torpedo_X -= torpedo_turn_rate;
                torpedo_Y += torpedo_turn_rate;
            }
            else if (torpedo_X <= 0 & torpedo_Y >= 0) {
                torpedo_X -= torpedo_turn_rate;
                torpedo_Y -= torpedo_turn_rate;
            }
            else if (torpedo_X <= 0 & torpedo_Y <= 0) {
                torpedo_X += torpedo_turn_rate;
                torpedo_Y -= torpedo_turn_rate;
            }
            else if (torpedo_X >= 0 & torpedo_Y <= 0) {
                torpedo_X += torpedo_turn_rate;
                torpedo_Y += torpedo_turn_rate;
            }
        }
        else if (Input.GetKey(KeyCode.D)) {
            if (torpedo_X >= 0 & torpedo_Y >= 0) {
                torpedo_X += torpedo_turn_rate;
                torpedo_Y -= torpedo_turn_rate;
            }
            else if (torpedo_X <= 0 & torpedo_Y >= 0) {
                torpedo_X += torpedo_turn_rate;
                torpedo_Y += torpedo_turn_rate;
            }
            else if (torpedo_X <= 0 & torpedo_Y <= 0) {
                torpedo_X -= torpedo_turn_rate;
                torpedo_Y += torpedo_turn_rate;
            }
            else if (torpedo_X >= 0 & torpedo_Y <= 0) {
                torpedo_X -= torpedo_turn_rate;
                torpedo_Y -= torpedo_turn_rate;
            }
        }
    }   // move torpedo angle

}   // class
