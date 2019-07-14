using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoapGenerator : MonoBehaviour
{

    public GameObject soapPrefab;
    public MaoBanho maoBanho;
    public Rect aaaa;
    int bolhas = 0;
    float timer;
    public float delay = .5f;
    // Start is called before the first frame update
    void Start()
    {
        aaaa = GetComponent<Rect>();

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float mpx = mousePosition.x;
        float mpy = mousePosition.y;
        if (Input.GetMouseButton(0) && maoBanho.holdingSoap && bolhas <= 50 && mpx > aaaa.x - 1000 && mpx < aaaa.x  && mpy > aaaa.y - 650 && mpy < aaaa.y + 100)
        {

            Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if(GetComponent<RectTransform>().rect.Contains(mouseWorld))
            {
                timer += Time.deltaTime;

                if(timer > delay){
                    timer -= delay;

                    GameObject go = Instantiate(soapPrefab, mouseWorld, soapPrefab.transform.rotation);
                    go.transform.SetParent(transform, false);
                    go.transform.position = mouseWorld;
                    bolhas++; 
                }

            }

        }
        if (bolhas > 5)
        {
            Animator cameraTransition = Camera.main.GetComponent<Animator>();
            cameraTransition.SetBool("Banho2", true);
        }
    }
}
