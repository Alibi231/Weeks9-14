using UnityEngine;
using UnityEngine.InputSystem;

public class knightSwordInteraction : MonoBehaviour
{
    public GameObject sword;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onAttack(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            if (sword != null)
                sword.GetComponent<swordScript>().swingSword();
        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.GetComponent<swordScript>() != null)
        {
            if (sword != null)
                sword.GetComponent<swordScript>().dropSword();
            sword = collision.gameObject;
            sword.transform.parent = transform;
            sword.transform.position = transform.position;

        }
    }
}
