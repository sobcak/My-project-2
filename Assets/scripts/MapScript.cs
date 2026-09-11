using UnityEngine;

public class MapScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private int MapWidth, MapHeight;
    [SerializeField] private GameObject Tile;


    private void Awake()
    {
        StartGeneration();
    }

    void StartGeneration()
    {
        for (int x = MapWidth; x >= 0; x--)
        {
            for (int y = MapHeight; y >= 0; y--) {
                float OffsetX = (x - y) * (1 / 2f);
                float OffsetY = (x + y) * (1 / 4f);
                GameObject PlacedTile = Instantiate(Tile, new Vector2(OffsetX, OffsetY), Quaternion.identity);
            }
        }
    }

}
