using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ColisaoCaraleo : MonoBehaviour
{

    BoxCollider2D colliderBox;
    RectTransform rect;
    // Start is called before the first frame update
    void Start()
    {
        colliderBox = GetComponent<BoxCollider2D>();
        rect = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        colliderBox.size = rect.rect.size;
        colliderBox.offset = rect.rect.position + rect.rect.size/2f;
    }
}
