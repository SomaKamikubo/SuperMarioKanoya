using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]
[RequireComponent(typeof(Animator))]

public class PlayerController : MonoBehaviour
{


    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private int walkSpeed;
    [SerializeField] private int dashRate;
    [SerializeField] private int jumpForce;
    [SerializeField] private Animator animator;
    [SerializeField] private AudioClip jump;
    AudioSource audioSource;

    int moveSpeed;
    public static bool dieFlag;

    private bool isMoving = false;
    private bool isJumping = false;
    private bool isFalling = false;


    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = walkSpeed;
        dieFlag = false;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        isMoving = horizontal != 0;
        isFalling = rb.velocity.y < -0.5f;

        Vector3 screen_LeftBottom = Camera.main.ScreenToWorldPoint(Vector3.zero);

        transform.GetComponent<Rigidbody2D>().AddForce(Vector2.left * 10);
        transform.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 10);


        if (transform.position.x < screen_LeftBottom.x)
        {
            Debug.Log(screen_LeftBottom.x);
            transform.position = new Vector3(screen_LeftBottom.x, transform.position.y, transform.position.z);
        }


        Speed();

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

        


        if (transform.position.y < -6)
        {
            dieFlag = true;
        }

        //Ž€‚ñ‚¾‚ç•œŠˆ‚·‚é
        if (dieFlag)
        {
            SceneManager.LoadScene("main");
        }
    }

    void Jump()
    {
        isJumping = true;
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        audioSource.PlayOneShot(jump);
    }



    void Speed()
    {
        if (!isJumping)
        {

            if (Input.GetKey(KeyCode.LeftShift))
                moveSpeed = walkSpeed * dashRate;
            else
                moveSpeed = walkSpeed;
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Goal")
        {
            Debug.Log("clera");
            SceneManager.LoadScene("ClearScene");
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Stage"))
        {
            isJumping = false;
            
        }
    }

    public bool getIsJumping()
    {
        return isJumping;
    }


}
