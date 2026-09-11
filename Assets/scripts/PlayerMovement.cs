using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float kameraDistance;
    public Rigidbody2D body;
    //public  Transform kamera;
    public Camera kamera;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Movement()
    {
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");
        Vector2 direction = new Vector2(xInput, yInput).normalized;
        body.linearVelocity = direction * speed;

    }
    void CameraControlls()
    {
        if (Input.GetKeyDown(KeyCode.O) && kamera.orthographicSize <= 10){
            kamera.orthographicSize = kamera.orthographicSize + kameraDistance;
        }
        else if (Input.GetKeyDown(KeyCode.P) && kamera.orthographicSize >= 1){
            kamera.orthographicSize = kamera.orthographicSize - kameraDistance;
        }
    }
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        CameraControlls();
        
        

        


 }
}
