using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float horizontalInput;
    float moveSpeed = 5f;
    bool isFacingRight = true;
    float jumpPower = 7.5f;

    float mobileInputX = 0f; // Untuk tombol kanan/kiri mobile
    private bool mobileJumpPressed = false;

    Rigidbody2D rb;
    Animator animator;

    // 🔽 Tambahan untuk Ground Check
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // 🔽 Cek apakah karakter sedang menyentuh tanah
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // Gabungkan input keyboard dan mobile
        float inputX = Input.GetAxis("Horizontal") + mobileInputX;
        horizontalInput = Mathf.Clamp(inputX, -1f, 1f);

        FlipSprite();

        // 🔽 Lompat kalau tombol ditekan dan sedang di tanah
        if ((Input.GetButtonDown("Jump") || mobileJumpPressed) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            mobileJumpPressed = false; // reset
        }

        // 🔽 Ganti animasi
        if (Input.GetKeyDown(KeyCode.X))
        {
            animator.SetInteger("state", 2); // contoh: attack
        }
        else if (Mathf.Abs(horizontalInput) > 0.1f)
        {
            animator.SetInteger("state", 1); // jalan
        }
        else
        {
            animator.SetInteger("state", 0); // idle
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
    }

    void FlipSprite()
    {
        if ((isFacingRight && horizontalInput < 0f) || (!isFacingRight && horizontalInput > 0f))
        {
            isFacingRight = !isFacingRight;
            Vector3 ls = transform.localScale;
            ls.x *= -1f;
            transform.localScale = ls;
        }
    }

    // 🔽 Fungsi tombol UI kanan
    public void MoveRight(bool isPressed)
    {
        if (isPressed)
            mobileInputX = 1f;
        else if (mobileInputX == 1f)
            mobileInputX = 0f;
    }

    // 🔽 Fungsi tombol UI kiri
    public void MoveLeft(bool isPressed)
    {
        if (isPressed)
            mobileInputX = -1f;
        else if (mobileInputX == -1f)
            mobileInputX = 0f;
    }

    // 🔽 Fungsi tombol lompat mobile
    public void MobileJump()
    {
        mobileJumpPressed = true;
    }
}
