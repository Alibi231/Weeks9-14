using System.Collections;
using System.Diagnostics;
using UnityEngine;

public class bossBehavior : MonoBehaviour
{
    //boss will have 3 attacks to cycle between, that are chosen randomly.
    public int behavior = 1;
    public Coroutine currentAction = null;
    public float timer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
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
        while (timer < 1)
        {
            timer += Time.deltaTime;
            yield return null;

        }
        //Instantiate Fireball
        while (timer < 6)
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
        while (timer < 3)
        {
            timer += Time.deltaTime;
            yield return null;

        }
        //Instantiate Explosion
        while (timer < 6)
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
        while (timer < 1)
        {
            timer += Time.deltaTime;
            yield return null;

        }
        //Instantiate Multiple Spikes
        while (timer < 3)
        {
            timer += Time.deltaTime;
            yield return null;

        }
        StopCoroutine(currentAction);
        timer = 0;
        currentAction = null;
    }

}
