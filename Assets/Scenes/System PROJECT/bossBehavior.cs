using System.Collections;
using System.Diagnostics;
using UnityEngine;

public class bossBehavior : MonoBehaviour
{
    //boss will have 3 attacks to cycle between, that are chosen randomly.
    public int behavior = 1;
    public Coroutine currentAction = null;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
                    print("Attack 2");
                    break;
                case 3:
                    print("Attack 3");
                    break;
            }
        }
    }

    IEnumerator Attack1()
    {
        yield return null;
    }

}
