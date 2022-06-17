using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSelection : MonoBehaviour
{
    [SerializeField]
    List<GameObject> levels = new List<GameObject>();
    public GameObject winnerMenu;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame(string levelName)
    {
        Time.timeScale = 1f;
        GameController.RespawnAllPlayers();
        GameObject levelToStart = levels[0];

        this.gameObject.SetActive(false);

        foreach(var level in levels)
        {
            if(level.name == levelName)
            {
                levelToStart = level;
                break;
            }
        }
        GameController.currentLevel = Instantiate(levelToStart, Vector3.zero, levels[0].transform.rotation);

        foreach(var player in GameController.activePlayers)
        {
            player.GetComponent<Player_Bomb_Placement>().enabled = true;
        }
        GameController.ResetPositions();
        GameController.gameIsRunning = true;
        winnerMenu.SetActive(false);
    }

    private static int CompareListByName(GameObject i1, GameObject i2)
    {
        return i1.name.CompareTo(i2.name);
    }
}
