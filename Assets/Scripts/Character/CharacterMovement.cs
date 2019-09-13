using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterMovement : MonoBehaviour
{

    private CharacterController charController;
    private CharacterStats stats;
    [SerializeField] private float airDrag;
    [SerializeField] private float slopeForce;
    [SerializeField] private float slopeForceRayLenght;
    private Vector3 moveDirection;
    private Vector3 airMove;
    private bool isJump;

    public float gravityMultiplier=1;

    public Vector3 Offset { get; set; }
    public bool OnPlatform { get; set; }

    public UnityEvent onMovingStart;
    public UnityEvent onMovingEnd;

    void Awake()
    {
        moveDirection=new Vector3(0.0f, 0.0f, 0.0f);
        airMove = new Vector3(0.0f, 0.0f, 0.0f);
        charController = GetComponent<CharacterController>();
        stats = GetComponent<CharacterStats>();
    }


    private void flatMovement(float sidewayInputVal, float forwardInputVal)
    {
        if (!OnPlatform)
        {
            moveDirection.x = sidewayInputVal;
            moveDirection.z = forwardInputVal;
            moveDirection = transform.TransformDirection(moveDirection);
            charController.Move(moveDirection * Time.deltaTime);
        }
        else if(sidewayInputVal !=0 || forwardInputVal!=0)
        {
            onMovingStart.Invoke();
            moveDirection.x = sidewayInputVal;
            moveDirection.z = forwardInputVal;
            moveDirection = transform.TransformDirection(moveDirection);
            //charController.Move(moveDirection * Time.deltaTime);
            charController.Move((moveDirection) * Time.deltaTime + Offset);
        }
    }
      
    private void slopeMovement(float sidewayInputVal, float forwardInputVal)
    {
        onMovingStart.Invoke();
        moveDirection.x = sidewayInputVal;
        moveDirection.z = forwardInputVal;
        moveDirection.y = Physics.gravity.y* gravityMultiplier * slopeForce * Time.deltaTime;
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
            moveDirection.y += Physics.gravity.y*gravityMultiplier * stats.GravityMultiplier * Time.deltaTime;
        }

        airMove.x=sidewayInputVal * stats.AirMoveMultiplier;
        airMove.z=forwardInputVal * stats.AirMoveMultiplier;
        moveDirection.x *= airDrag * Time.deltaTime; 
        moveDirection.z *= airDrag * Time.deltaTime;
        airMove = transform.TransformDirection(airMove);
        moveDirection = transform.TransformDirection(moveDirection);
        charController.Move((moveDirection + airMove)*Time.deltaTime);
    }

    public void movement(float sidewayInputVal, float forwardInputVal, bool isJumping, bool isAcceleration)
    {
        sidewayInputVal *= stats.MovementSpeed;
        if (isAcceleration)
            forwardInputVal *= stats.MovementSpeed * stats.Acceleration;
        else
            forwardInputVal *= stats.MovementSpeed;

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
            moveDirection.y = stats.JumpSpeed;
        }
        else if (charController.isGrounded)
        {
            isJump = false;
        }
        onMovingEnd.Invoke();
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