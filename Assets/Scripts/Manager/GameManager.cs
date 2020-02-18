using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerController playerController;
    public GameObject food;

    private void Start()
    {
        Time.timeScale = 0f;
    }
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

    public void Exit()
    {
        Application.Quit();
    }
}
