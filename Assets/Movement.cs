using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 1f;
    public float maxRotationAngle = 1f;

    private Vector3 movementDirection = Vector3.zero;

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementInput = new Vector3(horizontalInput, 0f, verticalInput);
        movementDirection = Quaternion.Euler(0f, transform.eulerAngles.y, 0f) * movementInput;

        if (movementDirection.magnitude > 0)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movementDirection);
            float step = rotationSpeed * Time.deltaTime;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, step * maxRotationAngle);
        }
    }

    void FixedUpdate()
    {
        if (movementDirection.magnitude > 0)
        {
            Vector3 movement = movementDirection.normalized * moveSpeed;
            transform.position += movement * Time.fixedDeltaTime;
        }
    }
}