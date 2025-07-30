using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Transform cameraPosition; // Reference to the camera's transform

    private void Start()
    {

    }
    private void Update()
    {
        transform.position = cameraPosition.position; // Update the position of this object to match the camera's position
    }
}
