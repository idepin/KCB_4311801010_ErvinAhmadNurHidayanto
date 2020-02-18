using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerController playerController;
    public GameObject food;
    

    public void ResetGame()
    {
        Time.timeScale = 1f;
        playerController.ResetPosition();
        for(int a = 0; a < food.transform.childCount; a++)
        {
            food.transform.GetChild(a).gameObject.SetActive(true);
        }
        playerController.gameObject.GetComponent<Player>().ResetPlayer();
    }
}
