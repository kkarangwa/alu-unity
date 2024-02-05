using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float JumpForce = 300f;
    [SerializeField] private float MovementSpeed = 5f; // Adjusted for more control
    private float directionX;
    private float directionZ;
    private float maxVelocity = 5f; // Limit maximum velocity

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        // Freeze rotation constraints
        rb.freezeRotation = true;
    }

    void Update()
    {
        Movements();
        Jumping();
    }

    void Jumping()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * JumpForce, ForceMode.VelocityChange);
        }
    }

    void Movements()
    {
        directionX = Input.GetAxisRaw("Horizontal");
        directionZ = Input.GetAxisRaw("Vertical");

        Vector3 movements = new Vector3(directionX, 0, directionZ);
        
        // Limit maximum velocity
        if (rb.velocity.magnitude > maxVelocity)
        {
            rb.velocity = rb.velocity.normalized * maxVelocity;
        }

        // Apply force using ForceMode.VelocityChange for more control
        rb.AddForce(movements * MovementSpeed, ForceMode.VelocityChange);
    }
}
