using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameController : MonoBehaviour
{
    public List<GameObject> activePlayers = new List<GameObject>();
    private int playersAlive = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        activePlayers.Clear();
        GameObject[] playersArr = GameObject.FindGameObjectsWithTag("Player");
        activePlayers.AddRange(playersArr);

        playersAlive = 0;
        foreach (var player in activePlayers)
        {
            if (player.GetComponent<Bomber_Movement_Script>().alive)
            {
                playersAlive++;
            }
        }

        if(playersAlive == 0 && activePlayers.Count != 0)
        {
            RespawnAllPlayers();
        }
    }

    public void RespawnAllPlayers()
    {
        foreach(var player in activePlayers)
        {
            player.GetComponent<Bomber_Movement_Script>().Respawn();
        }
    }
}
