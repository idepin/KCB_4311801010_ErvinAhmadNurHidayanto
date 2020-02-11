using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float varHunger;
    public Image hungerImage;

    public enum playerHungerStats
    {
        Starving,
        Neutral,
        Full
    }
    public playerHungerStats varHungerStats;

    public float runSpeed;
    Rigidbody2D rb;
    Animator anim;

    public int angka;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        //print("Aku ada fungsi start");
        varHunger = 100f;
    }

    // Update is called once per frame
    void Update()
    {
        HungerTime();
        UpdateUI();
        CheckStats();


        Run();
        Flip();
        //print(angka++);
        if (Input.GetKeyDown(KeyCode.A)){
            print(angka++);
        }
    }

    void Run()
    {
        float inputHorizontal = CrossPlatformInputManager.GetAxis("Horizontal");
        Vector2 velocity = new Vector2(inputHorizontal * runSpeed, rb.velocity.y);
        rb.velocity = velocity;

        bool playerHasHorizontalSpeed = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;
        anim.SetBool("isRunning", playerHasHorizontalSpeed);
    }

    void Flip()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;
        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector3(Mathf.Sign(rb.velocity.x), 1f);
        }
    }

    void CheckStats()
    {
        switch (varHungerStats)
        {
            case playerHungerStats.Neutral:
                print("Masih bertenaga");
                break;
            case playerHungerStats.Starving:
                print("Aku lapar");
                break;
            default:
                print("Aku Kenyang");
                break;
        }
    }
    void HungerTime()
    {
        varHunger -= 1 * Time.deltaTime;

        if(varHunger <= 30)
        {
            varHungerStats = playerHungerStats.Starving;
        }else if(varHunger <= 60)
        {
            varHungerStats = playerHungerStats.Neutral;
        }
        else
        {
            varHungerStats = playerHungerStats.Full;
        }
    }

    void UpdateUI()
    {
        hungerImage.fillAmount = (varHunger / 100);
    }
}
