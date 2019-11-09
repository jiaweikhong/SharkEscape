using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class LaserLvManager : MonoBehaviour
{
    public static int laserLevel;
    TextMeshProUGUI text;

    // Start is called before the first frame update
    void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
        laserLevel = 1;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Laser Lv: " + laserLevel;
    }
}
