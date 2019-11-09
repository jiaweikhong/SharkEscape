using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TorpLvManager : MonoBehaviour
{
    public static int torpLevel;
    TextMeshProUGUI text;

    // Start is called before the first frame update
    void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
        torpLevel = 1;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Torp Lv: " + torpLevel;
    }
}
