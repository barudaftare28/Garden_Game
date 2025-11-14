using UnityEngine;

public class MonsterReaction : MonoBehaviour
{
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Fungsi ini jalan saat Player MASUK ke zona deteksi (Circle Collider)
    void OnTriggerEnter2D(Collider2D other)
    {
        // Cek apakah yang masuk adalah Player
        if (other.CompareTag("Player"))
        {
            // Set parameter "isPlayerNearby" di Animator Goblin menjadi TRUE
            anim.SetBool("isPlayerNearby", true);
        }
    }

    // Fungsi ini jalan saat Player KELUAR dari zona deteksi
    void OnTriggerExit2D(Collider2D other)
    {
        // Cek apakah yang keluar adalah Player
        if (other.CompareTag("Player"))
        {
            // Set parameter "isPlayerNearby" di Animator Goblin menjadi FALSE
            anim.SetBool("isPlayerNearby", false);
        }
    }
}