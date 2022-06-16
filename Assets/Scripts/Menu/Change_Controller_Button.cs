using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Change_Controller_Button : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && collision.gameObject.GetComponent<Bomber_Movement_Script>().confirm)
        {
            collision.gameObject.GetComponent<Bomber_Skin_Select>().NextOption();
        }
    }
}
