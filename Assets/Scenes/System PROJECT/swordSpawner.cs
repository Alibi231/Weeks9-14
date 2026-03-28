using UnityEngine;
using UnityEngine.UIElements;

public class swordSpawner : MonoBehaviour
{
    //Swordlist is an array of all the different sword types
    public GameObject[] swordList;
    public float timer;
    public float spawnTime = 10;

    // Update is called once per frame
    void Update()
    {
        //One the timer reaches the spawn time, it is reset and a random sword is spawned on the ground.
        timer += Time.deltaTime;
        if (timer > spawnTime)
        {
            timer = 0;
            Vector2 spawnPos = new Vector2(Random.Range(-7, 7), -3.8f);
            Instantiate(swordList[Random.Range(0, swordList.Length)], spawnPos, Quaternion.identity);

        }
    }
}
