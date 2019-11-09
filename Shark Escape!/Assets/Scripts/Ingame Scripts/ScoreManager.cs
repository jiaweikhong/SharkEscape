using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreManager : MonoBehaviour
{
    public static int score;
    TextMeshProUGUI text;

    void Awake()
    {
        text = GetComponent <TextMeshProUGUI> ();
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = score.ToString();
    }
}
