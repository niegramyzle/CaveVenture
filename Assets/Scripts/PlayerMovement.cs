using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float gravity;
    [SerializeField] private Rigidbody rigidbody;
    [SerializeField] private Transform camera;
    [SerializeField] private CharacterController player;

    private Vector3 postionChange;
    public bool isMoving { private set; get; }
    private bool isJumping = false;
    private float jumpPhase = 0;
    [SerializeField] private float jumpDuration;
    [SerializeField] private float jumpForce;

    private Action onUpdate = delegate { };

    private void Awake()
    {
        onUpdate += MovePlayer;
        onUpdate += ResolveJump;
        onUpdate += ResolveGravity;
    }

    private void Update()
    {
        postionChange = Vector3.zero;

        onUpdate();
       

        player.Move(postionChange);
    }

    private void ResolveJump()
    {
        if (!isJumping && Input.GetKey(KeyCode.Space))
        {
            isJumping = true;
            jumpPhase = 0;
        }

        if (isJumping)
        {
            jumpPhase += Time.deltaTime;
            postionChange.y += jumpForce;
        }

        if (jumpPhase > jumpDuration)
        {
            isJumping = false;
        }
    }

    private void MovePlayer()
    {
        isMoving = false;

        if (Input.GetKey(KeyCode.W))
        {
            postionChange += camera.forward * Time.deltaTime * speed;
            isMoving = true;
        }
        if (Input.GetKey(KeyCode.S))
        {
            postionChange += -camera.forward * Time.deltaTime * speed;
            isMoving = true;
        }
        if (Input.GetKey(KeyCode.A))
        {
            postionChange += -camera.right * Time.deltaTime * speed;
            isMoving = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            postionChange += camera.right * Time.deltaTime * speed;
            isMoving = true;
        }
    }

    private void ResolveGravity()
    {
        postionChange.y -= gravity;
    }
}
