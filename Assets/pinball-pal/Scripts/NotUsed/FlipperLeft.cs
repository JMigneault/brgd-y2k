using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperLeft : MonoBehaviour
{
    HingeJoint2D joint;
    JointMotor2D motor;
    float speed = 1000;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start Hinge");
        joint = GetComponent<HingeJoint2D>();
        motor = joint.motor;
        motor.motorSpeed = 0;
        joint.useMotor = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("a"))
        {
            motor.motorSpeed = -speed;
            joint.motor = motor;
        }
        else
        {
            motor.motorSpeed = speed;
            joint.motor = motor;
        }
    }
}
