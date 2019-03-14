using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private float rotateSpeed;
    [SerializeField]
    private float movementSpeed;
    [SerializeField]
    private float jumpForce;
    float rotatHorizontal = 0.0f;
    float rotatVertical = 0.0f;
    float distanceToGround = 1.8f;
    [SerializeField]
    private Transform body;
    [SerializeField]
    private Transform head;
    private Rigidbody rb;
    private CapsuleCollider col;
    private CharacterController characterController;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        rb = GetComponent<Rigidbody>();
        col = body.GetComponent<CapsuleCollider>();
    }

    private bool isGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, distanceToGround);
    }

    private void rotation()
    {
        rotatHorizontal += Input.GetAxis("Mouse X") * rotateSpeed * Time.deltaTime;
        float rotatVer = Input.GetAxis("Mouse Y") * rotateSpeed * Time.deltaTime;
        if (rotatVer - rotatVertical < 60 && rotatVer - rotatVertical > -60)
        {
            rotatVertical -= rotatVer;
            Debug.Log(rotatVertical);
        }
        Vector3 vec = new Vector3(0.0f, rotatHorizontal, 0.0f);
        body.eulerAngles = vec;
        vec.x = rotatVertical;
        head.eulerAngles = vec;
    }

    private void movement()
    {
        if (Input.GetKey("w"))
        {
            transform.position += body.forward * movementSpeed * Time.deltaTime;
            //controller.SimpleMove(movementSpeed);
        }
        if (Input.GetKey("s"))
        {
            transform.position -= body.forward * movementSpeed * Time.deltaTime;
        }
        if (Input.GetKey("d"))
        {
            transform.position += body.right * movementSpeed * Time.deltaTime;
        }
        if (Input.GetKey("a"))
        {
            transform.position -= body.right * movementSpeed * Time.deltaTime;
        }
        if (isGrounded() && Input.GetKey("space"))//characterController.isGrounded
        {
            rb.AddForce(Vector3.up * jumpForce * Time.deltaTime, ForceMode.Impulse);
        }
    }

    // Update is called once per frame
    void Update()
    {
        rotation();
        movement();
    }
}
