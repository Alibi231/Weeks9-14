using UnityEngine;

public class swingScript : MonoBehaviour
{
    public bool swingActive;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        swingActive = true;
        Destroy(gameObject, .2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
