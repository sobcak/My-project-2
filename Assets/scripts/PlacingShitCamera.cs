using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using NUnit.Framework.Internal.Commands;

public class PlacingShitCamera : MonoBehaviour
{


    [SerializeField] private Camera mainCamera;
    [SerializeField] private LayerMask Layer;
    [SerializeField] private float SearchRadius = 20f;
    [SerializeField] private GameObject RightClickInfoCanvas;
    [SerializeField] private Text HasBuilding;
    [SerializeField] private Text TerrainType2;
    [SerializeField] private Text BuidlingType;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
        if(mainCamera == null)
        {
            Debug.Log("camera");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Vector3 mouseScreenPos = Input.mousePosition;

            //idk bro matiku ukradena z stack overflow(overflow?)
            mouseScreenPos.z = mainCamera.transform.position.z;


            Vector2 mouseWorldPos = mainCamera.ScreenToWorldPoint(mouseScreenPos);

            Debug.Log("World Position: " + mouseWorldPos);
            GameObject Temp = ClosestOb(mouseWorldPos);
            RightClickInfoCanvas.SetActive(true);
            HasBuilding.text = Temp.GetComponent<TileManager>().HasBuilding.ToString();
            TerrainType2.text = Temp.GetComponent<TileManager>().TerrainType.ToString();
            BuidlingType.text = Temp.GetComponent<TileManager>().BuildingType.ToString();
        }
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("fdzkgdskz");
            Vector3 mouseScreenPos = Input.mousePosition;

            //idk bro matiku ukradena z stack overflow(overflow?)
            mouseScreenPos.z = mainCamera.transform.position.z;

            
            Vector2 mouseWorldPos = mainCamera.ScreenToWorldPoint(mouseScreenPos);

