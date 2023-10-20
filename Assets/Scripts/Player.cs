using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 150f;
    [SerializeField]
    private float maxSpeed = 8f;
    [SerializeField]
    private float idleFriction = 0.9f;
    [SerializeField]
    private int _cooldownTime;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Animator _animator;

    [SerializeField]
    private GameObject _colliderArea;
    private Collider2D _areacollider;


    private Vector2 moveInput = Vector2.zero;

    bool IsMoving {

         set {
            _isMoving = value;
            _animator.SetBool("isMoving", _isMoving);
        }
    }

    private bool _isMoving;
    public bool _cooldownEnabled = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        _areacollider = _colliderArea.GetComponent<Collider2D>();

        _animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {

        if (moveInput != Vector2.zero)
        {

            rb.velocity = Vector2.ClampMagnitude(rb.velocity + (moveInput * moveSpeed * Time.deltaTime), maxSpeed);

            // Control whether looking left or right
            if (moveInput.x > 0)
            {
                spriteRenderer.flipX = false;
                gameObject.BroadcastMessage("Right", true);
                _animator.SetBool("AttackRight", true);
                _animator.SetBool("AttackTop", false);

                _animator.SetBool("MoveRight", true);
                _animator.SetBool("MoveTop", false);
                _animator.SetBool("MoveDown", false);
            }
            else if (moveInput.x < 0)
            {
                spriteRenderer.flipX = true;
                gameObject.BroadcastMessage("Right", false);
                _animator.SetBool("AttackRight", true);
                _animator.SetBool("AttackTop", false);

                _animator.SetBool("MoveRight", true);
                _animator.SetBool("MoveTop", false);
                _animator.SetBool("MoveDown", false);
            }
            else if (moveInput.y > 0)
            {
                gameObject.BroadcastMessage("Top", true);
                _animator.SetBool("AttackTop", true);
                _animator.SetBool("AttackRight", false);

                _animator.SetBool("MoveRight", false);
                _animator.SetBool("MoveTop", true);
                _animator.SetBool("MoveDown", false);
            }
            else if (moveInput.y < 0)
            {
                gameObject.BroadcastMessage("Top", false);
                _animator.SetBool("AttackTop", false);
                _animator.SetBool("AttackRight", false);

                _animator.SetBool("MoveRight", false);
                _animator.SetBool("MoveTop", false);
                _animator.SetBool("MoveDown", true);
            }
            IsMoving = true;
        }
        else
        {
            // No movement so interpolate velocity towards 0
            rb.velocity = Vector2.Lerp(rb.velocity, Vector2.zero, idleFriction);

            IsMoving = false;
            _animator.SetBool("MoveRight", false);
            _animator.SetBool("MoveTop", false);
            _animator.SetBool("MoveDown", false);
        }
    }

    void OnAttack()
    {
        if(!_cooldownEnabled)
        {
            _animator.SetTrigger("Attack");
            _cooldownEnabled = true;
            StartCoroutine(Cooldown(_cooldownTime));
        }
    }

    private IEnumerator Cooldown(int time)
    {
        yield return new WaitForSeconds(time);
        _cooldownEnabled = false;
    }

    // Get input values for player movement
    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }
}
