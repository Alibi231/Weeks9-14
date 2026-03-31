using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;

public class DestructionScript : MonoBehaviour
{
    public float crumbleTimer;
    public GameObject chest;
    public GameObject pot;
    public GameObject barrel;
    public Coroutine crumble;
    public ParticleSystem particles;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        crumble = StartCoroutine(DestroyBuilding());    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator DestroyBuilding()
    {
        particles.Play();
        crumble = StartCoroutine(ShrinkBuilding(chest));
        yield return new WaitForSeconds(crumbleTimer);
        crumble = StartCoroutine(ShrinkBuilding(pot));
        yield return new WaitForSeconds(crumbleTimer);
        crumble = StartCoroutine(ShrinkBuilding(barrel));
        yield return new WaitForSeconds(crumbleTimer);
        Destroy(gameObject);

    }

    public IEnumerator ShrinkBuilding(GameObject building)
    {
        float t = 0;
        while(t < crumbleTimer)
        {
            t += Time.deltaTime;
            building.transform.localScale = Vector3.one * (crumbleTimer - t) * (1/crumbleTimer);
            yield return null;
        }
        building.transform.localScale = Vector3.zero;
    }
}
