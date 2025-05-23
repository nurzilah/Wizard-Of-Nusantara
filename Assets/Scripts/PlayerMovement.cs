using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float horizontalInput;
    float moveSpeed = 5f;
    bool isFacingRight = true;
    float jumpPower = 7.5f;
    bool isJumping = false;

    float mobileInputX = 0f; // Tambahan untuk tombol kanan/kiri mobile

    Rigidbody2D rb;
    Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>(); // Inisialisasi Animator
    }

    void Update()
    {
        // Gabungkan input keyboard dan tombol mobile
        float inputX = Input.GetAxis("Horizontal") + mobileInputX;
        horizontalInput = Mathf.Clamp(inputX, -1f, 1f); // Hindari lebih dari 1

        FlipSprite();

        if ((Input.GetButtonDown("Jump") || mobileJumpPressed) && !isJumping)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            isJumping = true;
            mobileJumpPressed = false; // Reset flag lompat
        }

        // Ganti animasi
        if (Input.GetKeyDown(KeyCode.X))
        {
            animator.SetInteger("state", 2);
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
        if (isFacingRight && horizontalInput < 0f || !isFacingRight && horizontalInput > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 ls = transform.localScale;
            ls.x *= -1f;
            transform.localScale = ls;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isJumping = false;
    }

    // ---------------- Tambahan Fungsi untuk Tombol UI Mobile ----------------

    public void MoveRight(bool isPressed)
    {
        if (isPressed)
            mobileInputX = 1f;
        else if (mobileInputX == 1f)
            mobileInputX = 0f;
    }

    public void MoveLeft(bool isPressed)
    {
        if (isPressed)
            mobileInputX = -1f;
        else if (mobileInputX == -1f)
            mobileInputX = 0f;
    }

    private bool mobileJumpPressed = false;

    public void MobileJump()
    {
        mobileJumpPressed = true;
    }
}
