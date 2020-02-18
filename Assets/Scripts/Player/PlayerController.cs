using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Vector2 startPos;

    public float runSpeed;
    public float jumpSpeed;


    Rigidbody2D rb;
    Animator anim;
    Collider2D col;
    public void ResetPosition()
    {
        transform.position = startPos;
    }
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        col = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
       
        Run();
        Flip();
        Jump();
        
    }






    void Jump()
    {
        if (col.IsTouchingLayers(LayerMask.GetMask("Foreground")))
        {
            if (CrossPlatformInputManager.GetButtonDown("Jump"))
            {
                Vector2 jumpVelocity = new Vector2(0f, jumpSpeed);
                rb.velocity += jumpVelocity;
            }
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
}
