using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D body;

    Vector2 direction;

    [SerializeField]
    private float speed = 4;

    [SerializeField] bool isTop = false;

    bool canJump = true;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();

        if (body != null)
        {
           // Debug.Log("Body founded!");
        }
        else
        {
            //Debug.Log("No body");
        }
    }

    void FixedUpdate()
    {
        body.velocity = new Vector3(direction.x * speed, body.velocity.y);
    }

    // Update is called once per frame
    void Update()
    {

        if (isTop)
        {
            direction = new Vector2(Input.GetAxisRaw("Horizontal") * speed, body.velocity.y);

            if (Input.GetAxisRaw("Jump") > 0.1f && canJump)
            {
                Debug.Log("ici");
                direction.y += 10;

                canJump = true;
            }

        }
        else
        {
            direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * speed;
        }

        if (direction.x <= -1)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (direction.x >= 1)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        canJump = true;
    }
}

