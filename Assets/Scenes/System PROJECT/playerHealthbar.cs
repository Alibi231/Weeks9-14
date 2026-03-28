using UnityEngine;
using UnityEngine.UI;

public class playerHealthbar : MonoBehaviour
{
    public Slider healthBar;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        healthBar = GetComponent<Slider>();
    }


    public void reduceHealth()
    {
        healthBar.value -= 20;
        if (healthBar.value < 0)
        {
            //LOSE
        }
    }

    public void increaseHealth()
    {
        healthBar.value += 5;
        if (healthBar.value > 100)
        {
            healthBar.value = 100;
        }
    }
}
