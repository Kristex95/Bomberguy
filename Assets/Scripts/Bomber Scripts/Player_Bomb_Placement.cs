using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Bomb_Placement : MonoBehaviour
{
    public GameObject Bomb;
    public Transform BombSpawn;
    [SerializeField]
    [Range(1f, 5f)]
    float timeToPlaceBomb = 1f;
    private float nextTimeToPlace = 0f;

    private bool placedBomb = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (placedBomb && Time.time >= nextTimeToPlace)
        {
            nextTimeToPlace = Time.time + timeToPlaceBomb;
            Spawn_Bomb();
        }
    }

    public void OnPlaceBomb(InputAction.CallbackContext context)
    {
        placedBomb = context.action.triggered;
    }

    private void Spawn_Bomb()
    {
        float xPos = (Mathf.Round(BombSpawn.position.x));
        float yPos = (Mathf.Round(BombSpawn.position.y));
        Instantiate(Bomb, new Vector3(xPos, yPos, 0), Quaternion.identity);

    }
}
