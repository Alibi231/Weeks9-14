using UnityEngine;
using UnityEngine.InputSystem;

public class knightMovement : MonoBehaviour
{
    public Vector2 movement;
    public float runSpeed = 5f;
    public Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3)movement * runSpeed * Time.deltaTime;

        
       
    }

    public void onMove(InputAction.CallbackContext context)
    {
        if (context.ReadValue<Vector2>() != Vector2.zero)
        {
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

        movement = context.ReadValue<Vector2>();
    }
}
