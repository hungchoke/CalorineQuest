using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public Animator animator;
    private SpriteRenderer spriteRenderer;
    private PlayerState currentState;
    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        
    }

    void ChangeState(PlayerState newState)
    {
        currentState = newState;
        switch (newState)
        {
            case PlayerState.Idle:
                PlayAnimation("Idle");
                break;
            case PlayerState.Run:
                PlayAnimation("Run");
                break;
            case PlayerState.Jump:
                PlayAnimation("Jump");
                break;
            case PlayerState.Fall:
                PlayAnimation("Fall");
                break;
            case PlayerState.Hit:
                PlayAnimation("Hit");
                break;
            case PlayerState.Death:
                PlayAnimation("Death");
                break;
        }
    }

    void PlayAnimation(string animationName)
    {
        animator.Play(animationName);
    }

    public void UpdateState(Rigidbody2D rb, bool ground)
    {
        switch (currentState)
        {
            case PlayerState.Idle:
                if (rb.velocity.x != 0f)
                {
                    ChangeState(PlayerState.Run);
                }

                if (rb.velocity.y > 0.1f)
                {
                    ChangeState(PlayerState.Jump);
                }
                break;
            case PlayerState.Run:

                if (rb.velocity.x == 0)
                {
                    ChangeState(PlayerState.Idle);
                }
                if (rb.velocity.y > 0.1f)
                {
                    ChangeState(PlayerState.Jump);
                }
                break;
            case PlayerState.Jump:
                if (rb.velocity.y < 0)
                {
                    ChangeState(PlayerState.Fall);
                }
                break;
            case PlayerState.Fall:
                if (rb.velocity.y == 0)
                {
                    ChangeState(PlayerState.Idle);
                }
                if (rb.velocity.x != 0 && ground == true)
                {
                    ChangeState(PlayerState.Run);
                }
                break;
            case PlayerState.Hit:
                break;
            case PlayerState.Death:
                break;
        }
    }

    public enum PlayerState
    {
        Idle,
        Run,
        Jump,
        Fall,
        Hit,
        Death
    }

    void UpdateAnimation()
    {
        switch (currentState)
        {
            case PlayerState.Idle:
                PlayAnimation("Idle");
                break;
            case PlayerState.Run:

                PlayAnimation("Run");
                break;
            case PlayerState.Jump:
                PlayAnimation("Jump");
                break;
            case PlayerState.Fall:
                PlayAnimation("Fall");
                break;
            case PlayerState.Hit:
                PlayAnimation("Hit");
                break;
            case PlayerState.Death:
                PlayAnimation("Death");
                break;
        }
    }
    public void Flip(Rigidbody2D rb)
    {
        if (rb.velocity.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (rb.velocity.x > 0)
        {
            spriteRenderer.flipX = false;
        }
    }    
}
