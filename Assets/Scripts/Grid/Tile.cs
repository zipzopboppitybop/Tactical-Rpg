using UnityEngine;
using UnityEngine.EventSystems;

public class Tile : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    public Vector2Int gridPosition;

    [Header("Colors")]
    public Color originalColor;
    public Color selectedColor = Color.blue;
    public Color highlightColor = Color.cyan;

    private Renderer tileRenderer;
    private static Tile selectedTile;

    private void Start()
    {
        tileRenderer = GetComponentInChildren<Renderer>();
    }

    public void ChangeColor(Color color)
    {
        if (tileRenderer != null)
        {
            tileRenderer.material.color = color;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (selectedTile != this)
        {
            ChangeColor(highlightColor);
        }    
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (selectedTile != this)
        {
            ChangeColor(originalColor);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (selectedTile)
        {
            selectedTile.ChangeColor(selectedTile.originalColor);
        }

         selectedTile = this;
         ChangeColor(selectedColor);
        
    }
}
