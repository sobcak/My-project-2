using UnityEngine;

public class TileManager : MonoBehaviour
{
    // Components
    [SerializeField]private GameObject objectPrefab; // the object that will render the sprite of this tile on this tile
    
    
    // Data
    public bool HasBuilding;  // will render only if building is placed on it to not crash and destroy the game
    public TerrainType TerrainType;
    public BuildingType BuildingType;
    public float BuildingOffset;
    GameObject spawnedObjectPrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        // Attach the BuildingDisplayer to self with custom x coordinates :)
        Vector3 position = new Vector3(transform.position.x, transform.position.y + BuildingOffset, transform.position.z-0.1f);
        spawnedObjectPrefab =  Instantiate(objectPrefab, position, Quaternion.identity);
        
    }


    public void UpdateBuilding()
    {
        if (HasBuilding)
        {
            SetSpriteForBuilding(BuildingType);
            //Debug.Log("reached update");
        }
    }


    public void SetTerrainSprite()
    {
        //Debug.Log("ballsack32");
        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>($"sprites/Terrain/{TerrainType}");
    }

    void SetSpriteForBuilding(BuildingType buildingType) // set the sprite of the buildingDisplayer with spriterenderer to some sprite at specific location
    {
        spawnedObjectPrefab.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>($"sprites/Buildings/{BuildingType}");
    }

   
    
}

public enum TerrainType
{
    Water,
    Grass,
    Forest,
    Desert
}

public enum BuildingType
{
    Building1,
    Building2,
    Building3,
    Farm,
    Mine,
}

public enum SubType
{
    Storage,
    Production,
}

    
