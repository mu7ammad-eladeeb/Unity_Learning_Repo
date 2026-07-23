using UnityEngine; // Provides access to core Unity features, classes, and components (like MonoBehaviour, GameObject, Vector3)

// Defines the Collectible class, which inherits from MonoBehaviour so it can be attached to Unity GameObjects
public class Collectible : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Public float exposed in the Unity Inspector to control how fast the object rotates (in degrees per frame)
    public float rotationSpeed;

    // Public reference to a GameObject prefab (like a particle effect) to spawn when collected
    public GameObject onCollectEffect;

    // Called on the frame when the script is enabled, before any Update methods are called
    void Start()
    {
        // Currently empty, but useful if you need to initialize variables or components when the game starts
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, rotationSpeed, 0); // Rotate the collectible around the Y-axis
    }

    // Automatically called by Unity when another Collider enters this object's Trigger collider
    private void OnTriggerEnter(Collider other)
    {
        // Checks if the object entering the trigger has the "Player" tag assigned in the Inspector
        if (other.CompareTag("Player"))
        {
            // Destroy the collectible when the player collides with it
            Destroy(gameObject); // gameObject (with lowercase 'g') refers to the GameObject this script is attached to (the collectible) not the player

            // Instantiate (spawn) the particle effect prefab at this collectible's current position and orientation
            Instantiate(onCollectEffect, transform.position, transform.rotation);
        }

    }
}
/*
A Quick Tip for Smooth Rotation (By Gemini AI):

In your Update() method, consider multiplying rotationSpeed by Time.deltaTime (e.g., transform.Rotate(0, rotationSpeed * Time.deltaTime, 0)).
This makes the rotation frame-rate independent, ensuring the item spins at the exact same speed on both slow and fast devices!
*/