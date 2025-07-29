using UnityEngine;

public class Player : MonoBehaviour
{
    private bool jump;
    private float horizontalInput;

    // Start is called before the first frame update
    void Start()
    {

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
        if (jump)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * 5, ForceMode.Impulse);
            jump = false; // Reset jump after applying force
        }
    }

}
