using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class knightMovement : MonoBehaviour
{
    public Vector2 movement;
    public float runSpeed = 5f;
    public Animator animator;
    public float jump;
    public float ySpeed;
    public float gravity;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //ySpeed is added to the movement vector, to make the character move up and down 
        movement.y = ySpeed;

        //Player position is moved by the movement variable, which is their velocity.  
        transform.position += (Vector3)movement * Time.deltaTime;

        //If the player is beneath the floor, return them to the floor and set velocity to zero. Otherwise, add gravity.
        if (transform.position.y > -4f)
        {
            ySpeed += gravity * Time.deltaTime;
        } else
        {
            ySpeed = 0;
            Vector3 newPos = transform.position;
            newPos.y = -4f;
            transform.position = newPos;
            movement.y = 0;
        }

        // If the player would move out of the screen's bounds, it is returned to the edge of the screen.
        Vector2 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        if ( screenPos.x < 0)
        {
            transform.position -= new Vector3(movement.x * Time.deltaTime, 0, 0);
        } 

        if(screenPos.x > Screen.width)
        {
            transform.position -= new Vector3(movement.x * Time.deltaTime, 0, 0);
        }

        
    }

    public void onMove(InputAction.CallbackContext context)
    {
        if (context.ReadValue<Vector2>() != Vector2.zero)
        {
            //This triggers the animation, and make the character face the direction they move in.
            animator.SetBool("isRunning", true);
            if (movement.x < 0)
            {
                Vector3 newScale = transform.localScale;
                newScale.x = -Mathf.Abs(newScale.x);
                transform.localScale = newScale;
            } else
            {
                Vector3 newScale = transform.localScale;
                newScale.x = Mathf.Abs(newScale.x);
                transform.localScale = newScale;
            }
        }
        else
        {
            animator.SetBool("isRunning", false);
        }

        //Add the x movement from the player controller to the movement variable.
        movement.x = context.ReadValue<Vector2>().x * runSpeed;
    }

    public void onJump(InputAction.CallbackContext context)
    {
        // If the button is pressed and the player is grounded, jump. 
        if(context.phase == InputActionPhase.Started && transform.position.y == -4f)
        {
            ySpeed = jump;
        }
        
    }
}
