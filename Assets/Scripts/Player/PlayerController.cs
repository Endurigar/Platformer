using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Containers;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float maxSpeed;
    private Rigidbody rigidbody;
    private Vector2 input;
    private Vector3 direction;
    private bool gravityState;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (rigidbody.velocity.magnitude > maxSpeed)
        {
            rigidbody.velocity = rigidbody.velocity.normalized * maxSpeed;
        }
        rigidbody.AddForce(direction * speed);
    }
     
    private void OnMove(InputValue value)
    {
        input = value.Get<Vector2>();
        direction = new Vector3(input.x, 0.0f, input.y);
        Debug.Log(rigidbody.velocity.magnitude);
    }
}
