using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonagemGarotinha : MonoBehaviour
{
    Rigidbody2D body;
    public Collider2D[] chaos;
    Animator animator;
    bool vivo = true;
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
        Camera.main.transform.position = Camera.main.transform.position + 
            (transform.position - Camera.main.transform.position) / 10f;

        Vector3 newPos = Camera.main.transform.position;

        newPos.z = -10;
        newPos.y = 0;
        if(Camera.main.transform.position.x < 0){
            newPos.x = 0;
        }
        if(Camera.main.transform.position.x > 9){
            newPos.x = 9;
        }

        Camera.main.transform.position = newPos;

         if(Input.GetKey(KeyCode.RightArrow) && vivo && !noChao)
        {
            body.velocity = new Vector2(10, body.velocity.y);
        }
        else if(Input.GetKey(KeyCode.LeftArrow) && vivo && !noChao)
        {
            body.velocity = new Vector2(-10, body.velocity.y);
        }
        else{
            body.velocity = new Vector2(body.velocity.x * 0.9f, body.velocity.y);
        }
        if (body.IsTouching(chaos[3]))
        {
            vivo = false;
            animator.SetBool("Morreu",true);
            Debug.Log("Yay, era pra rodar a anim do candelabro");
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
            Debug.Log("era pra pular, mas acho que não ta saindo");
        }
        else
        {
            animator.SetBool("PuloBoneca",false);
        }
    }
}
