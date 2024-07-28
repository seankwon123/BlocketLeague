using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriveTwin : MonoBehaviour
{

    private Rigidbody2D Car;

    // Driving stuff
    private JointMotor2D backMotor, frontMotor;

    public WheelJoint2D frontWheel, backWheel;
    public float forwardSpeed;
    public float backwardSpeed;
    public float torque;

    // Jumping stuff
    private int remainingJumps;
    private int maxJumps = 2;
    private bool isGrounded;

    private Transform[] wheelTransforms;

    public float jump = 700f;
    public float groundCheckDistance = 2.0f;

    // Tilting stuff
    public float airTiltTorque = 50f; // Adjust this value to control tilt speed
    public float maxTiltSpeed = 150f;
   

    // Start is called before the first frame update
    void Start()
    {
        Car = GetComponent<Rigidbody2D>();
        remainingJumps = maxJumps;
        isGrounded = true;
        wheelTransforms = new Transform[] { frontWheel.transform, backWheel.transform };

    }

    // Update is called once per frame
    void Update()
    {
        // CheckGrounded();
        HandleDriving();
        HandleJumping();
        HandleAirTilt();

    }


    void HandleDriving()
    {
        
        float verticalInput = Input.GetAxis("Vertical");
        if (verticalInput != 0)
        {
            float speed = verticalInput > 0 ? forwardSpeed : backwardSpeed;
            SetMotorSpeed(speed);
        }
        // if (horizontalBackwardInput) {
        //     SetMotorSpeed(backwardSpeed);
        // }
        // else if (horizontalForwardInput) {
        //     SetMotorSpeed(forwardSpeed);
        // }
        else
        {
            SetMotorSpeed(0);
        }
    }

    void SetMotorSpeed(float speed)
    {
        backMotor.motorSpeed = frontMotor.motorSpeed = speed;
        backMotor.maxMotorTorque = frontMotor.maxMotorTorque = torque;
        frontWheel.motor = frontMotor;
        backWheel.motor = backMotor;
    }

    void HandleJumping()
    {
        if (Input.GetKeyDown("right ctrl") && remainingJumps > 0)
        {
            Car.AddForce(Vector2.up * jump);
            remainingJumps--;
            isGrounded = false;
        }
    }

    // void CheckGrounded()
    // {
    //     // Check if the car itself is touching the floor
    //     if (Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, LayerMask.GetMask("Floor")))
    //     {
    //         SetGrounded();
    //         Debug.Log("car touched floor");

    //         return;
    //     }

    //     // Check if either wheel is touching the floor
        
    //     if (Physics2D.Raycast(wheelTransforms[0].position, Vector2.down, groundCheckDistance, LayerMask.GetMask("Floor"))
    //         && Physics2D.Raycast(wheelTransforms[1].position, Vector2.down, groundCheckDistance, LayerMask.GetMask("Floor")))
    //     {
    //         SetGrounded();
    //         Debug.Log("wheels touched floor");
    //         return;
    //     }
        
    // }


    void SetGrounded()
    {
        if (!isGrounded)
        {
            isGrounded = true;
            remainingJumps = maxJumps;
            Debug.Log("RESET JUMPS");

        }
        
        isGrounded = true;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Top"))
        {
            SetGrounded();
        }
    }

    void HandleAirTilt()
    {
        if (!isGrounded)
        {
            float tiltInput = 0f;
            
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                tiltInput = 1f;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                tiltInput = -1f;
            }
            
             if (tiltInput != 0)
            {
                if (Mathf.Abs(Car.angularVelocity) < maxTiltSpeed)
                {
                    Car.AddTorque(tiltInput * airTiltTorque);
                }
            }


            // Clamp the angular velocity to the maximum tilt speed
            Car.angularVelocity = Mathf.Clamp(Car.angularVelocity, -maxTiltSpeed, maxTiltSpeed);

        }


    }

}
