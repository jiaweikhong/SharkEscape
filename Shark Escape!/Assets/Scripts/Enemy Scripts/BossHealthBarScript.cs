using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealthBarScript : MonoBehaviour
{
    private Transform bar;

    // Start is called before the first frame update
    private void Start()
    {
        //Transform bar = transform.Find("Bar");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetSize(float sizeNormalized)
    {
        Debug.Log("Before local scale step ");
    }
}
