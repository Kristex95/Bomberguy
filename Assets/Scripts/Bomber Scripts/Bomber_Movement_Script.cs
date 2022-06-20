using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Bomber_Movement_Script : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    public string button = "null";
    public float speed;
    public bool alive = true;

    
    private Vector2 moveDir = Vector2.zero;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (alive)
        {
            Set_Input();
        }
    }

    private void FixedUpdate()
    {
        if (alive)
        {
            Move();
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveDir = context.ReadValue<Vector2>();
        if(moveDir.x >= moveDir.y && moveDir.x > 0.5f)
        {
            moveDir.y = 0f;
            moveDir.x = 1f;
        }
        else if(moveDir.x < moveDir.y && moveDir.x < -0.5f)
        {
            moveDir.y = 0f;
            moveDir.x = -1f;
        }
        else if (moveDir.y > moveDir.x && moveDir.y > 0.5f)
        {
            moveDir.x = 0f;
            moveDir.y = 1f;
        }
        else if (moveDir.y < moveDir.x && moveDir.y < -0.5f)
        {
            moveDir.x = 0f;
            moveDir.y = -1f;
        }
        else
        {
            moveDir = Vector3.zero;
        }
    }

    private void Set_Input()
    {
        anim.SetFloat("Horizontal_Speed", moveDir.x);
        anim.SetFloat("Vertical_Speed", moveDir.y);
    }

    private void Move()
    {
        rb.MovePosition(rb.position + moveDir * speed * Time.deltaTime);
    }

    public void OnConfirmPress(InputAction.CallbackContext context)
    {
        if (context.started && button == "skinSelector")
        {
            GetComponent<Bomber_Skin_Select>().NextOption();
        }
        else if(context.started && button == "nameSelector")
        {
            GetComponent<Bomber_Name_Select>().NextOption();
        }
        else if(context.started && button == "randromizer")
        {
            int rand = Random.Range(0, 100);
            GetComponent<Bomber_Name_Select>().UpdateName(rand);
            rand = Random.Range(0, 100);
            GetComponent<Bomber_Skin_Select>().UpdateAnimator(rand);
        }
    }

    //Is called when player disconnects or controll is lost
    public void Destroy()
    {
        GameController gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        foreach (KeyValuePair<GameObject, GameObject> item in gc.playersSpawn)
        {
            if(item.Value == this.gameObject)
            {
                gc.playersSpawn[item.Key] = null;
                break;
            }
        }
        Destroy(this.gameObject);
    }

    public void Die()
    {
        alive = false;
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Player_Bomb_Placement>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<Player_Bomb_Placement>().explosionRadius = 2;
    }

    public void Respawn()
    {
        alive = true;
        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<BoxCollider2D>().enabled = true;
        GetComponent<Player_Bomb_Placement>().explosionRadius = 2;
    }

    public void PauseGame(InputAction.CallbackContext context)
    {
        if (context.performed && gameObject.scene.IsValid())
        {
            GameObject.FindGameObjectWithTag("Pause").GetComponent<PauseMenu>().ChangePauseState();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<Change_Controller_Button>())
        {
            button = "skinSelector";
        }
        else if (collision.gameObject.GetComponent<Change_Name_Button>())
        {
            button = "nameSelector";
        }
        else if (collision.gameObject.GetComponent<Randromizer_Button>())
        {
            button = "randromizer";
        }
        else
        {
            button = "null";
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Button")
        {
            button = "null";
        }
    }
}
