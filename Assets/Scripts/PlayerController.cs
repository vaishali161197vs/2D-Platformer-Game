using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float playerSpeed = 10f;
    [SerializeField] float jumpForce = 10f;
    [SerializeField] Animator animator;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] BoxCollider2D bodyCollider;

    

    [SerializeField] BoxCollider2D feetCollider;

    ScoreController scoreController;    

    float initialOffsetY, initialSizeY;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        scoreController = FindObjectOfType<ScoreController>();

        SetBodyColliderInitialValues();
    }
    void SetBodyColliderInitialValues()
    {
        bodyCollider = GetComponent<BoxCollider2D>();
        initialOffsetY = bodyCollider.offset.y;
        initialSizeY = bodyCollider.size.y;
    }
    // Update is called once per frame
    void Update()
    {
        Run();
        Crouch();
        Jump();
    }

    void Run()
    {
        float speed = Input.GetAxisRaw("Horizontal");
        spriteRenderer.flipX = speed >= 0 ? false : true;
        animator.SetFloat("Speed", Mathf.Abs(speed));
        rb.velocity = new Vector2(playerSpeed * speed * Time.deltaTime, rb.velocity.y);
    }

    void Crouch()
    {
        bool crouch = Input.GetKey(KeyCode.LeftControl);
        
        if(crouch)
        {
            animator.SetBool("Crouch", true);
            bodyCollider.offset = new Vector2(bodyCollider.offset.x, initialOffsetY / 1.6f);
            bodyCollider.size = new Vector2(bodyCollider.size.x, initialSizeY / 1.6f);
        }
        else
        {
            animator.SetBool("Crouch", false);
            bodyCollider.offset = new Vector2(bodyCollider.offset.x, initialOffsetY);
            bodyCollider.size = new Vector2(bodyCollider.size.x, initialSizeY);
        }
    }

    void Jump()
    {
        if (feetCollider.IsTouchingLayers(LayerMask.GetMask("Platform")))
        {
            //float jump = Input.GetAxis("Vertical");
            //animator.SetBool("Jump", jump > 0 ? true : false);
            float jump = Input.GetAxisRaw("Jump");
            if (jump > 0)
            {
                //rb.velocity += new Vector2(rb.velocity.x, jump * jumpForce * Time.deltaTime);
                rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            }
            //rb.AddForce(Vector3.up * jumpForce * jump, ForceMode2D.Impulse);
            
            animator.SetBool("Jump", jump > 0 ? true : false);
        }
    }

    internal void PickUpKey()
    {
        Debug.Log("Player collected key");
        scoreController.IncreaseScore(10);
    }

    public void KillPlayer()
    {
        Debug.Log("Player Killed by enemy.");
        animator.SetTrigger("IsDead");
        //Destroy(gameObject);
    }
    //void OnCollisionEnter2D(Collision2D collision)
    //{
    //    Debug.Log("Collision: " + collision.gameObject.name);
    //}
}
