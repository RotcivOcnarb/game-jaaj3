using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerContador : MonoBehaviour
{

    Text text;
    float timer = 120;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
        timer -= Time.deltaTime;

        int min = (int)(timer / 60);
        text.text =  min + ":" + (int)(timer - min*60);
    }
}
