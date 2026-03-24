using UnityEngine;

public class Footsteps : MonoBehaviour
{
    public AudioSource footstep;
    public AudioClip[] footstepClips;
    public ParticleSystem dust;
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
        footstep.PlayOneShot(footstepClips[Random.Range(0, footstepClips.Length)]);
        dust.Emit(Random.Range(15, 40));

    }
}
