using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ready_Field_Script : MonoBehaviour
{
    private BoxCollider2D boxColl;
    public bool isReady = false;
    // Start is called before the first frame update
    void Awake()
    {
        boxColl = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
