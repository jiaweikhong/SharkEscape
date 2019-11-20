using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MobsForBossScript : MonoBehaviour
{
    public bool isActive = false;
    void Start()
    {
        gameObject.SetActive(false);
    }

    void Update()
    {
        if (isActive == true)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
;