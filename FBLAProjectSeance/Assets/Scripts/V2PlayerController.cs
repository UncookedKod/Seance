using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class V2PlayerController : MonoBehaviour
{
    //Get the Rigidbody an order to apply movement
    //Directions needed an order to apply movement
    Rigidbody PlayerBody;
    CapsuleCollider PlayerHitbox;
    float thrust = 20.0f;
    float gravity = -14.0f;
    bool isGround = false;
    bool isJumping = false;
    float jumpcount = 0;
    float jumplimit = 3;

    void Start()
    {
        //Getting Rigidbody and CapsuleCollider
        PlayerBody = GetComponent<Rigidbody>();
        PlayerHitbox = GetComponent<CapsuleCollider>();
        PlayerBody.freezeRotation = true;
    }

    void Update()
    {
        #region Directional Values
        //If its 0 its not supposed to move
        //Standard Movement will be equal to 1
        //Any values higher than 1 will be assigned a special value that will be listed
        float Forward = 5.0f;
        float Backward = -5.0f;
        float Left = -5.0f;
        float Right = 5.0f;
        #endregion
        #region Movement Keyboard Inputs
        if (Input.GetKey(KeyCode.W))
        {
            Forward = 5.0f;
            PlayerBody.AddForce(0, 0, Forward, ForceMode.VelocityChange);
        }
        else
            Forward = 0.0f;

        if (Input.GetKey(KeyCode.S))
        {
            Backward = -5.0f;
            PlayerBody.AddForce(0, 0, Backward, ForceMode.VelocityChange);
        }
        else
            Backward = 0.0f;

        if (Input.GetKey(KeyCode.A))
        {
            Left = -5.0f;
            PlayerBody.AddForce(Left, 0, 0, ForceMode.VelocityChange);
        }
        else
            Left = 0.0f;

        if (Input.GetKey(KeyCode.D))
        {
            Right = 5.0f;
            PlayerBody.AddForce(Right, 0, 0, ForceMode.VelocityChange);
        }
        else
            Right = 0.0f;

        // Jumping Is Different so heres a whole dedicated section for it
        if (Input.GetKey(KeyCode.Space))
        {
            isJumping = true;
            PlayerBody.AddForce(0,thrust,0, ForceMode.VelocityChange);
        }
        else
        {
            isJumping = false;
            //PlayerBody.AddForce(0, gravity, 0, ForceMode.VelocityChange);
        }

        /*
        if (isGround == false)
            PlayerBody.AddForce(0, gravity, 0, ForceMode.VelocityChange);
        else
            gravity = 0;
        */

        //Lazier Code for Shift Sprint
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Forward = 10.0f;
        }
        else
        {
            Forward = 5.0f;
        }
        #endregion


    }
}