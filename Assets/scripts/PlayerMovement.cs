using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float kameraDistance;
    public Rigidbody2D body;
    //public  Transform kamera;
    public Camera kamera;
    public float akcelerace;

    private Vector2 moveInput;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void FixedUpdate()
    {
Vector2 targetVelocity = moveInput * speed;
        
        body.linearVelocity = Vector2.MoveTowards(body.linearVelocity, targetVelocity, akcelerace * Time.fixedDeltaTime);    }
    void CameraControlls()
    {
        if (Input.GetKeyDown(KeyCode.O) && kamera.orthographicSize < 10){
            kamera.orthographicSize = kamera.orthographicSize + kameraDistance;
        }
        else if (Input.GetKeyDown(KeyCode.P) && kamera.orthographicSize > 4){
            kamera.orthographicSize = kamera.orthographicSize - kameraDistance;
        }
    }
    void Start()
    {
     kamera.orthographicSize = 4f;
    }

    // Update is called once per frame
    void Update()
    {

        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");
        moveInput = new Vector2(xInput, yInput).normalized;
        CameraControlls();

    }
}
