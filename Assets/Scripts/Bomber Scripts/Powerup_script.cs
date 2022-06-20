using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup_script : MonoBehaviour
{
    public GameObject bombLevelupPrefab;
    public AudioClip powerupSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        string collName = collision.name;
        collName = collName.Replace("(Clone)", "");
        if (collName == bombLevelupPrefab.name)
        {
            GetComponent<AudioSource>().PlayOneShot(powerupSound);
            GetComponent<Player_Bomb_Placement>().explosionRadius += 1;
            Destroy(collision.gameObject);
        }
    }
}
