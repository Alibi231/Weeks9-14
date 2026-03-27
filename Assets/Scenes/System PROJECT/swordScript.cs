using System.Collections;
using System.Threading;
using UnityEngine;

public class swordScript : MonoBehaviour
{
    public int weaponType;
    public Coroutine swing;
    public float swingTime = .3f;
    public GameObject visualSwing;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void swingSword()
    {
        if (swing == null)
        {
            
            swing = StartCoroutine(swingSwordCoroutine());
        }
    }

    IEnumerator swingSwordCoroutine()
    {
        float timer = 0;
        
        while(timer < swingTime)
        {
            timer += Time.deltaTime;
            yield return null;
        }

        Instantiate(visualSwing, transform.position, Quaternion.identity);
        StopCoroutine(swing);



    }
}
