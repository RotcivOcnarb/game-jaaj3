using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonagemGarotinha : MonoBehaviour
{
    Rigidbody2D body;
    public Collider2D[] chaos;
    Animator animator;
    bool vivo = true;

    public Camera mainCamera;

    public CandelabroScript candelabro;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
    bool noChao = false;
    for(int i = 0; i < chaos.Length; i ++){
            if(body.IsTouching(chaos[i])){
                noChao = true;
                break;
            }
        }
        mainCamera.transform.position = mainCamera.transform.position + 
            (transform.position - mainCamera.transform.position) / 10f;

        Vector3 newPos = mainCamera.transform.position;

        newPos.z = -10;
        newPos.y = 0;
        if(mainCamera.transform.position.x < 0){
            newPos.x = 0;
        }
        if(mainCamera.transform.position.x > 9){
            newPos.x = 9;
        }

        mainCamera.transform.position = newPos;

         if(Input.GetKey(KeyCode.RightArrow) && vivo)
        {
            body.velocity = new Vector2(10, body.velocity.y);
        }
        else if(Input.GetKey(KeyCode.LeftArrow) && vivo)
        {
            body.velocity = new Vector2(-10, body.velocity.y);
        }
        else{
            body.velocity = new Vector2(body.velocity.x * 0.9f, body.velocity.y);
        }
        if (body.IsTouching(chaos[3]))
        {
            vivo = false;
            candelabro.Cai();
        }
        for(int i = 0; i < chaos.Length; i ++){
            if(body.IsTouching(chaos[i])){
                noChao = true;
                break;
            }
        }

        if(Input.GetKeyDown(KeyCode.UpArrow) && noChao && vivo)
        {
            body.AddForce(new Vector2(0,20),ForceMode2D.Impulse);
        }
        if(vivo && !noChao){
            animator.SetBool("PuloBoneca",true);
        }
        else
        {
            animator.SetBool("PuloBoneca",false);
        }
    }
}
