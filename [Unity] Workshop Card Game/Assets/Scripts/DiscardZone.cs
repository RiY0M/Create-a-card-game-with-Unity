using UnityEngine;

public class DiscardZone : MonoBehaviour
{
    void Update() {}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Vérifie si l'objet qui entre dans la zone est une carte
        if (collision.gameObject.CompareTag("Card"))
        {
            Destroy(collision.gameObject); // Détruit la carte
        }
    }
}
