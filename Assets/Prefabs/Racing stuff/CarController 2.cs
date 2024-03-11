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


    // Wird aktuell direkt von den Buttons gesetzt!
    private float currentSpeed = 0f;
    private float accelerationInput = 0f;
    private float steeringInput = 0f;

    private void Update()
    {
        // Keyboard input
        float accelerationInput = Input.GetAxis("Vertical");
        // TODO: Bei Rückwärs invertieren!
        float steeringInput = Input.GetAxis("Horizontal");

        // Button input - überholt!
        // accelerationInput = getAcceleration();
        // steeringInput = getSteering();

        // Accelerate
        if (accelerationInput > 0)
        {
            // Min, so that if currentstpeed accelerates over maxspeed, speed is set to maxspeed instead
            currentSpeed = Mathf.Min(currentSpeed + acceleration * Time.deltaTime, maxSpeed);
        }
        // Decelerate
        else if (accelerationInput == 0)
        {
            // do not go lower as 0 when letting go
            currentSpeed = Mathf.Max(currentSpeed - deceleration * Time.deltaTime, 0f);
        }

        // Braking/ backwards
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
                // Invert steering when driving backwards
                steeringInput = -steeringInput;
            }
        }


        carRigidbody.velocity = currentSpeed * carBody.forward;

        // Apply steering
        if (currentSpeed != 0f)
        {
            float rotation = steeringInput * steeringSpeed;
            // float rotation = steeringInput * (currentSpeed > 0 ? 1 : -1) * steeringSpeed;
            carRigidbody.rotation *= Quaternion.Euler(0f, rotation, 0f);
        }
    }

    public float getAcceleration()
    {
        // Wrong buttons!
        // TODO: UI Button script which sets axis values on pointerevent
        // accelerationInput = value;
        if (Input.GetButtonDown("fwd"))
        {
            return 1f;
        }
        else if (Input.GetButtonDown("back"))
        {
            return -1f;
        }
        else
        {
            Debug.Log("noacc");
            return 0f;
        }
    }
    public float getSteering()
    {
        if (Input.GetButton("left"))
        {
            return -1f;
        }
        else if (Input.GetButtonDown("right"))
        {
            return 1f;
        }
        else
        {
            Debug.Log("nosteer");
            return 0f;
        }
    }

    public void accelerate(float value)
    {
        accelerationInput = value;
    }

    public void steer(float value)
    {
        // TODO: Steering does not work ...
        steeringInput = value;
    }

    void OnCollisionEnter3D(Collision collision)
    {
        Debug.Log("Collide enter");

        if (collision.gameObject.tag == "Wall")
        {
            Debug.Log("Wall");
            carRigidbody.constraints = RigidbodyConstraints.FreezeRotation;
        }

    }

    void OnCollisionExit3D(Collision collision)
    {
        Debug.Log("Collide exit");
        if (collision.gameObject.tag == "Wall")
        {
            Debug.Log("Wall");
            carRigidbody.constraints = RigidbodyConstraints.None | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
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