using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMov : MonoBehaviour
{
    Rigidbody2D body;
    public Collider2D chao;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            body.velocity = new Vector2(10, body.velocity.y);
        }
        else if(Input.GetKey(KeyCode.RightArrow))
        {
            body.velocity = new Vector2(-10, body.velocity.y);
        }
        else{
            body.velocity = new Vector2(body.velocity.x * 0.9f, body.velocity.y);
        }
        if(Input.GetKeyDown(KeyCode.UpArrow) && body.IsTouching(chao))
        {
            body.AddForce(new Vector2(0,20),ForceMode2D.Impulse);
        }
    }

    
}