using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameScript : MonoBehaviour
{
    public float scroll_speed = StatDatabase.map_scrollspeed;
    private float y_Scroll;
    public GameObject mainCam;

    // Update is called once per frame
    void Update()
    {
        Scroll();
    }
    void Scroll()
    {
        y_Scroll = scroll_speed;
        transform.position = new Vector3(transform.position.x, transform.position.y + y_Scroll, transform.position.z);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Frame"))
        {
            scroll_speed = 0f;
            mainCam.GetComponent<CameraScroll>().scroll_speed = 0f;
            Debug.Log("Reached end of map");
        }
    }   // stops camera when end of map
}
