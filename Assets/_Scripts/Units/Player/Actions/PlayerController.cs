using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;

    [SerializeField] private InputReader input;

    [SerializeField] private float speed;   // get speed from player script
    [SerializeField] private Vector2 _moveDirection;

    private void OnEnable()
    {
        input.MoveEvent += HandleMove;
    }

    private void OnDisable()
    {
        input.MoveEvent -= HandleMove;
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void HandleMove(Vector2 moveDirection)
    {
        _moveDirection = moveDirection;
    }

    private void Move()
    {
        rb.velocity = new Vector2(_moveDirection.x, _moveDirection.y) * speed;
    }

}
