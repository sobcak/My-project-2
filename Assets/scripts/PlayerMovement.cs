using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float kameraDistance;
    public Rigidbody2D body;
    //public  Transform kamera;
    public Camera kamera;
    public float akcelerace;
    public GameObject PauseMenuUi;
    private Vector2 moveInput;
    bool GameIsPaused = false;
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
    void Pause()
    {
        PauseMenuUi.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    void Resume()
    {
        PauseMenuUi.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    void Start()
    {
     kamera.orthographicSize = 4f;
     GameIsPaused = false;
    }

    // Update is called once per frame
    void Update()
    {

        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");
        moveInput = new Vector2(xInput, yInput).normalized;
        CameraControlls();
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Esc pressed");
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

    }
}
