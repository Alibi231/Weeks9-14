using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class knightSwordInteraction : MonoBehaviour
{
    public GameObject sword;
    
    // Like Punchout, hitting the enemy does two things at once, damages the enemy and slightly heals you the player. 
    public UnityEvent hit;
    public float invincibility = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (invincibility > 0)
            invincibility -= Time.deltaTime;
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
            Vector2 newPos = transform.position;
            newPos.y += .5f;

            sword.transform.position = newPos;

        }
        else if (collision.GetComponentInParent<iceSpikeScript>() != null && invincibility <= 0)
        {
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
