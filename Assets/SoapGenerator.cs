using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoapGenerator : MonoBehaviour
{

    public GameObject soapPrefab;
    public MaoBanho maoBanho;

    float timer;
    public float delay = .5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0) && maoBanho.holdingSoap){

            Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if(GetComponent<RectTransform>().rect.Contains(mouseWorld)){
                timer += Time.deltaTime;

                if(timer > delay){
                    timer -= delay;

                    GameObject go = Instantiate(soapPrefab, mouseWorld, soapPrefab.transform.rotation);
                    go.transform.SetParent(transform, false);
                    go.transform.position = mouseWorld;
                }
            }

        }
    }
}
