using System.Collections;
using System.Threading;
using UnityEngine;

public class swordScript : MonoBehaviour
{
    public int weaponType;
    public Coroutine swing;
    public float swingTime = .3f;
    public GameObject visualSwing;



    public void swingSword()
    {
        //This makes sure the swing coroutine is only started if one isn't currently running. 
        if (swing == null)
        {
            swing = StartCoroutine(swingSwordCoroutine());
        }
    }

    public void dropSword()
    {
        /*
         * When the sword is dropped, it removes itself as a child of the player, stops the coroutine if one is running
         * and then destroys the game objecct.
         */
        transform.parent = null;
        if (swing != null)
            StopCoroutine(swing);
        Destroy(gameObject);
        
    }

    IEnumerator swingSwordCoroutine()
    {
        // the sword swings by starting a timer in the courtine, and makes a swing prefab instantiate once the timer is up.
        float timer = 0;
        
        while(timer < swingTime)
        {
            timer += Time.deltaTime;
            yield return null;
        }
        GameObject vSwing = Instantiate(visualSwing, transform.position, Quaternion.identity);
        //This gets the scale of the parents - which is the player - to ensure it faces in the right direction.
        vSwing.transform.localScale = transform.parent.localScale;
        StopCoroutine(swing);
        swing = null;
    }
}
