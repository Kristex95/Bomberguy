using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion_Script : MonoBehaviour
{

    [SerializeField]
    float burnTime = 1f;

    void Start()
    {
        
        StartCoroutine(Die());
        
    }

    void Update()
    {
        
    }

    IEnumerator Die()
    {
        yield return new WaitForSeconds(burnTime);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
        }
    }
    
}
