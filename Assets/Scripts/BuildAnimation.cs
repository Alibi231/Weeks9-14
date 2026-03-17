using System.Collections;
using UnityEngine;

public class BuildAnimation : MonoBehaviour
{
    public GameObject ammo;
    public GameObject armor;
    public GameObject repair;
    public AnimationCurve curve;
    public float buildTime;
    private Coroutine buildCoroutine;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(startBuilding());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator startBuilding()
    {
        StartCoroutine(growBuilding(ammo));
        yield return new WaitForSeconds(buildTime);

        StartCoroutine(growBuilding(armor));
        yield return new WaitForSeconds(buildTime);

        StartCoroutine(growBuilding(repair));
    }

    IEnumerator growBuilding(GameObject building)
    {
        float t = 0;
        building.transform.localScale = Vector3.zero;

        while (t < buildTime)
        {
            t += Time.deltaTime;
            Debug.Log(t);
            building.transform.localScale = Vector3.one * curve.Evaluate(t);
            yield return null;
        }
    }
}
