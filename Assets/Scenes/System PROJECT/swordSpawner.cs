using UnityEngine;
using UnityEngine.UIElements;

public class swordSpawner : MonoBehaviour
{
    public GameObject[] swordList;
    public float timer;
    public float spawnTime = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > spawnTime)
        {
            timer = 0;
            Vector2 spawnPos = new Vector2(Random.Range(-7, 7), -3.8f);
            Instantiate(swordList[Random.Range(0, swordList.Length)], spawnPos, Quaternion.identity);

        }
    }
}
