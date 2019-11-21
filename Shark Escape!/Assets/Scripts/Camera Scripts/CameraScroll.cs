using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScroll : MonoBehaviour
{
    public float scroll_speed = StatDatabase.map_scrollspeed;
    private float y_Scroll;
    private bool bossBGM = false;
    public AudioSource bgm1;
    public AudioSource bgm2;

    // Start is called before the first frame update
    void Start()
    {
        AudioSource.PlayClipAtPoint(bgm1.clip, transform.position, 0.1f);
        //Scroll();
    }

    // Update is called once per frame
    void Update()
    {
        Scroll();
        PlayBossBGM();
    }

    void Scroll()
    {
        y_Scroll = scroll_speed;
        //Might have to edit this in the later part to smoothen scrolling of camera
        transform.position = new Vector3(transform.position.x, transform.position.y + y_Scroll, transform.position.z);
    }

    void PlayBossBGM()
    {
        if (scroll_speed == 0f && bossBGM == false)
        {
            AudioSource.PlayClipAtPoint(bgm2.clip, transform.position, 0.1f);
            bossBGM = true;
        }
    }
}
