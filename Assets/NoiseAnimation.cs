using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NoiseAnimation : MonoBehaviour
{

    
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    int sceneIndex = 3;
    public void SetNoiseOff(){
        animator.SetBool("NoiseOn", false);
        SceneManager.UnloadSceneAsync(sceneIndex);
        SceneManager.LoadScene(sceneIndex+1, LoadSceneMode.Additive);
        sceneIndex++;
    }
}
