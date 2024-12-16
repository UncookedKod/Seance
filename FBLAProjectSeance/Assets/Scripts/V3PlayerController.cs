using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class V3PlayerController : MonoBehaviour
{
    [SerializeField] private CapsuleCollider PlayerHitbox;
    [SerializeField] private Rigidbody PlayerBody;
    private CharacterController Controller;
    private Vector3 PlayerMovementInput;

    [SerializeField] private float PlayerSpeed;
    [SerializeField] private float JumpForce;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayerBody.freezeRotation = true;
        Controller = GetComponent<CharacterController>();

        PlayerMovementInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

    }
    // Update is called once per frame
     void Update()
    {
        Vector3 MoveVector = transform.TransformDirection(PlayerMovementInput) * PlayerSpeed;
        PlayerBody.linearVelocity = new Vector3(MoveVector.x, PlayerBody.linearVelocity.y, MoveVector.z);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayerBody.AddForce(Vector3.up*JumpForce,ForceMode.Impulse);
            print("Jumped!");
        }

        #region Keyboard Inputs
        
        /*if (Input.GetKey("w"))
        {
            PlayerBody.transform.position += (Vector3.forward * Time.deltaTime) * PlayerSpeed;
            print("W!");
        }*/
        /*if (Input.GetKey("s"))
        {
            PlayerBody.transform.position += (Vector3.back * Time.deltaTime) * PlayerSpeed;
            print("S!");
        }*/
        if (Input.GetKey("a"))
        {
            PlayerBody.transform.position += (Vector3.left * Time.deltaTime) * PlayerSpeed;
            print("A!");
        }
        if (Input.GetKey("d"))
        {
            PlayerBody.transform.position += (Vector3.right * Time.deltaTime) * PlayerSpeed;
            print("D!");
        }
        #endregion
    }

}
