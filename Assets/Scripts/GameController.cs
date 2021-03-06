using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Linq;

public class GameController : MonoBehaviour
{
    public List<GameObject> readyFields = new List<GameObject>();
    [SerializeField]
    GameObject winnerScreen;
    [SerializeField]
    GameObject menu;
    [SerializeField]
    GameObject mapSelection;
    [SerializeField]
    public GameObject pauseMenu;
    [SerializeField]
    private GameObject winnerResult;
    [SerializeField]
    public static GameObject currentLevel;

    [Header("Player")]
    [Space(20)]
    public static List<GameObject> activePlayers = new List<GameObject>();
    private static int playersAlive = 0;
    public static int playersReady = 0;

    [Header("Spawns")]
    [Space(20)]
    public List<GameObject> spawns = new List<GameObject>();
    public Dictionary<GameObject, GameObject> playersSpawn = new Dictionary<GameObject, GameObject>();

    [Header("Game Status")]
    [Space(20)]
    public static bool gameIsRunning = false;
    public static bool isPaused = false;

    // Start is called before the first frame update
    void Start()
    {
        menu.SetActive(true);
        mapSelection.SetActive(false);

        GameObject[] spawnsArr = GameObject.FindGameObjectsWithTag("Respawn");
        spawns.AddRange(spawnsArr);
        spawns.Sort(CompareListByName);

        foreach (var spawn in spawns)
        {
            playersSpawn.Add(spawn, null);
        }

    }

    // Update is called once per frame
    void Update()
    {

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

#region ReadyStatus
        playersReady = 0;
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
            OnReady();
        }
#endregion

        if (playersAlive == 1 && activePlayers.Count >= 2 && gameIsRunning)
        {
            gameIsRunning = false;
            DestroyAllExplosions();
            winnerScreen.SetActive(true);
            foreach(var player in activePlayers)
            {
                if (player.GetComponent<Bomber_Movement_Script>().alive)
                {
                    winnerResult.GetComponent<WinnerImageScript>().ChangeWinnerImage(player);
                }
            }
            Time.timeScale = 0f;
        }
        else if(playersAlive == 0 && activePlayers.Count >= 2 && gameIsRunning)
        {
            gameIsRunning = false;
            DestroyAllExplosions();
            Time.timeScale = 0f;
            winnerScreen.SetActive(true);
            winnerResult.GetComponent<WinnerImageScript>().Draw();
        }
    }

    //Respawns all dead players withtin 1 second
    IEnumerator RespawnAllPlayers(float val)
    {
        yield return new WaitForSeconds(val);
        foreach (var player in activePlayers)
        {
            player.GetComponent<Bomber_Movement_Script>().Respawn();
        }
    }

    public static void RespawnAllPlayers()
    {
        foreach (var player in activePlayers)
        {
            player.GetComponent<Bomber_Movement_Script>().Respawn();
        }
    }

    public static void ResetPositions()
    {
        GameObject[] sp = GameObject.FindGameObjectsWithTag("Respawn");
        List<GameObject> levelSpawns = new List<GameObject>();
        levelSpawns.AddRange(sp);
        levelSpawns.Sort(CompareListByName);

        for(int i = 0; i < activePlayers.Count; i++)
        {
            activePlayers[i].transform.position = levelSpawns[i].transform.position;
            levelSpawns[i].SetActive(false);
        }
    }   

    public void ResetMenuPositions()
    {
        foreach(var item in playersSpawn)
        {
            if(item.Value != null)
            {
                item.Value.transform.position = item.Key.transform.position;
            }
        }
    }

    void OnReady()
    {
        menu.SetActive(false);
        mapSelection.SetActive(true);
        ResetPositions();
    }


    //return to menu
    public void StopGame()
    {
        if (menu.active)
            return;

        gameIsRunning = false;
        Destroy(currentLevel);
        menu.SetActive(true);
        pauseMenu.GetComponent<PauseMenu>().Resume();
        mapSelection.SetActive(false);
        winnerScreen.SetActive(false);
        foreach (var player in activePlayers)
        {
            player.GetComponent<Player_Bomb_Placement>().enabled = false;
        }
        StartCoroutine(RespawnAllPlayers(0f));
        ResetMenuPositions();
        Time.timeScale = 1f;
    }

    public void RestartLevel()
    {
        string newLevel = currentLevel.name;
        newLevel = newLevel.Replace("(Clone)", "");
        Destroy(currentLevel);
        mapSelection.GetComponent<MapSelection>().StartGame(newLevel);
        winnerScreen.SetActive(false);
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

    public void DestroyAllExplosions()
    {
        GameObject[] explosions = GameObject.FindGameObjectsWithTag("Explosion");
        GameObject[] bombs = GameObject.FindGameObjectsWithTag("Bomb");
        GameObject[] powerups = GameObject.FindGameObjectsWithTag("Powerup");
        for (int i = 0; i < explosions.Length; i++)
        {
            Destroy(explosions[i]);
        }
        for (int i = 0; i < bombs.Length; i++)
        {
            Destroy(bombs[i]);
        }
        for (int i = 0; i < powerups.Length; i++)
        {
            Destroy(powerups[i]);
        }
    }

    private static int CompareListByName(GameObject i1, GameObject i2)
    {
        return i1.name.CompareTo(i2.name);
    }

    
}
