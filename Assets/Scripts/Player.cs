using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 150f;
    public float maxSpeed = 8f;

    // Each frame of physics, what percentage of the speed should be shaved off the velocity out of 1 (100%)
    public float idleFriction = 0.9f;
    Rigidbody2D rb;

    SpriteRenderer spriteRenderer;

    public GameObject _colliderArea;
    public Collider2D _areacollider;

    Vector2 moveInput = Vector2.zero;

    bool _isMoving = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        _areacollider = _colliderArea.GetComponent<Collider2D>();
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
            }
            else if (moveInput.x < 0)
            {
                spriteRenderer.flipX = true;
                gameObject.BroadcastMessage("Right", false);
            }
            else if (moveInput.y > 0)
            {
                spriteRenderer.flipY = false;
                gameObject.BroadcastMessage("Top", true);
            }
            else if (moveInput.y < 0)
            {
                spriteRenderer.flipY = true;
                gameObject.BroadcastMessage("Top", false);
            }
            _isMoving = true;
        }
        else
        {
            // No movement so interpolate velocity towards 0
            rb.velocity = Vector2.Lerp(rb.velocity, Vector2.zero, idleFriction);

            _isMoving = false;
        }
    }


    // Get input values for player movement
    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }
}
