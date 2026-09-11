using UnityEngine;

public class TestScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.position = new Vector2(5000, 5000);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Triggered overlap with: " + other.name);
    }
    
}
