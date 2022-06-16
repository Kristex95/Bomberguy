using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb_Script : MonoBehaviour
{
    public BoxCollider2D coll;
    
    public float explodeTime = 3f;
    public bool collidersInside = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Create_Explode());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Create_Explode()
    {
        yield return new WaitForSeconds(explodeTime);
        Destroy(gameObject);
        Vector2 cell = new Vector2(transform.position.x, transform.position.y);
        FindObjectOfType<Tilemap_Destruction>().Explode(cell);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collidersInside = false;
        coll.isTrigger = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        collidersInside = true;
        coll.isTrigger = true;
    }
}
