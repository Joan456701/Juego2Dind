using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealth : MonoBehaviour
{

    public Image[] heart;
    public Sprite fullHealth;
    public Sprite emptyHelth;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerHealthController playerHealth = gameObject.GetComponent<PlayerHealthController>();
        int lives = playerHealth.lives;
        int maxLives = playerHealth.maxLives;

        if (lives > maxLives )
        { lives = maxLives;}

        for (int i = 0; i < heart.Length; i++)
        {
            if (i < lives)
            {
                heart[i].sprite = fullHealth;
            }
            else
            {
                heart[i].sprite = emptyHelth;
            }

            if (i < maxLives)
            {
                heart[i].enabled = true;
            }
            else
            {
                heart[i].enabled = false;
            }
        }

    }
}
