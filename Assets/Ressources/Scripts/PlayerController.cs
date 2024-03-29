﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private SpriteRenderer mySpriteRenderer;
    private Rigidbody2D body;

    Vector2 direction;

    [SerializeField]
    private float speed = 4;

    [SerializeField]
    private float speedJump = 50;

    bool canJump = true;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        body.velocity = new Vector3(direction.x * speed, direction.y);

        if (direction.x <= -1)
        {
            mySpriteRenderer.flipX = true;
            //Debug.Log("Tourne");
        }
        else if (direction.x >= 1)
        {
            mySpriteRenderer.flipX = false;
            //Debug.Log("Retourne");
        }
    }

    // Update is called once per frame
    void Update()
    {
        direction = new Vector2(Input.GetAxisRaw("Horizontal") * speed, body.velocity.y);

        if (Input.GetButtonDown("Jump") && canJump)
        {
            //Debug.Log("ici");
            body.AddForce(Vector2.up * speedJump);
            canJump = false;
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        canJump = true;
    }
}
