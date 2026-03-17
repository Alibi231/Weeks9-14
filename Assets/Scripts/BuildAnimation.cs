using System.Collections;
using UnityEngine;

public class BuildAnimation : MonoBehaviour
{
    public GameObject ammo;
    public GameObject armor;
    public GameObject repair;
    public AnimationCurve curve;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(growBuilding(ammo));
        StartCoroutine(growBuilding(armor));
        StartCoroutine(growBuilding(repair));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator growBuilding(GameObject building)
    {
        float t = 0;
        building.transform.localScale = Vector3.zero;

        while (t < 1)
        {
            t += Time.deltaTime;
            building.transform.localScale = Vector3.one * curve.Evaluate(t);
            yield return null;
        }
    }
}
