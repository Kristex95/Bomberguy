using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ready_Field_Script : MonoBehaviour
{
    private BoxCollider2D boxColl;
    private SpriteRenderer sr;
    public bool isReady = false;
    // Start is called before the first frame update
    void Awake()
    {
        boxColl = GetComponent<BoxCollider2D>();
        sr = GetComponentInChildren<SpriteRenderer>();

        sr.color = new Color(0.5f, 0.5f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (isReady)
        {
            sr.color = new Color(1, 1, 1);
        }
        else
        {
            sr.color = new Color(0.5f, 0.5f, 0.5f);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isReady = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isReady = false;
        }
    }
}
