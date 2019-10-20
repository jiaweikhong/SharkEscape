using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScroll : MonoBehaviour
{
    public float scroll_speed = 0.01f;
    private float y_Scroll;
    // Start is called before the first frame update
    void Start()
    {
        Scroll();
    }

    // Update is called once per frame
    void Update()
    {
        Scroll();
    }
    void Scroll()
    {
        y_Scroll = Time.time * scroll_speed;
        //Might have to edit this in the later part to smoothen scrolling of camera
        transform.position = new Vector3(transform.position.x, transform.position.y + y_Scroll, transform.position.z);

    }
}
