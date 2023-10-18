using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Player Movement with WASD
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.up * 0.2f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.down * 0.2f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * 0.2f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * 0.2f;
        }
    }
    //Player Dash with Spacebar any direction
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.position += Vector3.up * 2f;
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.position += Vector3.down * 2f;
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.position += Vector3.left * 2f;
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.position += Vector3.right * 2f;
            }
        }
    }   
}
