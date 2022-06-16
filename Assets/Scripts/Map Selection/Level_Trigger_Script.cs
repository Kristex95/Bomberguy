using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_Trigger_Script : MonoBehaviour
{
    public MapSelection mapSelection;
    [SerializeField]
    int selectedCounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(selectedCounter == GameController.activePlayers.Count)
        {
            mapSelection.StartGame(this.gameObject.name);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        selectedCounter++;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        selectedCounter--;
    }
}
