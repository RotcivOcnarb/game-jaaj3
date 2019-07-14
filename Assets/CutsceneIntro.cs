using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneIntro : MonoBehaviour
{
    // Start is called before the first frame update
    Animator animator;
    AudioSource source;
    void Start()
    {
        animator = GetComponent<Animator>();
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return) && !animator.GetBool("Outro")){
            animator.SetBool("Outro", true);
            source.Play();
        }
    }

    void ChangeScene(){
        SceneManager.LoadScene(1);
    }
}
