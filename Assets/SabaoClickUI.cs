using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SabaoClickUI : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject sabaoNaMao;
    public Animator cameraAnimator;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PointerDown(){
        
        if(cameraAnimator.GetBool("EndMinigame")){
            gameObject.SetActive(false);
            sabaoNaMao.SetActive(true);
        }
    }

}
