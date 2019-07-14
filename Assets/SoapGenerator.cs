using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoapGenerator : MonoBehaviour
{

    public GameObject soapPrefab;
    public MaoBanho maoBanho;
    RectTransform area;
    public Camera myCam;
    public Camera renderCam;
    public static bool banhoFinished;
    int bolhas = 0;
    float timer;
    public float delay = .5f;
    // Start is called before the first frame update
    void Start()
    {
        area = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = myCam.ScreenToWorldPoint(Input.mousePosition);
        float mpx = mousePosition.x;
        float mpy = mousePosition.y;

        Vector3[] corners = new Vector3[4];
        area.GetWorldCorners(corners);

        Rect reer = new Rect(corners[0].x, corners[0].y, corners[2].x - corners[0].x, corners[2].y - corners[0].y);

        if (Input.GetMouseButton(0) && maoBanho.holdingSoap && bolhas <= 50 && reer.Contains(new Vector2(mpx, mpy)))
        {
            timer += Time.deltaTime;
            if(timer > delay){
                timer -= delay;

                GameObject go = Instantiate(soapPrefab, mousePosition, soapPrefab.transform.rotation);
                go.transform.SetParent(transform, false);
                go.transform.localScale = go.transform.localScale * 1f;
                go.transform.position = mousePosition;
                bolhas++; 
            }
        }
        if (bolhas > 5)
        {
            Animator cameraTransition = renderCam.gameObject.GetComponent<Animator>();
            cameraTransition.SetBool("Banho2", true);
        }
    }
}
