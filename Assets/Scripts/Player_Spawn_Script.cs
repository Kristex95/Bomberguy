using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Spawn_Script : MonoBehaviour
{
    private PlayerInputManager manager;
    [SerializeField]
    public GameObject spawnPosition;
    private Vector3 spawnPosition3D = Vector3.zero;


    // Start is called before the first frame update
    void Start()
    {
        manager = GetComponent<PlayerInputManager>();
        spawnPosition3D = new Vector3(spawnPosition.transform.position.x, spawnPosition.transform.position.y, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }    

    /*private void OnPlayerJoined(PlayerInput playerInput)
    {
        playerInput.transform.position = spawnPosition3D;
    }*/
}
