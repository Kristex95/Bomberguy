using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ZIndex_Script : MonoBehaviour
{
    SpriteRenderer sr;
    public Canvas canvas;


    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        sr.sortingOrder = 10000 + -(int)(transform.position.y * 10);
        canvas.sortingOrder = 10000 + -(int)(transform.position.y * 10);
    }
}
