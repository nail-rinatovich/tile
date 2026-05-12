using UnityEngine;

public class message : MonoBehaviour
{
    // This function is called when another object enters the trigger collider attached to this object
    void OnTriggerEnter2D(Collider2D other)
    {
        // You can check the tag, name, or other properties of the entering object
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player entered the trigger zone!"); // Log a message to the console

            // Add your custom logic here (e.g., collect an item, activate a door, etc.)
            
            // Example: Disable the current trigger object after it's entered once
            gameObject.SetActive(false); 
        }
    }
    
    // You can also use OnTriggerStay2D and OnTriggerExit2D
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player exited the trigger zone.");
        }
    }
}
