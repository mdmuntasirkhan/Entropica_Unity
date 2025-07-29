using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]private Transform groundCheck;
    [SerializeField]private LayerMask playerMask;
    private bool jump;
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
        if (Physics.OverlapSphere(groundCheck.position, 0.1f, playerMask).Length == 0)
        {
            return; // Exit if the player is not grounded (not touching the ground).   
        }
        
        if (jump)
        {
            rbComponent.AddForce(Vector3.up * 5, ForceMode.Impulse);
            jump = false; // Reset jump after applying force
        }
        // Apply horizontal movement based on user input.
        rbComponent.linearVelocity = new Vector3(horizontalInput * 5, rbComponent.linearVelocity.y, 0);
    }
}
