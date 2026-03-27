using UnityEngine;

public class knightSwordInteraction : MonoBehaviour
{
    public GameObject sword;
    public Component swordScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.GetComponent<swordScript>() != null)
        {
            sword.GetComponent<swordScript>().dropSword();
            sword = collision.gameObject;
            sword.transform.parent = transform;
            sword.transform.position = transform.position;

        }
    }
}
