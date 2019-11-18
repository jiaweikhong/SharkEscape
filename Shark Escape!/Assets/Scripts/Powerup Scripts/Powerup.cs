using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    public AudioSource powerupSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(powerupSound.clip, transform.position);
            Destroy(gameObject, powerupSound.clip.length);
        }
    }   // destroy powerup when collide
}
