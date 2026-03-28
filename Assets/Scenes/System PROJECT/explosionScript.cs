using UnityEngine;

public class explosionScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //The explosion is destroyed quickly to make it seem like a short burst.
        Destroy(gameObject, .8f);
    }

}
