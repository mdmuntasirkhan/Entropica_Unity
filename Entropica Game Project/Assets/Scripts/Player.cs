using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask playerMask;
    private bool jump;
    private float horizontalInput;
    private int superJumpCount = 0;
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
    }

    // FixedUpdate is called at a fixed time interval, typically used for physics calculations.
    void FixedUpdate()
    {
        // Apply horizontal movement based on user input.
        rbComponent.linearVelocity = new Vector3(horizontalInput * 5, rbComponent.linearVelocity.y, 0);

        if (Physics.OverlapSphere(groundCheck.position, 0.1f, playerMask).Length == 0)
        {
            return; // Exit if the player is not grounded (not touching the ground).   
        }

        if (jump)
        {
            float jumpForce = 5f; // Increase jump force based on super jump count
            if (superJumpCount > 0)
            {
                jumpForce *= 2;
                superJumpCount--; // Decrease super jump count after using it
            }
            rbComponent.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jump = false; // Reset jump after applying force
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
            Destroy(other.gameObject); // Destroy the object if it is on layer 7
            superJumpCount++; // Increment the super jump count
        }
    }

}
