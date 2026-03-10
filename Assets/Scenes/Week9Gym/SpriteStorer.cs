using UnityEngine;
using UnityEngine.InputSystem;

public class SpriteStorer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public Sprite[] spriteList;
    public SpriteRenderer[] objectSprites;
    private int iterator = -1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeSprite(InputAction.CallbackContext context)
    {
        if (context.performed == true)
        {
            iterator++;
            if (iterator >= objectSprites.Length)
            {
                iterator = 0;
            }

            Sprite newImage = spriteList[Random.Range(0, spriteList.Length)];
            while (newImage == objectSprites[iterator].sprite)
            {
                newImage = spriteList[Random.Range(0, spriteList.Length)];
            }
            objectSprites[iterator].sprite = newImage;
        }

    }

}
