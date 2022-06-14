using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameController : MonoBehaviour
{
    public List<GameObject> readyFields = new List<GameObject>();
    [SerializeField]
    GameObject menu;
    [SerializeField]
    List<GameObject> levels = new List<GameObject>();
    GameObject currentLevel;

    [Header("Player")]
    [Space(20)]
    public List<GameObject> activePlayers = new List<GameObject>();
    private int playersAlive = 0;
    public int playersReady = 0;

    [Header("Spawns")]
    [Space(20)]
    public List<GameObject> spawns = new List<GameObject>();
    public Dictionary<GameObject, GameObject> playersSpawn = new Dictionary<GameObject, GameObject>();

    [Header("Game Status")]
    [Space(20)]
    public bool gameIsRunning = false;

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] spawnsArr = GameObject.FindGameObjectsWithTag("Respawn");
        spawns.AddRange(spawnsArr);

        foreach (var spawn in spawns)
        {
            playersSpawn.Add(spawn, null);
        }

    }

    // Update is called once per frame
    void Update()
    {
        playersReady = 0;

        activePlayers.Clear();
        GameObject[] playersArr = GameObject.FindGameObjectsWithTag("Player");
        activePlayers.AddRange(playersArr);

        playersAlive = 0;
        //Count how many players alive
        foreach (var player in activePlayers)
        {
            if (player.GetComponent<Bomber_Movement_Script>().alive)
            {
                playersAlive++;
            }
        }

        //if none of the players alive -> respawn them after 1 second
        if (playersAlive == 0 && activePlayers.Count != 0)
        {
            StartCoroutine(RespawnAllPlayers());
        }

        //Count how many players are ready to play (stepped on "ready field")
        foreach (var field in readyFields)
        {
            if (field.GetComponent<Ready_Field_Script>().isReady)
            {
                playersReady++;
            }
        }

        //start the game if all players are ready
        if (playersReady == activePlayers.Count && activePlayers.Count >= 2)
        {
            StartGame();
        }

        if(playersAlive == 1 && activePlayers.Count >= 2)
        {
            StopGame();
        }
        
    }

    //Respawns all dead players withtin 1 second
    IEnumerator RespawnAllPlayers()
    {
        yield return new WaitForSeconds(1f);
        foreach (var player in activePlayers)
        {
            player.GetComponent<Bomber_Movement_Script>().Respawn();
        }
    }

    public void ResetAllPositions()
    {
        foreach (KeyValuePair<GameObject, GameObject> item in playersSpawn)
        {
            item.Value.transform.position = item.Key.transform.position;
        }
    }

    void StartGame()
    {
        menu.SetActive(false);
        currentLevel = Instantiate(levels[0], Vector3.zero, levels[0].transform.rotation);
    }

    //return to menu
    void StopGame()
    {
        Destroy(currentLevel);
        menu.SetActive(true);
        StartCoroutine(RespawnAllPlayers());
        ResetAllPositions();
    }

    //Adds player to a special position in the dictionary 
    private void OnPlayerJoined(PlayerInput playerInput)
    {
        foreach (KeyValuePair<GameObject, GameObject> item in playersSpawn)
        {
            if(item.Value == null)
            {
                playersSpawn[item.Key] = playerInput.gameObject;
                break;
            }
        }

        if (!gameIsRunning)
        {
            foreach (KeyValuePair<GameObject, GameObject> item in playersSpawn)
            {
                if (item.Value == playerInput.gameObject)
                {
                    playerInput.transform.position = item.Key.transform.position;
                    break;
                }
            }
        }
    }
}
