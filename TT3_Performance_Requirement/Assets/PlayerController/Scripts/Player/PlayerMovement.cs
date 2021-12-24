using System.Security.Cryptography;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    public KeyCode jumpKey;

    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        if (Input.GetKeyDown(jumpKey)) jump = true;
        FlipSprite(horizontalMove);
    }
    private void FlipSprite(float movDir) { if (movDir != 0) GetComponent<SpriteRenderer>().flipX = movDir < 0 ? true : false; }
    void FixedUpdate()
    {
        // Move our character in FixedUpdate to avoid physics issues
        controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
        jump = false;
    }
}
