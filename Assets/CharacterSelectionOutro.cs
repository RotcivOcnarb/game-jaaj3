using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterSelectionOutro : MonoBehaviour
{
    public Image flash;
    float alpha = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        alpha += (0 - alpha) / 5f;
        flash.color = new Color(1, 1, 1, alpha);
    }

    public void ChangeScene(){
        SceneManager.LoadScene(2);
    }

    public void Flash(){
        alpha = 1;
    }
}
