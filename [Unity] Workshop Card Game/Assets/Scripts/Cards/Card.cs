using UnityEngine;

public class Card : MonoBehaviour
{
    // Pour pouvoir être modifiées, les propriétés doivent être en public
	public string cardName;
	public int cardValue;
    public GameObject cardPrefab;

    private bool isDragging = false;
    private Vector3 offset;
    private SpriteRenderer highlightRenderer;

    void Start()
    {
        // Initialisation pour le déplacement
        highlightRenderer = transform.Find("Highlight").GetComponent<SpriteRenderer>();
        if (highlightRenderer != null)
        {
            highlightRenderer.enabled = false; // Désactive l'effet de surbrillance au début
        }
    }

    void Update()
    {
        UpdatePosition();
    }

    void OnMouseEnter()
    {
        // Active l'effet de surbrillance lorsque la souris survole la carte
        if (highlightRenderer != null)
        {
            highlightRenderer.enabled = true;
        }
    }

    void OnMouseExit()
    {
        // Désactive l'effet de surbrillance lorsque la souris quitte la carte
        if (highlightRenderer != null)
        {
            highlightRenderer.enabled = false;
        }
    }

    void OnMouseDown()
    {
        isDragging = true;
        offset = transform.position - GetMouseWorldPosition();
    }

    void OnMouseUp()
    {
        isDragging = false;
    }

    void UpdatePosition()
    {
        if (isDragging)
        {
            transform.position = GetMouseWorldPosition() + offset;
        }
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        return mousePosition;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Vérifie si l'objet qui entre dans la zone est une carte
        if (collision.gameObject.CompareTag("Card") && isDragging)
        {
            if(cardPrefab == null) {
                Debug.LogWarning("CardPrefab ou DrawPosition non défini !");
                return;
            }

            // Créé la carte
            Instantiate(cardPrefab, this.transform.position, Quaternion.identity);
            Destroy(collision.gameObject); // Détruit la carte
            Destroy(gameObject);
        }
    }
}
