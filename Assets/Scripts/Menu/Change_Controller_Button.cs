using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Change_Controller_Button : MonoBehaviour
{
    public bool collided = false;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if(player.GetComponent<Bomber_Movement_Script>().confirm)
            player.GetComponent<Bomber_Skin_Select>().NextOption();*/
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*if(collision.gameObject.tag == "Player")
        {
            collided = true;
            player = collision.gameObject;
        }*/
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        /*if (collision.gameObject.tag == "Player")
        {
            collided = false;
        }*/
    }
}
