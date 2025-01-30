using UnityEngine;

public class CardManager : MonoBehaviour
{
    public GameObject cardPrefab; // Référence au Prefab de carte
    public Transform drawPosition; // Position où la carte sera créée

    void Update() {}

    public void DrawCard()
    {
        // Vérifie que le Prefab de carte est défini
        if (cardPrefab != null && drawPosition != null)
        {
            // Instancie une nouvelle carte à la position de pioche
            Instantiate(cardPrefab, drawPosition.position, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("CardPrefab ou DrawPosition non défini !");
        }
    }
}