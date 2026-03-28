using System;
using Unity.Hierarchy;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class knightSwordInteraction : MonoBehaviour
{
    public GameObject sword;
    
    // Like Punchout, hitting the enemy does two things at once, damages the enemy and slightly heals you the player. 
    public UnityEvent hit;
    public float invincibility = 0;

    // Update is called once per frame
    void Update()
    {
        // If the players invincibilty is > 0, it will reduce until it isn't.
        if (invincibility > 0)
            invincibility -= Time.deltaTime;
    }

    public void onAttack(InputAction.CallbackContext context)
    {
        // If the player presses the attack button, they will sattack by calling the swing function on their child sword.
        if (context.phase == InputActionPhase.Started)
        {
            if (sword != null)
                sword.GetComponent<swordScript>().swingSword();
        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        /* If the player collides with a sword, they will remove their current sword by calling its dropsword function,
         * then they will assign the colliding sword as their child, set it to their position (+.5 in y to make it visible),
         * and set the sword variable to that sword's game object.
         */
        if (collision.GetComponent<swordScript>() != null)
        {
            if (sword != null)
                sword.GetComponent<swordScript>().dropSword();
            sword = collision.gameObject;
            sword.transform.parent = transform;
            Vector2 newPos = transform.position;
            newPos.y += .5f;

            sword.transform.position = newPos;

        }
        // For all the attacks, it checks if the colliding object has that attacks script, and if invincibility is < 0.
        else if (collision.GetComponentInParent<iceSpikeScript>() != null && invincibility <= 0)
        {
            //When the player is hit the hit event is invoked, which damages the player, and the player is given invincibility.
            invincibility = 1.5f;
            hit.Invoke();
        }
        else if (collision.GetComponent<explosionScript>() != null && invincibility <= 0)
        {
            invincibility = 1.5f;
            hit.Invoke();
        }
        else if (collision.GetComponent<fireballScript>() != null && invincibility <= 0)
        {
            invincibility = 1.5f;
            hit.Invoke();
        }

    }
}
