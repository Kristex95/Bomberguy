using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Bomber_Hint_Script : MonoBehaviour
{
    private PlayerInput playerInput;
    public GameObject keyboardHintE;
    public GameObject controllerHintX;

    // Start is called before the first frame update
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GetComponent<Bomber_Movement_Script>().button != "null")
        {
            if(playerInput.currentControlScheme == "Keyboard")
            {
                keyboardHintE.SetActive(true);
            }
            else if(playerInput.currentControlScheme == "Controller")
            {
                controllerHintX.SetActive(true);
            }
            
        }
        else
        {
            keyboardHintE.SetActive(false);
            controllerHintX.SetActive(false);
        }
    }
}
