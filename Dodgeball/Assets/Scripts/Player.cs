using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    float moveX;
    float moveY;
    public float moveSpeed;
    
    public float jumpForce;
    public LayerMask layerMask;
    public Transform gc;
    public float groudcheckDistance;
    private Rigidbody2D rb;
    private float fallMultipler = 2f;
    public int health = 0;
    bool jump;
    AnimationController animationController;
    private void Start()
    {
        animationController = GetComponent<AnimationController>();
        rb = GetComponent<Rigidbody2D>();
        if (rb == null )
        {
            rb.AddComponent<Rigidbody2D>();
        }
        if(animationController == null)
        {
            rb.AddComponent<AnimationController>();
        }
    }

    private void Update()
    {
        
        moveX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveX * moveSpeed,rb.velocity.y);
        if(Input.GetButtonDown("Jump") && IsGround())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            AudioManager.instance.PlaySFX("Jump");
        }
        animationController.UpdateState(rb,IsGround());
        animationController.Flip(rb);
    }

    bool IsGround()
    {
        RaycastHit2D hit = Physics2D.Raycast(gc.transform.position, Vector2.down, groudcheckDistance, layerMask);
        if (hit.collider != null)
        {
            Debug.DrawRay(gc.transform.position, Vector2.down * groudcheckDistance, Color.yellow);
            return true;
        }
        else
        {
            Debug.DrawRay(gc.transform.position, Vector2.down * groudcheckDistance, Color.red);
            return false;
        }
    }
    
}
