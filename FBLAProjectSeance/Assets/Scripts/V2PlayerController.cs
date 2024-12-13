using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class V2PlayerController : MonoBehaviour
{

    private Vector3 PlayerMovementInput;
    [SerializeField] private Rigidbody PlayerBody;
    [SerializeField] private CapsuleCollider PlayerHitbox;
    [SerializeField] private GameObject PlayerObject;

    [SerializeField] private float speed;
    [SerializeField] private float jumpforce;

    private void Start()
    {
        //Getting Rigidbody and CapsuleCollider
        PlayerBody.freezeRotation = true;

        PlayerMovementInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
    }

     void Update()
    {
        Vector3 MoveVector = transform.TransformDirection(PlayerMovementInput) * speed;
        PlayerBody.linearVelocity = new Vector3(MoveVector.x, PlayerBody.linearVelocity.y, MoveVector.z);
    
        if(Input.GetKeyDown(KeyCode.Space))
        {
            PlayerBody.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
        }
    }

}