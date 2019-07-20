using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChuvaGenerator : MonoBehaviour
{

    public Collider2D deleteGota;
    public RectTransform spawnArea;
    public GameObject gotaPrefab;

    public Animator cameraAnimator;

    public GameObject sabaoNaMao;
    public GameObject sabaoSaboneteira;

    public RectTransform registroArea;
    public GameObject pontaDaMao;

    public Camera myCamera;

    public float delay;
    float timer = 0;

    bool fall = false;

    // Start is called before the first frame update
    void Start()
    {
        Animator cameraTransition = GetComponent<Animator>();
        fall = false;

        cameraTransition.SetBool(0, true);

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer > delay && fall){
            timer -= delay;

            Vector3[] corners = new Vector3[4];

            spawnArea.GetWorldCorners(corners);

            Vector3 min = corners[0];
            Vector3 max = corners[2];

            Vector2 randomPos = new Vector2(Random.Range(min.x, max.x), Random.Range(min.y, max.y));

            GameObject instancedGota = Instantiate(gotaPrefab, randomPos, gotaPrefab.transform.rotation);
            instancedGota.transform.SetParent(transform, true);

            instancedGota.GetComponent<GotaDeleter>().deleterCollider = deleteGota;

        }

        Vector3[] registroCorners = new Vector3[4];

        registroArea.GetWorldCorners(registroCorners);

        Vector3 minA = registroCorners[0];
        Vector3 maxA = registroCorners[2];

        Rect r = new Rect(minA, maxA - minA);

        if (r.Contains(pontaDaMao.transform.position)) {
            Debug.Log("MouseEmCima do registro");
            if (Input.GetMouseButtonDown(0)) {
                Debug.Log("Mouse click registro");
                RegistroClick();
            }
        }


    }

    public void RegistroClick(){
        fall = true;
        cameraAnimator.SetBool("EndMinigame", true);
    }
}
