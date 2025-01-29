using UnityEngine;

public class Card : MonoBehaviour
{
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
}
