using UnityEngine;

// This script is a placeholder for player jump functionality.
[RequireComponent(typeof(CharacterController))]
public class PlayerJump : MonoBehaviour
{
    [Header("Jump Settings")]
    [Tooltip("The force applied when the player jumps.")]
    public float jumpForce = 5f;

    [Tooltip("Empty GameObject positioned at the player's feet to check if they are grounded.")]
    public Transform groundCheck;

    [Tooltip("Which Layer count as 'ground' for the player.")]
    public LayerMask groundMask;

    private CharacterController controller;
    private Vector3 velocity;
    private bool isGrounded;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Check if the player is grounded
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.1f, groundMask);

        // Reset vertical speeed
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // Small downward force to keep the player grounded
        }

        // Handle jump input
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpForce * -2f * Physics.gravity.y); // Calculate jump velocity
        }

        // Apply gravity
        velocity.y += Physics.gravity.y * Time.deltaTime;

        // Move the player
        controller.Move(velocity * Time.deltaTime);
    }
}
