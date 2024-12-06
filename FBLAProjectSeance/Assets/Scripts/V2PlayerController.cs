using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class V2PlayerController : MonoBehaviour
{
    //Get the Rigidbody an order to apply movement
    //Directions needed an order to apply movement
    Rigidbody PlayerBody;
    CharacterController cont;
    CapsuleCollider PlayerHitbox;
    GameObject PlayerObject;
    float playerSpeed = 8.0f;
    float thrust = 5.0f;
    float gravity = -14.0f;
    bool isGround = false;
    bool isJumping = false;
    float jumpcount = 0;
    float jumplimit = 3;

    void Start()
    {
        //Getting Rigidbody and CapsuleCollider
        CharacterController[] tempControllers = GetComponents<CharacterController>();
        cont = tempControllers[0];

        PlayerObject = GetComponent<GameObject>();
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
        int forward = 0;
        int back = 0;
        int left = 0;
        int right = 0;
        int xIn = 0;
        int zIn = 0;
        #endregion
        #region Movement Keyboard Inputs
        if (Input.GetKey(KeyCode.W))
            forward = 1;
        else
            forward = 0;

        if (Input.GetKey(KeyCode.A))
            left = 1;
        else
            left = 0;

        if (Input.GetKey(KeyCode.S))
            back = 1;
        else
            back = 0;

        if (Input.GetKey(KeyCode.D))
            right = 1;
        else
            right = 0;

        // Jumping Is Different so heres a whole dedicated section for it
        if (Input.GetKey(KeyCode.Space))
        {
            isJumping = true;
            PlayerBody.AddForce(0,thrust,0, ForceMode.Impulse);
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
        #endregion

        Vector3 forwards = transform.TransformDirection(Vector3.forward);
        Vector3 rightwards = transform.TransformDirection(Vector3.right);
        Vector3 leftwards = transform.TransformDirection(Vector3.left);
        Vector3 backwards = transform.TransformDirection(Vector3.back);

        xIn = right - left;
        zIn = forward - back;
        Vector3 move = new Vector3(xIn, 0f, zIn);
    }
}