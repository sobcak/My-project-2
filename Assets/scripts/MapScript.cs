using UnityEngine;

public class MapScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private int MapWidth, MapHeight;
    [SerializeField] private GameObject Tile;
    Vector2 scale;
    Vector2 Temp;
    char tmp;



    private void Awake()
    {
        scale = Tile.transform.localScale;

        StartGeneration();
    }

    void StartGeneration()
    {
        fileReaderTemporary.LoadMapsIntoMemory();
        for (int x = MapWidth-1; x >= 0; x--)
        {
            for (int y = MapHeight-1; y >= 0; y--) {

                float OffsetX = (x - y) * (scale.x / 2f);
                float OffsetY = (x + y) * (scale.y / 4f);
                GameObject PlacedTile = Instantiate(Tile, new Vector3(OffsetX, OffsetY,0f), Quaternion.identity);

                switch (tmp = fileReaderTemporary.Coordinance(new Vector2(x, y))){
                    case 'P':
                        PlacedTile.GetComponent<TileManager>().TerrainType = TerrainType.Grass;
                        PlacedTile.GetComponent<TileManager>().SetTerrainSprite();
                        PlacedTile.transform.position = new Vector3(OffsetX, OffsetY, -0.1f);
                        break;
                    case 'S':
                        PlacedTile.GetComponent<TileManager>().TerrainType = TerrainType.Desert;
                        PlacedTile.GetComponent<TileManager>().SetTerrainSprite();
                        break;
                    case 'W':
                        PlacedTile.GetComponent<TileManager>().TerrainType = TerrainType.Water;
                        PlacedTile.GetComponent<TileManager>().SetTerrainSprite();
                        break;
                }
                

                
                
                
                Temp = PlacedTile.GetComponent<SpriteRenderer>().bounds.size;
                
            }
        }
    }

}
