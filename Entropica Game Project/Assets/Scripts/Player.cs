using UnityEngine;

public class Player : MonoBehaviour
{
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

            GetComponent<Rigidbody>().AddForce(Vector3.up * 5, ForceMode.Impulse);

        }
    }

}
