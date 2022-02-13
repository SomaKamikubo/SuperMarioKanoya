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
    [SerializeField] private GameObject soundObject;
    private Audio audioClass;

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
        audioClass = soundObject.GetComponent<Audio>();

    }

    // Update is called once per frame
    
    void Update()
    {
        Move();
        //ジャンプ
        if (Input.GetKeyDown(KeyCode.Space) && !(rb.velocity.y < -0.5f) && !isJumping)
        {
            Jump();
        }

        isFalling = rb.velocity.y < -0.5f;
        //アニメーション
        animator.SetBool("IsMoving", isMoving);
        animator.SetBool("IsJumping", isJumping);
        animator.SetBool("IsFalling", isFalling);

        
    }

    void Move()
    {
        //動く
        float horizontal = Input.GetAxis("Horizontal");
        isMoving = horizontal != 0;
        rb.velocity = new Vector2(horizontal * moveSpeed, rb.velocity.y);

        //プレイヤーがカメラの左に行かないようにする
        Vector3 screen_LeftBottom = Camera.main.ScreenToWorldPoint(Vector3.zero);
        if (transform.position.x < screen_LeftBottom.x)
        {
            transform.position = new Vector3(screen_LeftBottom.x, transform.position.y, transform.position.z);
        }

        //プレイヤーの左右反転
        if (isMoving)
        {
            Vector3 scale = gameObject.transform.localScale;
            if (horizontal < 0 && scale.x > 0 || horizontal > 0 && scale.x < 0)
            {
                scale.x *= -1;
            }
            gameObject.transform.localScale = scale;
        }

        //SHIFTでスピードを上げる
        if (!isJumping)
        {

            if (Input.GetKey(KeyCode.LeftShift))
                moveSpeed = walkSpeed * dashRate;
            else
                moveSpeed = walkSpeed;
        }
    }

    void Jump()
    {
        isJumping = true;
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        audioClass.JumpSE();
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



}
