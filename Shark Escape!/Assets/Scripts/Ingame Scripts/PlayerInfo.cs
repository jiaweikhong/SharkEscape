using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public float scroll_speed = 0.01f;
    private float y_Scroll;

    // Update is called once per frame
    void Update()
    {
        Scroll();
    }
    void Scroll()
    {
        y_Scroll = scroll_speed;
        transform.position = new Vector3(transform.position.x, transform.position.y + y_Scroll, transform.position.z);
    }   // for scrolling the blue bar together with the camera.
}
