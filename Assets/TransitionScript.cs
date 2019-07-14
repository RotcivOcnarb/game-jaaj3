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
            sombraAnimator.SetInteger("SombraState", 1);
            controleAnimator.SetBool("ChangeChannel", true);
        }
    }
}
