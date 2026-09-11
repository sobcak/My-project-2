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
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Attach the BuildingDisplayer to self with custom x coordinates :)
        Vector3 position = new Vector3(transform.position.x, transform.position.y + BuildingOffset, transform.position.z);
        Instantiate(objectPrefab, position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetSpriteForBuilding(BuildingType buildingType) // set the sprite of the buildingDisplayer with spriterenderer to some sprite at specific location
    {
        
        //TODO If not displaying maybe the path is wrong don't forgor
            objectPrefab.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Buildings/" + BuildingType);
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
}

    
