using System.Collections;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class bossBehavior : MonoBehaviour
{
    //boss will have 3 attacks to cycle between, that are chosen randomly.
    public int behavior = 1;
    public Coroutine currentAction = null;
    public float timer;

    // The fireball, explosion, and groundspikes objects are all assigned as projectiles the boss can summon.
    public GameObject fireball;
    public GameObject explosion;
    public GameObject groundSpikes;

    // When bosshit is invoked, it does two seperate things within one event. It damages the enemy and heals the player.
    public UnityEvent bossHit;
    Renderer renderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // When the game starts, the renderer is assigned, the behavior is set between 1 and 3, and a random coroutine is started.
        renderer = GetComponent<Renderer>();
        behavior = Random.Range(1, 4);
        switch (behavior)
        {
            case 1:
                currentAction = StartCoroutine(Attack1());
                break;
            case 2:
                currentAction = StartCoroutine(Attack2());
                break;
            case 3:
                currentAction = StartCoroutine(Attack3());
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // If the boss isn't in a coroutine, it will change its behavior variable and start a coroutine based on it. 
        if (currentAction == null)
        {
            behavior = Random.Range(1, 4);
            switch (behavior)
            {
                case 1:
                    currentAction = StartCoroutine(Attack1());
                    break;
                case 2:
                    currentAction = StartCoroutine(Attack2());
                    break;
                case 3:
                    currentAction = StartCoroutine(Attack3());
                    break;
            }
        }
    }

    /*
     * All of the attacks work with two while loops using delta time, and an instantiate gameObject in between. 
     * the first while loop serves as the attacks startup, then it instantiates the projectile in between loops, 
     * and enters a new while loop that serves as the attacks cooldown.
     */
    IEnumerator Attack1()
    {
        // This attack makes the enemy red, and makes it wait before throwing a fireball vertically at the player.
        renderer.material.color = Color.red;
        while (timer < 0.5f)
        {
            timer += Time.deltaTime;
            yield return null;

        }
        GameObject fBall = Instantiate(fireball, new Vector3(transform.position.x, transform.position.y - 1.5f, transform.position.z), Quaternion.identity);
        renderer.material.color = Color.white;
        while (timer < 2)
        {
            timer += Time.deltaTime;
            yield return null;

        }
        StopCoroutine(currentAction);
        timer = 0;
        currentAction = null;

    }

    IEnumerator Attack2()
    {
        // This attack makes the enemy yellow, then makes an explosion around the boss to make the player retreat.
        renderer.material.color = Color.yellow;
        while (timer < 1)
        {
            timer += Time.deltaTime;
            yield return null;

        }
        GameObject xPlosion = Instantiate(explosion, transform.position, Quaternion.identity);
        renderer.material.color = Color.white;
        while (timer < 4)
        {
            timer += Time.deltaTime;
            yield return null;

        }
        StopCoroutine(currentAction);
        timer = 0;
        currentAction = null;
    }

    IEnumerator Attack3()
    {
        // This attack makes the enemy blue, and makes it summon spikes along the ground that rapidly move upwards.
        renderer.material.color = Color.blue;
        while (timer < 1)
        {
            timer += Time.deltaTime;
            yield return null;

        }
        for (int i = 0; i < 15; i++)
        {
            GameObject spike = Instantiate(groundSpikes, new Vector3(transform.position.x +2 - (i * 2.5f), transform.position.y, transform.position.z), Quaternion.identity);
        }
        renderer.material.color = Color.white;
        while (timer < 2)
        {
            timer += Time.deltaTime;
            yield return null;

        }
        StopCoroutine(currentAction);
        timer = 0;
        currentAction = null;
    }

    // The stagger routine make the enemy pink, and leaves them doing nothing for three seconds to give you a window for damage.
    IEnumerator stagger()
    {
        renderer.material.color = Color.pink;
        while (timer < 3)
        {
            timer += Time.deltaTime;
            yield return null;

        }
        StopCoroutine(currentAction);
        timer = 0;
        currentAction = null;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*
         * If the boss is hit by an object with the swingScript - which will be the visual swing, it will then check if the 
         * objects swingActive variable is true. If it is, it will invoke the bossHit event - which damages it then heals 
         * the player - and then set the swingActive to false to prevent being hit multiple times by the same attack.
         */
        if (collision.GetComponent<swingScript>() != null)
        {
            if (collision.GetComponent<swingScript>().swingActive)
            {
                bossHit.Invoke();
                collision.GetComponent<swingScript>().swingActive = false;
            }
        }
         
    }

    // If the enemy is staggered, it immediately stops whichever attack coroutine it was doing, and enters its stagger routine.
    public void staggerState()
    {
        StopCoroutine(currentAction);
        timer = 0;
        currentAction = null;
        currentAction = StartCoroutine(stagger());
    }

}
