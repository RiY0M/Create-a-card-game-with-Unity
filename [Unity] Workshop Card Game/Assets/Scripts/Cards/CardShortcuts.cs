using UnityEngine;

public class CardShortcuts : MonoBehaviour
{
    public GameObject cardPrefab; // Le prefab de carte à instancier
    public Transform spawnPoint; // L'emplacement où les cartes apparaîtront

    void Update()
    {
        // Vérifie si une touche est pressée pour faire apparaître une carte
        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Ampersand)) // Touche "1"
        {
            SpawnCard("Card 1");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2)) // Touche "2"
        {
            SpawnCard("Card 2");
        }
    }

    private void SpawnCard(string cardName)
    {
        if (cardPrefab != null && spawnPoint != null)
        {
            // Instancier une carte
            GameObject newCard = Instantiate(cardPrefab, spawnPoint.position, Quaternion.identity);
            newCard.name = cardName; // Renommer la carte pour identifier son origine
        }
        else
        {
            Debug.LogWarning("CardPrefab ou SpawnPoint n'est pas assigné dans l'Inspector !");
        }
    }
}
