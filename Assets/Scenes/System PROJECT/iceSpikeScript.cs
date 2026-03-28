using UnityEngine;

public class iceSpikeScript : MonoBehaviour
{
    public float velocity = 0f;
    public float acceleration = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //The game objects are destroyed to prevent them lingering off screen without reason.
        Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        //The ice spikes accelerate upwards, starting at 0 speed to give the player time to react to them.
        velocity += acceleration * Time.deltaTime;
        Vector2 newPos = transform.position;
        newPos.y += velocity * Time.deltaTime;
        transform.position = newPos;

    }
}
