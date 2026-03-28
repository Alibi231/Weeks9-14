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
        winScreen.gameObject.SetActive(false);
        healthBar = GetComponent<Slider>();
    }


    public void reduceHealth()
    {
        healthBar.value -= 1;
        if (healthBar.value <= 0)
        {
            winScreen.gameObject.SetActive(true);

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
