using UnityEngine;
using UnityEngine.UI;

public class playerHealthbar : MonoBehaviour
{
    public Slider healthBar;
    public GameObject lossScreen;
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
            lossScreen.SetActive(true);
        }
    }

    public void increaseHealth()
    {
        healthBar.value += 1;
        if (healthBar.value > 100)
        {
            healthBar.value = 100;
        }
    }
}
