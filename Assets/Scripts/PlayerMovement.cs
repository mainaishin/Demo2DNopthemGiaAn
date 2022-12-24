using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    bool isDoubleJump = false;
    int level;
     Rigidbody2D rb;
     BoxCollider2D coll;
     float dirX;
     Animator anim;
     SpriteRenderer sprite;
     int airJumpCount;
    int airJumpCountMax = 1;

    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private float runSpeed;
    [SerializeField] private float jumpForce;

    public enum MovementState { idle, running, jumping, falling, doublejump}

    [SerializeField] private AudioSource jumpSoundEffect;
    [SerializeField] private AudioSource DoublejumpSoundEffect;


    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        Scene scene = SceneManager.GetActiveScene();
        if (scene.buildIndex == 4 || scene.buildIndex == 5)
        {
            isDoubleJump = true;
        }
    }

    // Update is called once per frame
     public void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * runSpeed, rb.velocity.y);
        //transform.position += new Vector3(dirX, 0, 0) * Time.deltaTime * runSpeed;
        if (IsGrounded())
        {
            airJumpCount = 0;
        }
        //test for normal jump if space is held down
        if (Input.GetButtonDown("Jump"))
        {
            if (IsGrounded())
            {
                jumpSoundEffect.Play();
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
            else
            {
                //Test for double jump only on the frame the space is pressed
                if (Input.GetButtonDown("Jump") && isDoubleJump == true)
                {
                    if (airJumpCount < airJumpCountMax)
                    {
                        DoublejumpSoundEffect.Play();
                        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                        airJumpCount++;
                    }
                }
            }
        }
        UpdateAnimationState();
    }

    public void UpdateAnimationState()
    {
        MovementState state;
        //if (dirX > 0f)
        //{
        //    state = MovementState.running;
        //    sprite.flipX = false;
        //}
        //else if (dirX < 0f)
        //{
        //    state = MovementState.running;
        //    sprite.flipX = true;
        //}
        if (!Mathf.Approximately(0, dirX))
        {
            transform.rotation = dirX > 0 ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;
            state = MovementState.running;
        }
        else
        {
            state = MovementState.idle;
        }
        if(rb.velocity.y > .1f)
        {
            if(airJumpCount == 0)
            {
                state = MovementState.jumping;
            }
            else
            {
                state = MovementState.doublejump;
            }
        }
      
        else if(rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }
        anim.SetInteger("state", (int)state);
    }

    public bool IsGrounded()
    {
       return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

}
