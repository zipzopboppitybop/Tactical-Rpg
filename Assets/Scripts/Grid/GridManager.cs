using Unity.VisualScripting;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [Header("Map Settings")]
    public int width = 20;
    public int height = 20;
    public GameObject tilePrefab;

    [Header("Materials")]
    public Material lightMaterial;
    public Material darkMaterial;

    private Tile[,] map;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        map = new Tile[width, height];

        GenerateGrid();
    }

    public void GenerateGrid()
    {
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                // Tiles are 2d so the j/y needs to be in the z coordinate position
                GameObject tile = Instantiate(tilePrefab,new Vector3(i, 0, j), Quaternion.identity);

                if (tile != null)
                {
                    tile.name = $"Tile {i},{j}";
                    tile.transform.SetParent(transform);

                    Renderer tileRenderer = tile.GetComponentInChildren<Renderer>();

                    // Creates checkerboard pattern
                    tileRenderer.material = new Material((i + j) % 2 == 0 ? lightMaterial : darkMaterial);

                    Tile tileScript = tile.GetComponent<Tile>();
                    tileScript.gridPosition = new Vector2Int(i, j);
                    map[i,j] = tileScript; 
                }
            }
        }
    }
}
