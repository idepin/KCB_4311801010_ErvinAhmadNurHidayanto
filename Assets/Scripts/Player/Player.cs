using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{


    public float hunger = 100f;
    public float health = 100f;
    public Slider hungerSlider;
    public Slider healthSlider;

    public GameObject DeadUI;

    public void ResetPlayer()
    {
        hunger = 100f;
        health = 100f;
        hungerSlider.value = hunger / 100f;
        healthSlider.value = health / 100f;
    }

    private void Start()
    {
        hungerSlider.value = hunger / 100f;
        healthSlider.value = health / 100f;
    }
    public void SetHunger(float value)
    {
        if (hunger < 1f)
        {
            health += value;
            healthSlider.value = health / 100f;
        }
        else
        {
            hunger += value;
            hungerSlider.value = hunger / 100f;
        }

        if (health < 1f)
        {
            DeadUI.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    
    // Update is called once per frame
    void Update()
    {
        
    }
}
