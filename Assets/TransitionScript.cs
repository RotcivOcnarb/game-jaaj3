using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionScript : MonoBehaviour
{

    Animator animator;
    public Animator sombraAnimator;
    public Animator controleAnimator;
    public Animator noiseAnimator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        //CARREGA AS OUTRAS CENAS
        SceneManager.LoadScene(3, LoadSceneMode.Additive);
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("ZoomOut", MoveFight.canTransitionOut);

        if(MoveFight.canTransitionOut){
            MoveFight.canTransitionOut = false;
            sombraAnimator.SetInteger("SombraState", 1);
            controleAnimator.SetTrigger("ChangeChannel");
            Debug.Log("ai chaves");
        }

        if(SoapGenerator.banhoFinished){
            SoapGenerator.banhoFinished = false;
            animator.SetTrigger("ZoomLava");
            controleAnimator.SetTrigger("ChangeChannel");
            Debug.Log("Triggerando loja");
        }
    }

    public void ZoomInEnd(){

        /*
        GameObject camgo = GameObject.FindGameObjectWithTag("CameraQueEuQuero");
        if(camgo){
            Camera.main.enabled = false;
            camgo.GetComponent<Camera>().enabled = true;
        }
        */
    }
}
