using UnityEngine;

public class fireballScript : MonoBehaviour
{
    public float speed = 10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = transform.position;
        newPos.x -= speed * Time.deltaTime;
        transform.position = newPos;
    }
}
