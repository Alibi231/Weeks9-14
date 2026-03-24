using UnityEngine;

public class Footsteps : MonoBehaviour
{
    public AudioSource footstep;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Footstep()
    {
        footstep.Play();
        Debug.Log("WWW");
    }
}
