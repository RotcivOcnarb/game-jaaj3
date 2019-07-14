using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionCharacter : MonoBehaviour
{

    public Vector2 localPos1;
    public Vector2 localPos2;
    public Vector2 localPos3;
    public Vector2 localPos4;
    Vector2 selectedPos;
    Vector2 posTween;

    public Image marcelo;
    public Image luisMauricio;
    public Image takaroNomuro;
    public Image mikoMeu;

    public Animator animator;

    public SpriteRenderer bigImage;

    public CharacterSelectionOutro charsel;

    // Start is called before the first frame update
    void Start()
    {
        posTween = transform.localPosition;
        selectedPos = localPos1;
        bigImage.sprite = marcelo.sprite;
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Return) && selectedPos == localPos1 && !animator.GetBool("Outro")){
            animator.SetBool("Outro", true);
            charsel.Flash();
        }

        posTween += (selectedPos - posTween) / 2f;

        bigImage.transform.localPosition = bigImage.transform.localPosition +
            (new Vector3(0, 0, 1) - bigImage.transform.localPosition)/5f;

        if(!animator.GetBool("Outro")){
            if(Input.GetKeyDown(KeyCode.UpArrow)){
                if(selectedPos == localPos3){
                    selectedPos = localPos1;
                    bigImage.sprite = marcelo.sprite;
                    bigImage.color = marcelo.color;
                    bigImage.transform.localPosition = new Vector3(0, -5, 1);
                }

                if(selectedPos == localPos4){
                    selectedPos = localPos2;
                    bigImage.sprite = luisMauricio.sprite;
                    bigImage.color = luisMauricio.color;
                    bigImage.transform.localPosition = new Vector3(0, -5, 1);
                }
            }

            if(Input.GetKeyDown(KeyCode.DownArrow)){
                if(selectedPos == localPos1){
                    selectedPos = localPos3;
                    bigImage.sprite = takaroNomuro.sprite;
                    bigImage.color = takaroNomuro.color;
                    bigImage.transform.localPosition = new Vector3(0, -5, 1);
                }

                if(selectedPos == localPos2){
                    selectedPos = localPos4;
                    bigImage.sprite = mikoMeu.sprite;
                    bigImage.color = mikoMeu.color;
                    bigImage.transform.localPosition = new Vector3(0, -5, 1);
                }
            }

            if(Input.GetKeyDown(KeyCode.LeftArrow)){
                if(selectedPos == localPos2){
                    selectedPos = localPos1;
                    bigImage.sprite = marcelo.sprite;
                    bigImage.color = marcelo.color;
                    bigImage.transform.localPosition = new Vector3(0, -5, 1);
                }

                if(selectedPos == localPos4){
                    selectedPos = localPos3;
                    bigImage.sprite = takaroNomuro.sprite;
                    bigImage.color = takaroNomuro.color;
                    bigImage.transform.localPosition = new Vector3(0, -5, 1);
                }
            }
            if(Input.GetKeyDown(KeyCode.RightArrow)){
                if(selectedPos == localPos1){
                    selectedPos = localPos2;
                    bigImage.sprite = luisMauricio.sprite;
                    bigImage.color = luisMauricio.color;
                    bigImage.transform.localPosition = new Vector3(0, -5, 1);
                }

                if(selectedPos == localPos3){
                    selectedPos = localPos4;
                    bigImage.sprite = mikoMeu.sprite;
                    bigImage.color = mikoMeu.color;
                    bigImage.transform.localPosition = new Vector3(0, -5, 1);
                }
            }
        }

        transform.localPosition = posTween;
    }

}
