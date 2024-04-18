using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    private Rigidbody rb;

    public float forwardSpeed = 25f;
    public float strafeSpeed = 7f;
    public float hoverSpeed = 5f; //Tehd‰‰n Input Manageriin Hover Input

    public float maxSpeed;

    private float activeForwardSpeed;
    private float activeStrafeSpeed;
    private float activeHoverSpeed;

    public float forwardAcceleration = 2.5f;
    public float strafeAcceleration = 2f;
    public float hoverAcceleration = 2f;

    public float lookRateSpeed = 90f;
    private Vector2 lookInput, screenCenter, mouseDistance;

    private float rollInput; //Tehd‰‰n Input Manageriin Roll Input
    public float rollSpeed = 90f;
    public float rollAcceleration = 3f;
    

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        //M‰‰ritet‰‰n n‰ytˆn keskipiste
        screenCenter.x = Screen.width * 0.5f;
        screenCenter.y = Screen.height * 0.5f;

        //Rajoitetaan kursorin liikkuminen peli-ikkunan sis‰ll‰
        Cursor.lockState = CursorLockMode.Confined;
    }

    void FixedUpdate()
    {
        lookInput.x = Input.mousePosition.x;
        lookInput.y = Input.mousePosition.y;

        //Hiiren et‰isyys n‰ytˆn keskipisteest‰
        mouseDistance.x = (lookInput.x - screenCenter.x) / screenCenter.y;
        mouseDistance.y = (lookInput.y - screenCenter.y) / screenCenter.y;

        mouseDistance = Vector2.ClampMagnitude(mouseDistance, 1f);

        rollInput = Mathf.Lerp(rollInput, Input.GetAxisRaw("Roll"), rollAcceleration * Time.deltaTime);

        transform.Rotate(-mouseDistance.y * lookRateSpeed * Time.deltaTime, mouseDistance.x * lookRateSpeed * Time.deltaTime, rollInput * rollSpeed * Time.deltaTime, Space.Self);

        activeForwardSpeed = Mathf.Lerp(activeForwardSpeed, Input.GetAxisRaw("Vertical") * forwardSpeed, forwardAcceleration * Time.deltaTime);
        activeStrafeSpeed = Mathf.Lerp(activeStrafeSpeed, Input.GetAxisRaw("Horizontal") * strafeSpeed, strafeAcceleration * Time.deltaTime);
        activeHoverSpeed = Mathf.Lerp(activeHoverSpeed, Input.GetAxisRaw("Hover") * hoverSpeed, hoverAcceleration * Time.deltaTime);

        //transform.position += transform.forward * activeForwardSpeed * Time.deltaTime;
        //transform.position += transform.right * activeStrafeSpeed * Time.deltaTime;
        //transform.position += transform.up * activeHoverSpeed * Time.deltaTime;

        
        Vector3 movement = transform.forward * activeForwardSpeed +
                    transform.right * activeStrafeSpeed +
                    transform.up * activeHoverSpeed;

        rb.AddForce(movement * Time.fixedDeltaTime, ForceMode.VelocityChange);

        //Rajoitetaan aluksen nopeutta maksiminopeuteen
        if(rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }

    }
}
