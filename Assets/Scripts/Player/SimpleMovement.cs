using UnityEngine;

public class SimpleMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]
    private float speedMovement = 1f;

    [SerializeField]
    private float speedRotation = 1f;

    [SerializeField]
    private float jumpHigh = 1f;
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
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, 0, speedMovement * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-speedMovement * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, 0, -speedMovement * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(speedMovement * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            transform.Translate(0, jumpHigh * Time.deltaTime, 0);
        }

    }

    private void mouseEvents() // Maus Events
    {
        float mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(0, mouseX * speedRotation * Time.deltaTime, 0);
    }
}
