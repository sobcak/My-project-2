using UnityEngine;

public class PlacingShitCamera : MonoBehaviour
{


    [SerializeField] private Camera mainCamera;
    [SerializeField] private LayerMask Layer;
    [SerializeField] private float SearchRadius = 20f;


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
        
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("fdzkgdskz");
            Vector3 mouseScreenPos = Input.mousePosition;

            //idk bro matiku ukradena z stack overflow(overflow?)
            mouseScreenPos.z = mainCamera.transform.position.z;

            
            Vector2 mouseWorldPos = mainCamera.ScreenToWorldPoint(mouseScreenPos);

            Debug.Log("World Position: " + mouseWorldPos);
            GameObject Temp = ClosestOb(mouseWorldPos);
            Temp.GetComponent<TileManager>().BuildingType = BuildingType.Building1;
            Temp.GetComponent<TileManager>().HasBuilding = true;
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
