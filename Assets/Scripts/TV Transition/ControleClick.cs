using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleClick : MonoBehaviour
{
    public Animator noiseAnimator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickControle(){
        noiseAnimator.SetBool("NoiseOn", true);
    }
}
