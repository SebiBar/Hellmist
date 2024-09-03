using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerUnitBase : UnitBase
{
    [SerializeField] protected InputReader input;
    [SerializeField] protected Rigidbody2D rb;

    private Vector2 _moveDirection;

    private bool isDashing = false;
    protected float dashSpeed = 6f;
    protected float dashDuration = 0.3f;
    protected float dashCooldown = 1f;
    private float lastDashTime = -Mathf.Infinity;


    protected virtual void Awake()
    {
        GameManager.OnBeforeStateChanged += OnStateChanged;
    }

    protected virtual void OnStateChanged(GameState state)
    {

    }

    protected virtual void OnEnable()
    {
        input.MoveEvent += HandleMove;
        input.DashEvent += HandleDash;
        input.NormalAttackEvent += HandleNormalAttack;
        input.ChargedAttackEvent += HandleChargedAttack;
    }

    protected virtual void OnDisable()
    {
        input.MoveEvent -= HandleMove;
        input.DashEvent -= HandleDash;
        input.NormalAttackEvent -= HandleNormalAttack;
        input.ChargedAttackEvent -= HandleChargedAttack;
    }

    protected virtual void FixedUpdate()
    {
        if (!isDashing)
            Move();
    }

    protected virtual void Move()
    {
        rb.velocity = Stats.MovementSpeed * new Vector2(_moveDirection.x, _moveDirection.y);
    }

    protected virtual IEnumerator Dash()
    {
        isDashing = true;
        lastDashTime = Time.time;

        rb.velocity = Stats.MovementSpeed * dashSpeed * new Vector2(_moveDirection.x, _moveDirection.y);

        yield return new WaitForSeconds(dashDuration);

        isDashing = false;
    }

    protected virtual void HandleMove(Vector2 moveDirection)
    {
        _moveDirection = moveDirection;
    }

    private void HandleDash()
    {
        if (Time.time >= lastDashTime + dashCooldown) // Check if cooldown period has passed
        {
            StartCoroutine(Dash());
        }
    }

    protected abstract void HandleNormalAttack();

    protected abstract void HandleChargedAttack();
}
