using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandelabroScript : MonoBehaviour
{
    public PersonagemGarotinha garotinha;
    bool jacaiu;
    public static bool canTransition;
    public Sprite[] pecas;
    // Start is called before the first frame update
    void Start()
    {
        jacaiu = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = mergeVectors(transform.position, garotinha.transform.position, 1, 0, 0);
    }

    public void Cai(){
        if(!jacaiu){
            gameObject.AddComponent<CircleCollider2D>();//.isTrigger = true;
            gameObject.AddComponent<Rigidbody2D>();
            jacaiu = true;
        }
    }

    Vector3 mergeVectors(Vector3 a, Vector3 b, float x, float y, float z){
        return new Vector3(
            Mathf.Lerp(a.x, b.x, x),
            Mathf.Lerp(a.y, b.y, y),
            Mathf.Lerp(a.z, b.z, z)
        );
    }

    public void OnCollisionEnter2D(Collision2D collision){
        if(collision.collider.gameObject == garotinha.gameObject || collision.otherCollider.gameObject == garotinha.gameObject){
            
            Debug.Log("ENCOSTROU");

            foreach(Sprite s in pecas){

                GameObject g = new GameObject();
                g.AddComponent<SpriteRenderer>().sprite = s;
                g.transform.position = transform.position;
                g.AddComponent<CircleCollider2D>();
                g.AddComponent<Rigidbody2D>().AddForce(Random.insideUnitCircle *10, ForceMode2D.Impulse);
                g.layer = 9;


            }
            garotinha.GetComponent<Animator>().SetTrigger("Morreu");
            //Destroy(garotinha.GetComponent<Rigidbody2D>());
            //Destroy(garotinha.GetComponent<CapsuleCollider2D>());

            Destroy(gameObject);
            canTransition = true;

        }
    }
}
