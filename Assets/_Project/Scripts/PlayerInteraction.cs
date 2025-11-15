using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public int cropsCollected = 0;
    public float recoilSpeed = 10f; 
    
    private Animator anim;
    private Rigidbody2D rb;
    private PlayerMovement movementScript; // Referensi ke script gerakan

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        movementScript = GetComponent<PlayerMovement>(); // Ambil script gerakan
    }

    // --- Menggunakan TABRAKAN (Collision) untuk SEMUA Interaksi ---
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Mencetak NAMA dan TAG dari APAPUN yang kita tabrak.
        // Pakai Warning agar warnanya KUNING dan gampang terlihat.
        Debug.LogWarning("PLAYER MENABRAK: " + collision.gameObject.name + " | DENGAN TAG: " + collision.gameObject.tag);

        // --- 6a: Kontak dengan Monster ---
        if (collision.gameObject.CompareTag("Monster"))
        {
            Debug.Log("Player is hurt");

            movementScript.canMove = false;
            Vector2 recoilDirection = (transform.position - collision.transform.position).normalized;
            rb.linearVelocity = recoilDirection * recoilSpeed; 
            anim.SetTrigger("Hurt");
            Invoke("ResetCanMove", 0.2f);
        }

        // --- 6b & 6c (Crop & Animal) ---
        if (collision.gameObject.CompareTag("Crop"))
        {
            cropsCollected++;
            Debug.Log("Crop harvested: " + cropsCollected); 
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Animal"))
        {
            Animal animalScript = collision.gameObject.GetComponent<Animal>();
            if (animalScript != null)
            {
                Debug.Log(animalScript.sound); 
            }
        }
    }

    // FUNGSI UNTUK MENGAKTIFKAN KEMBALI GERAKAN
    void ResetCanMove()
    {
        movementScript.canMove = true;
    }
}