using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
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
}
