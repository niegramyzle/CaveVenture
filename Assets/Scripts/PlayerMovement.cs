using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private CharacterController charController;
    [SerializeField]
    private MovementInputController movementInputController;
    [SerializeField]
    private float airDrag;

    private float verticalVelocity;

    private Vector3 moveDirection;
    private Vector3 airMove;
    private bool isJump;

    [SerializeField]
    private float slopeForce;
    [SerializeField]
    private float slopeForceRayLenght;

    void Awake()
    {
        verticalVelocity = 0;
        moveDirection=new Vector3(0.0f, 0.0f, 0.0f);
        airMove = new Vector3(0.0f, 0.0f, 0.0f);
        charController = GetComponent<CharacterController>();
    }


    private void flatMovement(float sidewayInputVal, float forwardInputVal, float verticalInputVal)
    {
        moveDirection.x = sidewayInputVal;
        moveDirection.z = forwardInputVal;
        moveDirection = transform.TransformDirection(moveDirection);
        charController.Move(moveDirection * Time.deltaTime); //delta time w jednym czy dwoch miejscach?
    }
      
    private void slopeMovement(float sidewayInputVal, float forwardInputVal)
    {
        moveDirection.x = sidewayInputVal;
        moveDirection.z = forwardInputVal;
        moveDirection.y = Physics.gravity.y * slopeForce * Time.deltaTime;
        moveDirection = transform.TransformDirection(moveDirection);
        charController.Move(moveDirection * Time.deltaTime); //delta time w jednym czy dwoch miejscach?
        moveDirection.y = 0;
    }

    private void airMovement(float sidewayInputVal, float forwardInputVal)
    {
        verticalVelocity += Physics.gravity.y * 2 * Time.deltaTime;
        airMove.x=sidewayInputVal * 0.4f;
        airMove.z=forwardInputVal * 0.4f;
        if (charController.collisionFlags == CollisionFlags.Above && verticalVelocity > 0)
        {
            verticalVelocity = 0;
        }
        airMove.y = verticalVelocity;
        airMove = transform.TransformDirection(airMove);
        moveDirection *= airDrag;
        charController.Move((moveDirection + airMove) * Time.deltaTime);
    }

    public void playerMovement(float sidewayInputVal, float forwardInputVal, float verticalInputVal, bool isJumping)
    {

        Debug.Log(charController.isGrounded);
        if (charController.isGrounded && !onSlope())
        {
            //Debug.Log("kek");
            flatMovement(sidewayInputVal, forwardInputVal, verticalInputVal);
        }
        else if (onSlope() && !isJump)
        {
            slopeMovement(sidewayInputVal, forwardInputVal);
        }
        else
        {
            airMovement(sidewayInputVal, forwardInputVal);
        }

        if (isJumping && !isJump && charController.isGrounded) //wyelminowac skok w powietrzu
        {
            isJump = isJumping;
            moveDirection.y = verticalInputVal;
            verticalVelocity = verticalInputVal;
        }
        else if (charController.isGrounded)
        {
            isJump = false;
        }
    }

    /* public void playerMovement(float sidewayInputVal, float forwardInputVal, float verticalInputVal, bool isJumping)
    {
        verticalVelocity += Physics.gravity.y * 4 * Time.deltaTime;
        Debug.Log(charController.isGrounded);
        if (charController.isGrounded)
        {
            isJump = isJumping;
            verticalVelocity = verticalInputVal;
            forwardVelocity = forwardInputVal;
            sidewayVelocity = sidewayInputVal;
            previousVector.x = sidewayVelocity;
            previousVector.z = forwardVelocity;
            previousVector = transform.TransformDirection(previousVector);
            Vector3 moveDirection = new Vector3(sidewayVelocity, verticalVelocity, forwardVelocity);
            moveDirection = transform.TransformDirection(moveDirection);
            charController.Move(moveDirection * Time.deltaTime);
        }
        else
        {
            sidewayInputVal *= 0.4f;
            forwardInputVal *= 0.4f;
            Vector3 airMove = new Vector3(sidewayInputVal, 0.0f, forwardInputVal);
            if (charController.collisionFlags == CollisionFlags.Above && verticalVelocity > 0)
            {
                verticalVelocity = 0;
            }
            airMove = transform.TransformDirection(airMove);
            airMove.y = verticalVelocity;
            previousVector *= airDrag;
            charController.Move((previousVector + airMove) * Time.deltaTime);
        }
    }*/

    private bool onSlope()
    {

        //if (isJump)
        //    return false;
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



/*public class PlayerMovement : MonoBehaviour
{
    
    private CharacterController charController;
    [SerializeField]
    private MovementInputController movementInputController;

    void Awake()
    {
        charController = GetComponent<CharacterController>();
    }

    public void playerMovement(float horizInputVal, float vertiInputVal)
    {
        charController.SimpleMove(transform.forward * vertiInputVal + transform.right * horizInputVal);
    }

    public IEnumerator jumpEvent(float jumpMultiplier, AnimationCurve jumpFallOff)
    {
        charController.slopeLimit = 90.0f;
        float timeInAir = 0.0f;
        do
        {
            float jumpForce = jumpFallOff.Evaluate(timeInAir);
            charController.Move(Vector3.up * jumpForce * jumpMultiplier * Time.deltaTime);
            timeInAir += Time.deltaTime;
        yield return null;
        } while (!charController.isGrounded && charController.collisionFlags!=CollisionFlags.Above);
        charController.slopeLimit = 45.0f;
        movementInputController.setJumping(false);
    }
}*/
