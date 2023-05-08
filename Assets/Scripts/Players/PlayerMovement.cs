using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 12f;
    [SerializeField] private Animator animator;

    private float horizontalInput;
    private float verticalInput;

    public Transform orientation;
    private Vector3 moveDirection;

    private Rigidbody rb;



    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

    }

    private void FixedUpdate()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        rb.AddForce(moveDirection.normalized * movementSpeed, ForceMode.Force);
        animator.SetFloat("Velocity", rb.velocity.magnitude, 0.1f, Time.deltaTime);

    }
}