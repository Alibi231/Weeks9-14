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
    public GameObject fireball;
    public GameObject explosion;
    public GameObject groundSpikes;
    public UnityEvent bossHit;
    Renderer renderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
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

    IEnumerator Attack1()
    {
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
        if (collision.GetComponent<swingScript>() != null)
        {
            if (collision.GetComponent<swingScript>().swingActive)
            {
                bossHit.Invoke();
                collision.GetComponent<swingScript>().swingActive = false;
            }
        }
         
    }

    public void staggerState()
    {
        StopCoroutine(currentAction);
        timer = 0;
        currentAction = null;
        currentAction = StartCoroutine(stagger());
    }

}
