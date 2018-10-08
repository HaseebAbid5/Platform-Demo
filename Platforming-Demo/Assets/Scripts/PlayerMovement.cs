﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    float moveDir;
    public float speed;
    float jumpForce;
    public int jump;
    public float range;
    public GameObject rayOrigin;
    float lastScale;
    RaycastHit2D hit;
    float ogSpeed;

    // Use this for initialization
    void Start()
    {
        lastScale = 1;
        ogSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        
        hit = Physics2D.Raycast(rayOrigin.transform.position,
                                new Vector2(0, -1), range);

        if (hit.collider == null)
        {
            GetComponent<Animator>().SetBool("Jump", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("Jump", false);
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (hit.collider != null)
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jump));
            }
        }

        moveDir = Input.GetAxisRaw("Horizontal");

        if (moveDir != 0)
            lastScale = moveDir;

        this.transform.localScale = new Vector2(lastScale, 1);

        if (Input.GetButtonDown("Fire3"))
            speed = speed * 1.3f;

        if(Input.GetButtonUp("Fire3"))
            speed = ogSpeed;

        Debug.Log(speed);

        transform.position = new Vector2(transform.position.x + speed * Time.deltaTime * moveDir,
                                         transform.position.y);
        GetComponent<Animator>().SetInteger("X", (int)moveDir);

    }
}
