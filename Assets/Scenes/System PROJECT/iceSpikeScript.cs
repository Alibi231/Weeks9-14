using UnityEngine;

public class iceSpikeScript : MonoBehaviour
{
    public float velocity = 0f;
    public float acceleration = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        velocity += acceleration * Time.deltaTime;
        Vector2 newPos = transform.position;
        newPos.y += velocity * Time.deltaTime;
        transform.position = newPos;

    }
}
