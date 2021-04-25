using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveBumper : MonoBehaviour
{

    HingeJoint2D joint;
    JointMotor2D motor;
    AudioSource audioSource;

    public float bumperSpeed;
    public int upDirection;
    public KeyCode key;
    public Text usesText; 

    public int movesLeft;
    public int round1Moves = 15;
    public int round2Moves = 5;
    public int round3Moves = 5;
    public int round4Moves = 25;


    // Start is called before the first frame update
    void Start()
    {
        joint = GetComponent<HingeJoint2D>();
        audioSource = GetComponent<AudioSource>();
        usesText.text = movesLeft.ToString();
    }

    void Update() {

        if (Input.GetKeyDown(key) && movesLeft > -1) {
            movesLeft--;
            if (movesLeft >= 0)
            {
                audioSource.Play();
            }
        }

        if (Input.GetKey(key) && movesLeft > -1) {
            ChangeMotorSpeed(bumperSpeed * upDirection, joint);
        } else {
            ChangeMotorSpeed(bumperSpeed * -upDirection, joint);
        }

        if(movesLeft >= 0)
        {
            usesText.text = movesLeft.ToString();
        }
    }

    static void ChangeMotorSpeed(float newSpeed, HingeJoint2D joint) {
        JointMotor2D motor = joint.motor;
        motor.motorSpeed = newSpeed;
        joint.motor = motor;
    }

    public void setUses(int round)
    {
        if(round == 1)
        {
            movesLeft += round1Moves;
        }
        if(round == 2)
        {
            movesLeft += round2Moves;
        }
        if (round == 3)
        {
            movesLeft += round3Moves;
        }
        if (round == 4)
        {
            movesLeft += round4Moves;
        }
    }

}
