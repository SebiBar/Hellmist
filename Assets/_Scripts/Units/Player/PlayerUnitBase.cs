using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnitBase : UnitBase
{
    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private InputReader input;

    [SerializeField] private Vector2 _moveDirection;


    private void Awake()
    {
        GameManager.OnBeforeStateChanged += OnStateChanged;
    }

    private void OnStateChanged(GameState state)
    {

    }

    private void OnEnable()
    {
        input.MoveEvent += HandleMove;
        Debug.Log("Player handleMove");
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
        rb.velocity = new Vector2(_moveDirection.x, _moveDirection.y) * 100; //Stats.MovementSpeed;
    }
}
