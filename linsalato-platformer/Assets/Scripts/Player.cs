using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player Variable Controls")]
    [SerializeField] private float runSpeed = 5.0f;
    [SerializeField] private float jumpSpeed = 5.0f;
    [SerializeField] private float climbSpeed = 5.0f;
    
    private float gravityScaleAtStart;

    Rigidbody2D playerCharacter;
    Animator playerAnimator;
    CapsuleCollider2D playerBodyCollider;
    BoxCollider2D playerFeetCollider;


    void Start()
    {
        playerCharacter = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        playerBodyCollider = GetComponent<CapsuleCollider2D>();
        playerFeetCollider = GetComponent<BoxCollider2D>();

        gravityScaleAtStart = playerCharacter.gravityScale;
    }


    void Update()
    {
        Run();
        FlipSprite();
        Jump();
        Climb();
        //Grounded();
    }

    private void Run()
    {
        //Value between -1 to +1
        float hMovement = Input.GetAxis("Horizontal");
        Vector2 runVelocity = new Vector2(hMovement * runSpeed, playerCharacter.velocity.y);
        playerCharacter.velocity = runVelocity;

        print(runVelocity);

        bool hSpeed = Mathf.Abs(playerCharacter.velocity.x) > Mathf.Epsilon;

        playerAnimator.SetBool("run", hSpeed);
    }

    private void FlipSprite()
    {
        bool hMovement = Mathf.Abs(playerCharacter.velocity.x) > Mathf.Epsilon;

        //If player is moving horizontally
        if (hMovement)
        {
            //reverse current direction of the x axis 
            transform.localScale = new Vector2(Mathf.Sign(playerCharacter.velocity.x), 1f);
        }
    }

    private void Jump()
    {
        if (!playerFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))) 
        {
            playerAnimator.SetBool("jump", false);

            return;
        }
        
        if (Input.GetButtonDown("Jump"))
        {
            
            Vector2 jumpVelocity = new Vector2(0.0f, jumpSpeed);
            playerCharacter.velocity += jumpVelocity;

            playerAnimator.SetBool("jump", true);
        }
    }

    private void Climb()
    {
        if (!playerBodyCollider.IsTouchingLayers(LayerMask.GetMask("Climbing")))
        {
            playerAnimator.SetBool("climb", false);
            playerCharacter.gravityScale = gravityScaleAtStart;
            return;
        }

        // "Vertical" from Input Axis
        float vMovement = Input.GetAxis("Vertical");

        // X axis need to remain the same and we need to change Y
        Vector2 climbVelocity = new Vector2(playerCharacter.velocity.x, vMovement * climbSpeed);
        playerCharacter.velocity = climbVelocity;

        playerCharacter.gravityScale = 0.0f;

        bool vSpeed = Mathf.Abs(playerCharacter.velocity.y) > Mathf.Epsilon;
        playerAnimator.SetBool("climb", vSpeed);
    }

    private void Grounded()
    {

    }
}
