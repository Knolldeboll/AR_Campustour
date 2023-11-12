using UnityEngine;

public class CarController2 : MonoBehaviour
{
    public Rigidbody carRigidbody;
    public Transform carBody;

    public float maxSpeed = 10f;
    public float acceleration = 5f;
    public float deceleration = 2f;
    public float brakingForce = 10f;  // Adjust this value for braking
    public float maxReverseSpeed = 3f;  // Maximum backward speed
    public float steeringSpeed = 2f;

    private float currentSpeed = 0f;

    private void Update()
    {
        // Get user input for acceleration, braking, and steering
        float accelerationInput = Input.GetAxis("Vertical");
        float steeringInput = Input.GetAxis("Horizontal");

        // Apply acceleration
        if (accelerationInput > 0)
        {
            // Min, so that if currentstpeed accelerates over maxspeed, speed is set to maxspeed instead
            currentSpeed = Mathf.Min(currentSpeed + acceleration * Time.deltaTime, maxSpeed);
        }
        // Apply deceleration when not accelerating
        else if (accelerationInput == 0)
        {
            // do not go lower as 0 when letting go
            currentSpeed = Mathf.Max(currentSpeed - deceleration * Time.deltaTime, 0f);
        }

        // Apply braking or move backward when the "back" button is pressed
        if (accelerationInput < 0)
        {
            if (currentSpeed > 0)
            {

                // Apply braking
                currentSpeed = Mathf.Max(currentSpeed - brakingForce * Time.deltaTime, 0f);
                // TODO: Toggle higher steeringSpeed
            }
            else
            {
                // Move backward, but not as fast as it can forward
                currentSpeed = Mathf.Max(currentSpeed - acceleration * Time.deltaTime, -maxReverseSpeed);
            }
        }

        // Apply force for acceleration, braking, and backward movement
        carRigidbody.velocity = currentSpeed * carBody.forward;

        // Apply steering
        if (currentSpeed != 0f)
        {
            float rotation = steeringInput * steeringSpeed;
            // float rotation = steeringInput * (currentSpeed > 0 ? 1 : -1) * steeringSpeed;
            carRigidbody.rotation *= Quaternion.Euler(0f, rotation, 0f);
        }
    }
}


/*

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    private float verticalInput, horizontalInput; //, currentForce;
    public float currentForce;
    private Rigidbody rigidBody;

    public float forceInc;
    // More acceleration than slowdown
    public float accelerationMultiplier;
    public float maxForce;

    void Start()
    {
        currentForce = 0f;
        rigidBody = GetComponent<Rigidbody>();
        //rigidBody.AddRelativeForce(Vector3.forward*1);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(rigidBody.velocity);
    }

    void FixedUpdate()
    {
        checkInput();
        controlForce();
        // continuously rotate by 0.5
        controlSteering();
    }

    void checkInput()
    {
      horizontalInput = Input.GetAxis("Horizontal");
       verticalInput=  Input.GetAxis("Vertical");
    }

    void controlForce()
    {
        Debug.Log(currentForce);
        switch (verticalInput)
        {
            case -1:
                break;
            case 0:
                break;
            case 1:
                if( currentForce<maxForce)
                {

                    rigidBody.AddRelativeForce(Vector3.forward*forceInc*accelerationMultiplier);
                    currentForce += forceInc * accelerationMultiplier;
                }
                break;

        }
    }
    void controlSteering()
    {
        //
        rigidBody.rotation *= Quaternion.Euler(0f,0.5f,0f);
    }

    void applyForce()
    {

    }

}
*/