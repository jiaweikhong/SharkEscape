using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthManager : MonoBehaviour
{
    public static int health;
    TextMeshProUGUI text;

    // Start is called before the first frame update
    void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
        health = StatDatabase.player_max_health;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Health: " + health;
    }
}
