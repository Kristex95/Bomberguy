using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play_Button_Script : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject Level;
    public GameObject LevelSpawn;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && collision.GetComponent<Bomber_Movement_Script>().confirm)
        {
            onClick();
        }
    }

    private void onClick()
    {
        mainMenu.SetActive(false);
        Instantiate(Level, LevelSpawn.transform.position, Quaternion.identity);
    }
}
