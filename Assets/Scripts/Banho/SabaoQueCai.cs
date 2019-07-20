using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SabaoQueCai : MonoBehaviour
{
    // Start is called before the first frame update
    public Collider2D destroyer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D collision){
        if(collision.collider == destroyer || collision.otherCollider == destroyer){
            Destroy(gameObject);
        }
    }
}
