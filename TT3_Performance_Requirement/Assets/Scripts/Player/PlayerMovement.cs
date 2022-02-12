using System.Security.Cryptography;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private KeyCode jumpKey;
    [SerializeField]
    private KeyCode sprintKey;

    //public so can be affected by external factors
    public CharacterController2D controller;
    public float runSpeed = 40f;
    public float sprintModifier = 2f;
    public bool canMove = true;
    public bool isPlayerFacingRight;
    //These two values are fields so the input can be gathered in Update and applied in FixedUpdate
    private float _horizontalMovDir = 0f;
    private bool jump = false;

    void Update()
    {
        //Prevents imput, can be set from other classes
        if (!canMove)
        {
            _horizontalMovDir = 0f;
            return;
        }

        SprintCheck(out _horizontalMovDir);

        animator.SetFloat("Speed", Mathf.Abs(_horizontalMovDir));
        if (Input.GetKeyDown(jumpKey)) jump = true;
        FlipSprite(_horizontalMovDir);
    }
    //When gathering input, check if the player is sprinting
    void SprintCheck(out float movDir)
    {
        //If the player is sprinting, multiply the movement speed by the sprint modifier
        if (Input.GetKey(sprintKey))
        {
            movDir = Input.GetAxisRaw("Horizontal") * runSpeed * sprintModifier;
            animator.speed = 2.5f;
        }
        else
        {
            movDir = Input.GetAxisRaw("Horizontal") * runSpeed;
            animator.speed = 1.15f;
        }
    }

    void FixedUpdate()
    {
        // Move our character in FixedUpdate to avoid physics issues
        controller.Move(_horizontalMovDir * Time.fixedDeltaTime, jump);
        jump = false;
    }
    //Being passed the movement direction, this method will flip the sprite to face the direction of movement
    private void FlipSprite(float horizontalMovDir)
    {
        if (horizontalMovDir != 0)
        {
            GetComponent<SpriteRenderer>().flipX = horizontalMovDir < 0 ? true : false;
            isPlayerFacingRight = horizontalMovDir < 0 ? false : true;
        }
    }
}
