﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    public bool isGrounded = false;

    private void Update()
    {
        //Player X Movement
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * moveSpeed;

        //Jump Check
        if (Input.GetButtonDown("Jump") && isGrounded)
            Jump();
    }

    private void Jump()
    {
        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 12f), ForceMode2D.Impulse);
    }
}