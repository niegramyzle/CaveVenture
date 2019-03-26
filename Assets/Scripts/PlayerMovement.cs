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
    private float forwardVelocity;
    private float sidewayVelocity;
    private Vector3 previousVector;


    void Awake()
    {
        verticalVelocity = 0;
        previousVector = new Vector3(0.0f, 0.0f, 0.0f);
        charController = GetComponent<CharacterController>();
    }

    public void playerMovement(float sidewayInputVal, float forwardInputVal, float verticalInputVal)
    {
        Debug.Log(charController.isGrounded);
        if (charController.isGrounded)
        {
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
            verticalVelocity += Physics.gravity.y * 2 * Time.deltaTime;
            airMove = transform.TransformDirection(airMove);
            airMove.y = verticalVelocity;
            previousVector *= airDrag;
            charController.Move((previousVector + airMove) * Time.deltaTime);
        }
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
