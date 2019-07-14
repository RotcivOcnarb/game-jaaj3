using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFight : MonoBehaviour
{
    Rigidbody2D body;
    public Collider2D chao;
    Animator animator;
    public static bool canTransitionOut;

    CircleCollider2D circleHand;

    public GameObject enemyObject;

    public CapsuleCollider2D enemyCollider;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        circleHand = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Z) && !animator.GetBool("Jump") && !animator.GetBool("SePegando")){
            animator.SetBool("Punch", true);
            animator.SetBool("WalkingForward", false);
            animator.SetBool("WalkingBackward", false);
            body.velocity = new Vector2(0, body.velocity.y);
        }

        if(Input.GetKey(KeyCode.RightArrow) && !animator.GetBool("SePegando"))
        {
            if(!animator.GetBool("Punch")){
                body.velocity = new Vector2(10, body.velocity.y);
                animator.SetBool("WalkingForward", true);
                animator.SetBool("WalkingBackward", false);
            }
        }
        else if(Input.GetKey(KeyCode.LeftArrow) && !animator.GetBool("SePegando"))
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
        if(Input.GetKeyDown(KeyCode.UpArrow) && body.IsTouching(chao) && !animator.GetBool("SePegando"))
        {
            body.AddForce(new Vector2(0,20),ForceMode2D.Impulse);
            
        }

        animator.SetBool("Jump", !body.IsTouching(chao));

        if(maoNoCara && animator.GetBool("Punch")){
            enemyObject.SetActive(false);
            animator.SetBool("SePegando", true);
            canTransitionOut = true;
        }

    }

    public void PunchFinish(){
        animator.SetBool("Punch", false);
    }

    bool maoNoCara;

    public void OnTriggerEnter2D(Collider2D collider){
        if(collider == enemyCollider){
            maoNoCara = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collider){
        if(collider == enemyCollider){
            maoNoCara = false;
        }
    }
    
}
