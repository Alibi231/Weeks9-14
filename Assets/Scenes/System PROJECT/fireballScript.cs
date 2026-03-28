using UnityEngine;
using UnityEngine.UIElements;

public class fireballScript : MonoBehaviour
{
    public float speed = 10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //The game objects are destroyed to prevent them lingering off screen without reason.
        Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        // the fireball moves left at a speed where the player can react and jump over it. 
        Vector3 newPos = transform.position;
        newPos.x -= speed * Time.deltaTime;
        transform.position = newPos;
    }
}
