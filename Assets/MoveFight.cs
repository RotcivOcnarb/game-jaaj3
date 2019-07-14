using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFight : MonoBehaviour
{
    Rigidbody2D body;
    public Collider2D chao;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Z)){
            animator.SetBool("Punch", true);
            animator.SetBool("WalkingForward", false);
            animator.SetBool("WalkingBackward", false);
            body.velocity = new Vector2(0, body.velocity.y);
        }

        if(Input.GetKey(KeyCode.RightArrow))
        {
            if(!animator.GetBool("Punch")){
                body.velocity = new Vector2(10, body.velocity.y);
                animator.SetBool("WalkingForward", true);
                animator.SetBool("WalkingBackward", false);
            }
        }
        else if(Input.GetKey(KeyCode.LeftArrow))
        {
            if(!animator.GetBool("Punch")){
                body.velocity = new Vector2(-10, body.velocity.y);
                animator.SetBool("WalkingForward", false);
                animator.SetBool("WalkingBackward", true);
            }

        }
        else{
            body.velocity = new Vector2(body.velocity.x * 0.9f, body.velocity.y);
            animator.SetBool("WalkingForward", false);
            animator.SetBool("WalkingBackward", false);
        }
        if(Input.GetKeyDown(KeyCode.UpArrow) && body.IsTouching(chao))
        {
            body.AddForce(new Vector2(0,20),ForceMode2D.Impulse);
        }
    }

    public void PunchFinish(){
        animator.SetBool("Punch", false);
    }
    
}
