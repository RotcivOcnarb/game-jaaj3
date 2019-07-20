using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SabaoClickUI : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject sabaoNaMao;
    public Animator cameraAnimator;
    public GameObject pontaDaMao;
    RectTransform rect;
    void Start()
    {
        rect = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3[] corners = new Vector3[4];

        rect.GetWorldCorners(corners);

        Vector3 minA = corners[0];
        Vector3 maxA = corners[2];

        Rect r = new Rect(minA, maxA - minA);

        if (r.Contains(pontaDaMao.transform.position)) {
            Debug.Log("MouseEmCima do registro");
            if (Input.GetMouseButtonDown(0)) {
                Debug.Log("Mouse click registro");
                PointerDown();
            }
        }
    }

    public void PointerDown(){
        
        if(cameraAnimator.GetBool("EndMinigame")){
            gameObject.SetActive(false);
            sabaoNaMao.SetActive(true);
        }
    }

}
