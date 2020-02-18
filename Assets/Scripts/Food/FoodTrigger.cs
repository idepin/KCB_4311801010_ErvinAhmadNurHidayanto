using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodTrigger : MonoBehaviour
{
    public Player player;

    public enum FoodType
    {
        Normal,
        Toxic
    }
    public FoodType foodType;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Eat();
        gameObject.SetActive(false);
    }

    void Eat()
    {
        switch (foodType)
        {
            case FoodType.Normal:
                player.SetHunger(10f);
                break;
            case FoodType.Toxic:
                player.SetHunger(-40f);
                break;
        }

    }
}
