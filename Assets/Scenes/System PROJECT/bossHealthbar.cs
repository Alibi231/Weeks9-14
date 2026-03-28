using UnityEngine;
using UnityEngine.UI;

public class bossHealthbar : MonoBehaviour
{
    public Slider healthBar;
    public bool stagger1 = false;
    public bool stagger2 = false;
    public GameObject boss;
    public GameObject winScreen;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //The player win screen is made invisible when the game starts.
        winScreen.gameObject.SetActive(false);
    }


    public void reduceHealth()
    {
        /* The boss's health is reduced by 1 whenever its hit. 
         * the player win screen is made visible once the bosses health hit's zero.
        Additionally, when the bosses health hits 55 and 25, it is put into a stagger state where it stays locked
        in place for three seconds.
        */
        healthBar.value -= 1;
        if (healthBar.value <= 0)
        {
            winScreen.gameObject.SetActive(true);
            Time.timeScale = 0f;

        } else if (healthBar.value <= 25 && stagger2 == false) {
            boss.GetComponent<bossBehavior>().staggerState();
            stagger2 = true;
        }
        else if (healthBar.value <= 55 && stagger1 == false)
        {
            boss.GetComponent<bossBehavior>().staggerState();
            stagger1 = true;
        }
    }

}
