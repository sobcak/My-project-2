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
        for(int x = MapWidth; x >= 0; x++)
        {
            for(int y = MapHeight; x >= 0; y++)
            {
                float OffsetX = (x + y) / 2;
                float OffsetY = (x - y) / 4;
                GameObject PlacedTile = Instantiate(Tile, new Vector3(OffsetX, OffsetY, 0), Quaternion.identity);
            }
        }
    }

}
