using System.Security.Cryptography;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    public KeyCode jumpKey;

    //public so can be affected by external factors
    public float runSpeed = 40f;

    //These two values are fields so the input can be gathered in Update and applied in FixedUpdate
    private float _horizontalMovDir = 0f;
    private bool jump = false;

    void Update()
    {
        _horizontalMovDir = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(_horizontalMovDir));
        if (Input.GetKeyDown(jumpKey)) jump = true;
        FlipSprite(_horizontalMovDir);
    }

    void FixedUpdate()
    {
        // Move our character in FixedUpdate to avoid physics issues
        controller.Move(_horizontalMovDir * Time.fixedDeltaTime, jump);
        jump = false;
    }
    //Being passed the movement direction, this method will flip the sprite to face the direction of movement
    private void FlipSprite(float horizontalMovDir) { if (horizontalMovDir != 0) GetComponent<SpriteRenderer>().flipX = horizontalMovDir < 0 ? true : false; }
}
