using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drive : MonoBehaviour
{


    public WheelJoint2D frontWheel, backWheel;

    private JointMotor2D backMotor, frontMotor;

    public float ForwardSpeed;
    public float BackwardSpeed;

    public float Torque;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float X = Input.GetAxis("Horizontal");

        if(X > 0)
        {
            backMotor.motorSpeed = ForwardSpeed;
            frontMotor.motorSpeed = ForwardSpeed;

            backMotor.maxMotorTorque = Torque;
            frontMotor.maxMotorTorque = Torque;

            frontWheel.motor = frontMotor;
            backWheel.motor = backMotor;

            
        }
    }
}
