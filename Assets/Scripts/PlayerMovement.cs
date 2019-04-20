using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private CharacterController charController;
    [SerializeField]
    private MovementInputController movementInputController;// to do usuniecia
    [SerializeField]
    private float airDrag;
    [SerializeField]
    private float jumpSpeed;
    [SerializeField]
    private float movementSpeed;
    [SerializeField]
    private float acceleration;

    [SerializeField]
    private float gravityMultiplier;
    [SerializeField]
    private float airMoveMultiplier;

    private Vector3 moveDirection;
    private Vector3 airMove;
    private bool isJump;

    [SerializeField]
    private float slopeForce;
    [SerializeField]
    private float slopeForceRayLenght;

    void Awake()
    {
        moveDirection=new Vector3(0.0f, 0.0f, 0.0f);
        airMove = new Vector3(0.0f, 0.0f, 0.0f);
        charController = GetComponent<CharacterController>();
    }


    private void flatMovement(float sidewayInputVal, float forwardInputVal)
    {
        moveDirection.x = sidewayInputVal;
        moveDirection.z = forwardInputVal;
        moveDirection = transform.TransformDirection(moveDirection);
        charController.Move(moveDirection * Time.deltaTime);
    }
      
    private void slopeMovement(float sidewayInputVal, float forwardInputVal)
    {
        moveDirection.x = sidewayInputVal;
        moveDirection.z = forwardInputVal;
        moveDirection.y = Physics.gravity.y * slopeForce * Time.deltaTime;
        moveDirection = transform.TransformDirection(moveDirection);
        charController.Move(moveDirection * Time.deltaTime); 
        moveDirection.y = 0;
    }

    private void airMovement(float sidewayInputVal, float forwardInputVal)
    {
        if (charController.collisionFlags == CollisionFlags.Above && moveDirection.y > 0)
        {
            moveDirection.y = 0;
        }
        else
        {
            moveDirection.y += Physics.gravity.y * gravityMultiplier * Time.deltaTime;
        }

        airMove.x=sidewayInputVal * airMoveMultiplier;
        airMove.z=forwardInputVal * airMoveMultiplier;
        Debug.Log(moveDirection.y);
        moveDirection.x *= airDrag * Time.deltaTime; 
        moveDirection.z *= airDrag * Time.deltaTime;
        airMove = transform.TransformDirection(airMove);
        moveDirection = transform.TransformDirection(moveDirection);
        charController.Move((moveDirection + airMove)*Time.deltaTime);
    }

    public void playerMovement(float sidewayInputVal, float forwardInputVal, bool isJumping, bool isAcceleration)
    {
        sidewayInputVal *= movementSpeed;
        if(isAcceleration)
            forwardInputVal *= movementSpeed*acceleration;
        else
            forwardInputVal *= movementSpeed;

        if (charController.isGrounded && !onSlope())
        {
            flatMovement(sidewayInputVal, forwardInputVal);
        }
        else if (onSlope() && !isJump)
        {
            slopeMovement(sidewayInputVal, forwardInputVal);
        }
        else
        {
           airMovement(sidewayInputVal, forwardInputVal);
        }
                          
        if (isJumping && !isJump && charController.isGrounded)
        {
            isJump = isJumping;
            moveDirection.y = jumpSpeed;
        }
        else if (charController.isGrounded)
        {
            isJump = false;
        }
    }


    private bool onSlope()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.down, out hit, charController.height / 2 * slopeForceRayLenght))
        {
            if (hit.normal != Vector3.up)
            {
                return true;
            }
        }
        return false;
    }
}


