using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ready_Status_Text : MonoBehaviour
{
    [SerializeField]
    private GameController gameController;
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
        str = "Ready " + gameController.playersReady + "/" + gameController.activePlayers.Count;
        Text.text = str;
    }
}
