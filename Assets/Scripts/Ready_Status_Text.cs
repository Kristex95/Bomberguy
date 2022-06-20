using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ready_Status_Text : MonoBehaviour
{
    [SerializeField]
    private string str;
    [SerializeField]
    private TextMeshProUGUI Text;

    // Start is called before the first frame update
    void Start()
    {
        Text.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameController.activePlayers.Count == 0)
        {
            str = "Press any button to join";
        }
        else if(GameController.activePlayers.Count == 1)
        {
            str = "Waiting for other players";
        }
        else
        {
            str = "Ready " + GameController.playersReady + "/" + GameController.activePlayers.Count;
        }
        Text.text = str;
    }
}
