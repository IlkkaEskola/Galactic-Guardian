using UnityEngine;

public class SkyboxMovement : MonoBehaviour
{
    public Transform spaceship;

    // Adjust these values to control the sensitivity of skybox movement
    public float rotationSpeed = 0.1f;

    private Vector3 previousPosition;

    void Start()
    {
        previousPosition = spaceship.position;
    }

    void Update()
    {
        // Calculate the change in position of the spaceship
        Vector3 deltaPosition = spaceship.position - previousPosition;

        // Calculate rotation angles based on spaceship movement
        float rotationX = -deltaPosition.z * rotationSpeed;
        float rotationY = deltaPosition.x * rotationSpeed;

        // Apply rotation to the skybox
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * rotationSpeed);
        RenderSettings.skybox.SetFloat("_Exposure", Mathf.Clamp(deltaPosition.magnitude, 0f, 1f)); // Adjust exposure based on spaceship speed

        // Store the current position for the next frame
        previousPosition = spaceship.position;
    }
}
