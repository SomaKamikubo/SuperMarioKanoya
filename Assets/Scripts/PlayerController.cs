using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]
[RequireComponent(typeof(Animator))]

public class PlayerController : MonoBehaviour
{


    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private int moveSpeed;
    [SerializeField] private int jumpForce;
    [SerializeField] private Animator animator;

    private bool isMoving = false;
    private bool isJumping = false;
    private bool isFalling = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        isMoving = horizontal != 0;
        isFalling = rb.velocity.y < -0.5f;

        if (isMoving)
        {
            Vector3 scale = gameObject.transform.localScale;
            if (horizontal < 0 && scale.x > 0 || horizontal > 0 && scale.x < 0)
            {
                scale.x *= -1;
            }
            gameObject.transform.localScale = scale;
        }

        if (Input.GetKeyDown(KeyCode.Space) && !(rb.velocity.y < -0.5f) && !isJumping)
        {
            Jump();
        }
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, rb.velocity.y);

        animator.SetBool("IsMoving", isMoving);
        animator.SetBool("IsJumping", isJumping);
        animator.SetBool("IsFalling", isFalling);
    }

    void Jump()
    {
        isJumping = true;
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Stage"))
        {
            isJumping = false;
        }
    }
}
