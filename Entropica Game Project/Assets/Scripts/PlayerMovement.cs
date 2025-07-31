using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    [Tooltip("Speed of the player movement.")]
    public float speed = 5f;

    private CharacterController controller;

    void Start()
    {
        // Get the CharacterController component attached to the player
        controller = GetComponent<CharacterController>();
    }
    void Update()
    {
        // Get input from the user
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        // Create a movement vector based on input
        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        // Move the controller(Handle collision and gravity)
        controller.Move(move * speed * Time.deltaTime);
    }
}
