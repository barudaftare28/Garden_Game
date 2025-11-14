using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Var yang bisa diatur di inspector
    public float moveSpeed = 5f;

    // Component references
    private Rigidbody2D rb;
    private Animator anim;

    // Var penyimpan input
    private Vector2 movement;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Dapat komponen Rigidbody2D dan Animator dari GameObject:
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // --- 1. Mendapatkan Input dari Keyboard ---
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // --- 2. Logika IsWalking ---
        if (movement.x != 0 || movement.y != 0)
        {
            movement.Normalize();
            anim.SetBool("isWalking", true);

            // Logika LastMove hanya di-update jika Player bergerak
            anim.SetFloat("lastMoveX", movement.x);
            anim.SetFloat("lastMoveY", movement.y);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }

        // --- 3. Mengirimkan Input ke Animator ---
        anim.SetFloat("moveX", movement.x);
        anim.SetFloat("moveY", movement.y);
    }

    void FixedUpdate()
    {
        // --- 4. Menerapkan Gerakan ke Rigidbody (Fisika) ---
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
