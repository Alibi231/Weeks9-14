using UnityEngine;
using UnityEngine.UI;

public class playerHealthbar : MonoBehaviour
{
    public Slider healthBar;
    public GameObject lossScreen;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //When the game starts, the lose screen is hidden.
        lossScreen.gameObject.SetActive(false);
    }


    public void reduceHealth()
    {
        //This is called by a unity event when the player loses health. It reduces health by 20, and ends the game if health < 0.
        healthBar.value -= 20;
        if (healthBar.value <= 0)
        {
            lossScreen.gameObject.SetActive(true);
            Time.timeScale = 0f;
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
