using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlight_Sprite_Script : MonoBehaviour
{

    bool active = false;
    SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.color = new Color(0.5f, 0.5f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
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
        active = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        active = false;
    }
}
