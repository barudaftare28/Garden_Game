using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    // Variabel yang dibutuhkan
    public int cropsCollected = 0;
    public float recoilForce = 15f;

    // Component references
    private Animator anim;
    private Rigidbody2D rb;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // --- Menggunakan TABRAKAN (Collision) untuk SEMUA Interaksi ---
    void OnCollisionEnter2D(Collision2D collision)
    {
        // --- 6a: Kontak dengan Monster ---
        if (collision.gameObject.CompareTag("Monster"))
        {
            // --- HANYA LOGIKA HURT YANG ADA DI BLOK INI ---
            Debug.Log("Player is hurt");

            Vector2 recoilDirection = (transform.position - collision.transform.position).normalized;
            rb.AddForce(recoilDirection * recoilForce, ForceMode2D.Impulse);

            anim.SetTrigger("Hurt");
            // --- BATAS LOGIKA HURT ---
        }

        // --- 6b: Kontak dengan Crop ---
        if (collision.gameObject.CompareTag("Crop"))
        {
            cropsCollected++;
            Debug.Log("Crop harvested: " + cropsCollected);

            Destroy(collision.gameObject); // Hancurkan objek yang ditabrak
        }

        // --- 6c: Kontak dengan Animal ---
        if (collision.gameObject.CompareTag("Animal"))
        {
            Animal animalScript = collision.gameObject.GetComponent<Animal>();
            if (animalScript != null)
            {
                Debug.Log(animalScript.sound);
            }
        }
    }
}