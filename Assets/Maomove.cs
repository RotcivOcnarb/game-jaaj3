using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maomove : MonoBehaviour
{
    Rigidbody2D maoBody;
    // Start is called before the first frame update
    void Start()
    {
        maoBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mp = new Vector2(mousePosition.x, mousePosition.y);

        maoBody.AddForce(
            (mp - maoBody.position) * 0.1f, ForceMode2D.Impulse
            );

        //transform.position = new Vector3(mousePosition.x, mousePosition.y, 0);
    }
}
