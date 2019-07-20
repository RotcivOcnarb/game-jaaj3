using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanhoCameraTextureRenderer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FinishMinigame(){
        SoapGenerator.banhoFinished = true;
        Debug.Log("TERMINOU O MINGAME DO BANHO");
    }
}
