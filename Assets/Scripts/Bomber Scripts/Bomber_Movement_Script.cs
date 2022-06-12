using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Bomber_Movement_Script : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    public bool confirm = false;
    public float speed;


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
        Get_Input();
    }

    private void FixedUpdate()
    {
        Move();
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

    private void Get_Input()
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
        confirm = context.action.triggered;     
    }
}
