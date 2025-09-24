using UnityEngine;

public class SimpleMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]
    private float speedMovement = 5f;

    [SerializeField]
    private float speedRotation = 50f;
    private Rigidbody rb;
    private Animator animator;
    
    

    [SerializeField]
    private float jumpHigh = 1f;

    
    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        animator = gameObject.GetComponent<Animator>();
    }
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        this.keyboardEvents();
        this.mouseEvents();
    }

    // Time.DeltaTime is the time in seconds it took to complete the last frame (Read Only). This can be used to make things frame rate independent.
    // Es ist ein Multiplikator, der dafür sorgt, dass die Bewegungsgeschwindigkeit unabhängig von der Framerate ist.
    private void keyboardEvents() // Tastatur Events
    {
        bool moveflag = false;
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, 0, speedMovement * Time.deltaTime);
            animator.SetFloat("Velocity", 1.0f);
            moveflag = true;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-speedMovement * Time.deltaTime, 0, 0);
            animator.SetFloat("Velocity", 1.0f);
            moveflag = true;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, 0, -speedMovement * Time.deltaTime);
            animator.SetFloat("Velocity", 1.0f);
            moveflag = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(speedMovement * Time.deltaTime, 0, 0);
            animator.SetFloat("Velocity", 1.0f);
            moveflag = true;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            transform.Translate(0, jumpHigh * Time.deltaTime, 0);
            animator.SetFloat("Velocity", 1.0f);
            moveflag = true;
        }
        if (!moveflag)
        {
            animator.SetFloat("Velocity", 0.0f);
        }

    }
    private void mouseEvents()
    {
        float mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(0, mouseX * speedRotation, 0);
    }
}
