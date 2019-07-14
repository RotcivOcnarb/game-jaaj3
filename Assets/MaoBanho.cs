using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaoBanho : MonoBehaviour
{

    public Sprite maoAberta;
    public Sprite maoFechada;
    public Camera thiscamera;
    public GameObject sabaoNaMao;

    public bool holdingSoap;

    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        holdingSoap = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        transform.position = new Vector3(mousePosition.x, mousePosition.y, 0);

        
        spriteRenderer.sprite = Input.GetMouseButton(0) ? maoFechada : maoAberta;
        spriteRenderer.size = new Vector2(transform.position.x*2 + 20, 5);

        if(sabaoNaMao != null && sabaoNaMao.activeSelf && sabaoNaMao.transform.root == this.transform){
            holdingSoap = true;
        }

        if(Input.GetMouseButtonUp(0)){
            //Solta o sabão
            if(sabaoNaMao != null && sabaoNaMao.activeSelf && sabaoNaMao.transform.root == this.transform){
                sabaoNaMao.AddComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                sabaoNaMao.transform.parent.DetachChildren();
                holdingSoap = false;
            }
        }

    }
}
