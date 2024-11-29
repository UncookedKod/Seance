using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    //Alright Im revamping all of this to make is simpler
    //private Vector3 PlayerMovementInput;
    //private Vector2 PlayerMouseInput;
    //[Header("Movement")]
    //public float moveSpeed;
    //public Transform orientation;
    //float horizontalInput;
    //float verticalInput;
    //Vector3 moveDirection;
    //Rigidbody rb;

    //Start is called before the first frame update
    private CharacterController cont;
    private float playerSpeed = 8.0f;
    [SerializeField] float jumpHeight = 5;
    [SerializeField] float gravityScale = 5;
    private bool isGround = false;
    private bool isJumping = false;
    private float jumpcount = 0;
    private float jumplimit = 3;

    float velocity;

    void Start()
    {
        CharacterController[] tempControllers = GetComponents<CharacterController>();
        cont = tempControllers[0];

        // rb = GetComponent<Rigidbody>();
        // rb.freezeRotation = true;

    }

    // private void KeyboardInput()
    // {
    //horizontalInput = Input.GetAxisRaw("Horziontal");
    //verticalInput = Input.GetAxisRaw("Vertical");
    //  }


    // Update is called once per frame
    void Update()
    {
        //KeyboardInput();
        //Directional Values
        int right = 0;
        int left = 0;
        int forward = 0;
        int backward = 0;
        int xIn = 0;
        int zIn = 0;

        #region Keyboard Inputs
        if (Input.GetKey("w"))
            forward = 1;
        else
            forward = 0;

        if (Input.GetKey("s"))
            backward = 1;
        else
            backward = 0;

        if (Input.GetKey("a"))
            left = 1;
        else
            left = 0;

        if (Input.GetKey("d"))
            right = 1;
        else
            right = 0;

        #endregion

        xIn = right - left;
        zIn = forward - backward;
        Vector3 move = new Vector3(xIn, 0f, zIn);

        //Gravity Calculations
        velocity += Physics.gravity.y * gravityScale * Time.deltaTime;
        
        //Jumping Mechanics
        if (Input.GetKey(KeyCode.Space) && jumpcount <= jumplimit)
        {
            isJumping = true;
            velocity = Mathf.Sqrt(jumpHeight * -2 * (Physics.gravity.y * gravityScale));
            transform.Translate(new Vector3(0, velocity, 0) * Time.deltaTime);
            jumpcount += 1;
            print($"Jumpcount: {jumpcount}");
        }
        else
        {
            isJumping = false;
        }
        Vector3 downwards = transform.TransformDirection(Vector3.down);
        Vector3 forwards = transform.TransformDirection(Vector3.forward);
        Vector3 rightwards = transform.TransformDirection(Vector3.right);
        Vector3 leftwards = transform.TransformDirection(Vector3.left);
        Vector3 backwards = transform.TransformDirection(Vector3.back);
        //Running & Sprint
        if (Input.GetKey(KeyCode.LeftShift))
        {
            playerSpeed = 16.0f;
        }
        else
        {
            playerSpeed = 8.0f;
        }
        //Raycasting to see objects below him
        if (!isJumping)
        {
            if (Physics.Raycast(transform.position, downwards, 1))
            {
                print("Detected an Object");
                isGround = true;
                jumpcount = 0;
                print($"Jumpcount: {jumpcount}");
            }
            else
            {
                isGround = false;
            }
        }
        //Toggling Gravity
        if (!isGround)
        {
            transform.Translate(new Vector3(0, velocity, 0) * Time.deltaTime);
        }

        //Regular Movement
        if (Physics.Raycast(transform.position, forwards, 2) || Physics.Raycast(transform.position, rightwards, 2) || Physics.Raycast(transform.position, leftwards, 2) || Physics.Raycast(transform.position, backwards, 2))
        {
            print("Touching an Object");
            isGround = true;
        }
        else
        {
            isGround = false;
        }
        if (!isGround)
            transform.Translate(move * playerSpeed * Time.deltaTime);
        /*
        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }
        */

        if (Input.GetKey("e"))
        {

        }

    }

    private void LateUpdate()
    {

    }
}