            Debug.Log("World Position: " + mouseWorldPos);
            GameObject Temp = ClosestOb(mouseWorldPos);
            Debug.Log(Temp);

            
            switch (LeChoiceSystem.WeBeChoosing)
            {
                case ("Nothing"):
                    break;
                case ("Housing"):
                    TileManager tile = Temp.GetComponent<TileManager>();
                    if (tile.TerrainType == TerrainType.Water)
                    {
                        break;
                    }

                    if (tile.HasBuilding == true)
                    {
                        Debug.Log("Has Building Already");
                        break;
                    }
                    if (BuildingManager.RegisterBuilding(BuildingManager.CreateBuilding(BuildingType.Housing)))
                    {
                        Temp.GetComponent<TileManager>().BuildingType = BuildingType.Housing;
                        Temp.GetComponent<TileManager>().HasBuilding = true;
                        Temp.GetComponent<TileManager>().UpdateBuilding();
                    }
                    else
                    {
                        Debug.Log("Not Enough Rescourscess");
                    }

                    LeChoiceSystem.WeBeChoosing = "Nothing";
                    break;
                case ("Farm"):
                    tile = Temp.GetComponent<TileManager>();
                    if (tile.TerrainType == TerrainType.Water)
                    {
                        break;
                    }

                    if (tile.TerrainType == TerrainType.Desert)
                    {
                        break;
                    }
                    if (BuildingManager.RegisterBuilding(BuildingManager.CreateBuilding(BuildingType.Farm)))
                    {
                        Temp.GetComponent<TileManager>().BuildingType = BuildingType.Farm;
                        Temp.GetComponent<TileManager>().HasBuilding = true;
                        Temp.GetComponent<TileManager>().UpdateBuilding();
                    }
                    else
                    {
                        Debug.Log("Not Enough Rescourscess");
                    }
                    LeChoiceSystem.WeBeChoosing = "Nothing";
                    break;
                case ("Well"):
                    tile = Temp.GetComponent<TileManager>();
                    if (tile.TerrainType == TerrainType.Water)
                    {
                        break;
                    }
                    if (BuildingManager.RegisterBuilding(BuildingManager.CreateBuilding(BuildingType.Well)))
                    {
                        DataStorage.Instance.Well = true;
                        Temp.GetComponent<TileManager>().BuildingType = BuildingType.Well;
                        Temp.GetComponent<TileManager>().HasBuilding = true;
                        Temp.GetComponent<TileManager>().UpdateBuilding();
                    }
                    else
                    {
                        Debug.Log("Not Enough Rescourscess");
                    }
                    LeChoiceSystem.WeBeChoosing = "Nothing";
                    break;
                case ("Forestry"):
                    Debug.Log("we for");
                    tile = Temp.GetComponent<TileManager>();
                    if (tile.TerrainType == TerrainType.Water)
                    {
                        break;
                    }
                    if (BuildingManager.RegisterBuilding(BuildingManager.CreateBuilding(BuildingType.Forestry)))
                    {
                        Debug.Log("fi");
                        Temp.GetComponent<TileManager>().BuildingType = BuildingType.Forestry;
                        Temp.GetComponent<TileManager>().HasBuilding = true;
                        Temp.GetComponent<TileManager>().UpdateBuilding();
                    }
                       
                    LeChoiceSystem.WeBeChoosing = "Nothing";
                    break;
                case ("Saw"):
                    tile = Temp.GetComponent<TileManager>();
                    if (tile.TerrainType == TerrainType.Water)
                    {
                        break;
                    }
                    if (BuildingManager.RegisterBuilding(BuildingManager.CreateBuilding(BuildingType.Saw)))
                    {
                        Temp.GetComponent<TileManager>().BuildingType = BuildingType.Saw;
                        Temp.GetComponent<TileManager>().HasBuilding = true;
                        Temp.GetComponent<TileManager>().UpdateBuilding();
                    }
                       
                    LeChoiceSystem.WeBeChoosing = "Nothing";
                    break;
                case ("Workshop"):
                    tile = Temp.GetComponent<TileManager>();
                    if (tile.TerrainType == TerrainType.Water)
                    {
                        break;
                    }
                    if (BuildingManager.RegisterBuilding(BuildingManager.CreateBuilding(BuildingType.Workshop)))
                    {
                        Temp.GetComponent<TileManager>().BuildingType = BuildingType.Workshop;
                        Temp.GetComponent<TileManager>().HasBuilding = true;
                        Temp.GetComponent<TileManager>().UpdateBuilding();
                    }
                    
                    LeChoiceSystem.WeBeChoosing = "Nothing";
                    break;
                case ("Mine"):
                    tile = Temp.GetComponent<TileManager>();
                    if (tile.TerrainType == TerrainType.Water)
                    {
                        break;
                    }
                    if (tile.TerrainType == TerrainType.Grass)
                    {
                        break;
                    }
                    if (BuildingManager.RegisterBuilding(BuildingManager.CreateBuilding(BuildingType.Mine)))
                    {
                        Temp.GetComponent<TileManager>().BuildingType = BuildingType.Mine;
                        Temp.GetComponent<TileManager>().HasBuilding = true;
                        Temp.GetComponent<TileManager>().UpdateBuilding();
                    }
                    else
                    {
                        Debug.Log("Not Enough Rescourscess");
                    }
                    LeChoiceSystem.WeBeChoosing = "Nothing";
                    break;
                case ("Storage"):
                    tile = Temp.GetComponent<TileManager>();
                    if (tile.TerrainType == TerrainType.Water)
                    {
                        break;
                    }
                    

                    if (BuildingManager.RegisterBuilding(BuildingManager.CreateBuilding(BuildingType.Storage)))
                    {
                        Temp.GetComponent<TileManager>().BuildingType = BuildingType.Storage;
                        Temp.GetComponent<TileManager>().HasBuilding = true;
                        Temp.GetComponent<TileManager>().UpdateBuilding();
                    }
                    else
                    {
                        Debug.Log("Not Enough Rescourscess");
                    }
                    LeChoiceSystem.WeBeChoosing = "Nothing";
                    break;
                case ("Smelter"):
                    tile = Temp.GetComponent<TileManager>();
                    if (tile.TerrainType == TerrainType.Water)
                    {
                        break;
                    }


                    if (BuildingManager.RegisterBuilding(BuildingManager.CreateBuilding(BuildingType.Smelter)))
                    {
                        Temp.GetComponent<TileManager>().BuildingType = BuildingType.Smelter;
                        Temp.GetComponent<TileManager>().HasBuilding = true;
                        Temp.GetComponent<TileManager>().UpdateBuilding();
                    }
                    else
                    {
                        Debug.Log("Not Enough Racecourses");
                    }
                    LeChoiceSystem.WeBeChoosing = "Nothing";
                    break;
                case ("Chapel"):
                    tile = Temp.GetComponent<TileManager>();
                    if (tile.TerrainType == TerrainType.Water)
                    {
                        break;
                    }


                    if (BuildingManager.RegisterBuilding(BuildingManager.CreateBuilding(BuildingType.Chapel)))
                    {
                        DataStorage.Instance.Chapple = true;
                        Temp.GetComponent<TileManager>().BuildingType = BuildingType.Chapel;
                        Temp.GetComponent<TileManager>().HasBuilding = true;
                        Temp.GetComponent<TileManager>().UpdateBuilding();
                    }
                    else
                    {
                        Debug.Log("Not Enough Rescourscess");
                    }
                    LeChoiceSystem.WeBeChoosing = "Nothing";
                    break;
                case ("School"):
                    tile = Temp.GetComponent<TileManager>();
                    if (tile.TerrainType == TerrainType.Water)
                    {
                        break;
                    }
                    if (BuildingManager.RegisterBuilding(BuildingManager.CreateBuilding(BuildingType.School)))
                    {
                        DataStorage.Instance.School = true;
                        Temp.GetComponent<TileManager>().BuildingType = BuildingType.School;
                        Temp.GetComponent<TileManager>().HasBuilding = true;
                        Temp.GetComponent<TileManager>().UpdateBuilding();
                    }
                    else
                    {
                        Debug.Log("Not Enough Rescourscess");
                    }
                    LeChoiceSystem.WeBeChoosing = "Nothing";
                    break;

            }

        }
    }

    
    
    
    
    
    
    
    
    
    
    
    public GameObject ClosestOb(Vector2 SearchPoint)
    {
      




        Collider2D[] colliders = Physics2D.OverlapCircleAll(SearchPoint, SearchRadius, Layer);

        Collider2D ClosestCollider = null;
        float minDistanceNaDruhou = Mathf.Infinity;

       
        foreach (Collider2D col in colliders)
        {
           
            float distSq = (col.transform.position - (Vector3)SearchPoint).sqrMagnitude;

            if (distSq < minDistanceNaDruhou)
            {
                minDistanceNaDruhou = distSq;
                ClosestCollider = col;
            }
        }

       
        return ClosestCollider != null ? ClosestCollider.gameObject : null;


    }
}
