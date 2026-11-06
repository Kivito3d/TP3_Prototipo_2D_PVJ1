using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] private PlayerStats playerStats; 
    [Header("Ground Check")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius = 0.2f; 

    [SerializeField] private LayerMask groundLayer; 
    
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private float horizontalInput; 
    private bool isGrounded; 
    private bool jump; 
    private bool canMove = true; 
    public void SetMovementState(bool state) => canMove = state;
  
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        playerStats.Checkpoint = transform.position;

    }

    private void Update()
    {
        if (GameManager.Instance.CurrentState == GameState.Playing  )
        {
            horizontalInput = Input.GetAxisRaw("Horizontal");
            if (Input.GetButtonDown("Jump") && isGrounded) jump = true;
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

            UpdateAnimator();
        }

     }

    private void FixedUpdate() 
    { 
        Move();
        if (jump)
        {
            Jump();
        }
    }

    private void Move()
    {
        float speed = playerStats != null ?playerStats.SpeedPlatform : 8f; 
        rb.linearVelocity = new Vector2(horizontalInput *speed,rb.linearVelocity.y);

        /*if (horizontalInput != 0f)
        {
            animator.SetBool("IsRunning", true);
        }
        else
        {
            animator.SetBool("IsRunning", false);
        }*/
        if (horizontalInput > 0f)
        {
            spriteRenderer.flipX = false;
        }
        else if (horizontalInput < 0f)
        {
            spriteRenderer.flipX = true;
        }

    }
    private void Jump() 
    { 
        float force = playerStats != null ? playerStats.JumpForce : 12f;
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, force);

        jump = false;
        
        
    }

    private void UpdateAnimator()
    {
        animator.SetFloat("Speed",Mathf.Abs(horizontalInput));
        animator.SetBool("IsGrounded",isGrounded);
    }

    private void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = isGrounded ? Color.green : Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }


}
