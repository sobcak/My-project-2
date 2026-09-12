using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlacingShitCamera : MonoBehaviour
{


    [SerializeField] private Camera mainCamera;
    [SerializeField] private LayerMask Layer;
    [SerializeField] private float SearchRadius = 20f;
    [SerializeField] private GameObject RightClickInfoCanvas;
    [SerializeField] private Text HasBuilding;
    [SerializeField] private Text TerrainType;
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
            TerrainType.text = Temp.GetComponent<TileManager>().TerrainType.ToString();
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
                    Temp.GetComponent<TileManager>().BuildingType = BuildingType.Housing;
                    Temp.GetComponent<TileManager>().HasBuilding = true;
                    Temp.GetComponent<TileManager>().UpdateBuilding();
                    LeChoiceSystem.WeBeChoosing = "Nothing";
                    break;
                case ("Farm"):
                    Temp.GetComponent<TileManager>().BuildingType = BuildingType.Farm;
                    Temp.GetComponent<TileManager>().HasBuilding = true;
                    Temp.GetComponent<TileManager>().UpdateBuilding();
                    BuildingManager.RegisterBuilding(BuildingManager.CreateBuilding(BuildingType.Farm)); // here we create the object
                    LeChoiceSystem.WeBeChoosing = "Nothing";
                    break;
                case ("Forestry"):
                    Temp.GetComponent<TileManager>().BuildingType = BuildingType.Forestry;
                    Temp.GetComponent<TileManager>().HasBuilding = true;
                    Temp.GetComponent<TileManager>().UpdateBuilding();
                    LeChoiceSystem.WeBeChoosing = "Nothing";
                    break;
                case ("Saw"):
                    Temp.GetComponent<TileManager>().BuildingType = BuildingType.Saw;
                    Temp.GetComponent<TileManager>().HasBuilding = true;
                    Temp.GetComponent<TileManager>().UpdateBuilding();
                    LeChoiceSystem.WeBeChoosing = "Nothing";
                    break;
                case ("Workshop"):
                    Temp.GetComponent<TileManager>().BuildingType = BuildingType.Workshop;
                    Temp.GetComponent<TileManager>().HasBuilding = true;
                    Temp.GetComponent<TileManager>().UpdateBuilding();
                    LeChoiceSystem.WeBeChoosing = "Nothing";
                    break;
                case ("Mine"):
                    Temp.GetComponent<TileManager>().BuildingType = BuildingType.Mine;
                    Temp.GetComponent<TileManager>().HasBuilding = true;
                    Temp.GetComponent<TileManager>().UpdateBuilding();
                    BuildingManager.RegisterBuilding(BuildingManager.CreateBuilding(BuildingType.Farm));
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
