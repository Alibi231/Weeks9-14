using UnityEngine;

public class swingScript : MonoBehaviour
{
    //The swing active bool is used by the boss to deactivate the hitbox after it is hit.
    public bool swingActive;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //This makes the hitbox destroy itself after a brief time window, to make it feel like an attack. 
        swingActive = true;
        Destroy(gameObject, .2f);
    }
}
