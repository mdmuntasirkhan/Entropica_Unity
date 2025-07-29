using UnityEngine;

public class Player : MonoBehaviour
{
    private bool jump;
    private bool isGrounded;
    private float horizontalInput;
    private Rigidbody rbComponent;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize the Rigidbody component.
        rbComponent = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the space key is pressed down.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Log a message to the console.
            Debug.Log("Space key was pressed!");
            jump = true;
        }
        // Get horizontal input from the user (A/D keys or left/right arrows).
        horizontalInput = Input.GetAxis("Horizontal");
    }

    // FixedUpdate is called at a fixed time interval, typically used for physics calculations.
    void FixedUpdate()
    {
        // Check if the player is grounded before allowing a jump.
        if (!isGrounded)
        {
            jump = false; // Prevent jumping if not grounded
        }   
        if (jump)
        {
            rbComponent.AddForce(Vector3.up * 5, ForceMode.Impulse);
            jump = false; // Reset jump after applying force
        }
        // Apply horizontal movement based on user input.
        rbComponent.linearVelocity = new Vector3(horizontalInput * 5, rbComponent.linearVelocity.y, 0);
    }
    // This method is called when the player collides with another collider.
    private void OnCollisionEnter(Collision collision)
    {
        isGrounded = true; // Set isGrounded to true when colliding with something
    }
    // This method is called when the player collides with another collider.
    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false; // Set isGrounded to false when no longer colliding
    }

}
