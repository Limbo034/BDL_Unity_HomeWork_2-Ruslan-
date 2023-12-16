using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private float horizontalMove = 0f;
    private bool facingRight = true;

    private bool isGround = false;
    private bool isJump = false;

    private bool isRun = false;

    [Header("Player Movement Settings")]
    [Range(0, 10f)][SerializeField] private float walkMoveSpeed = 1f;
    [Range(0, 10f)][SerializeField] private float runMoveSpeed = 1f;
    [Range(0, 10f)][SerializeField] private float jumpForce = 1f;

    [Header("Player Animator Settings")]
    public Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");

        animator.SetFloat("HorizontalMove", Mathf.Abs(horizontalMove));

        if (Input.GetKey(KeyCode.LeftShift))
        {
            animator.SetFloat("HorizontalMove", Mathf.Abs(horizontalMove * 2));
            isRun = true;
        }

        if (horizontalMove < 0f && facingRight)
        {
            Flip();
        }
        else if (horizontalMove > 0f && !facingRight)
        {
            Flip();
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            isJump = true;
        }


        if (isGround == false)
        {
            animator.SetBool("Jumping", true);
        }
        else
        {
            animator.SetBool("Jumping", false);
        }
    }

    private void FixedUpdate()
    {
        Vector2 walkTargetVelocity = new Vector2(horizontalMove * walkMoveSpeed, rb.velocity.y);
        rb.velocity = walkTargetVelocity;

        if (isJump)
        {
            rb.AddForce(new Vector2(0f, 300f * jumpForce));
            isGround = false;
            isJump = false;
        }

        if (isRun)
        {
            Vector2 runTargetVelocity = new Vector2(horizontalMove * runMoveSpeed, rb.velocity.y);
            rb.velocity = runTargetVelocity;
            isRun = false;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGround = true;
        }
    }


    private void Flip()
    {
        facingRight = !facingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
