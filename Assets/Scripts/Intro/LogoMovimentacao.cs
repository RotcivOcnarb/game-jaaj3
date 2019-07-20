using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogoMovimentacao : MonoBehaviour
{

    public GameObject imagem;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        imagem.transform.localPosition = new Vector2(0, Mathf.Sin(Time.fixedTime*4)*.25f);
    }
}
