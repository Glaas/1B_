// **************************************************************************************************************************************************************
// This controller is loosely based on the Metroidvania controller here https://assetstore.unity.com/packages/2d/characters/metroidvania-controller-166731
// I tend to use this controller as a base for my 2D controllers. Except for the horizontal movement, and the ground detection which I adepted to my needs, everything
// else was stripped away from the original controller.
// Main concepts I kept :
// - the limit player speed
// - the ground check through OverlapCircleAll
// Original code is multiple hundered lines long, my version starts at ~50 lines long
//
// - <Sebastien>
// **************************************************************************************************************************************************************

using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    [SerializeField] private float m_JumpForce = 400f; // Amount of force added when the player jumps.
    [SerializeField] private bool m_AirControl = false; // Whether or not a player can steer while jumping;
    [SerializeField] private LayerMask groundLayers; // A mask determining what is ground to the character
    [SerializeField] private Transform groundCheck; // A position marking where to check if the player is grounded.

    public bool isGrounded;            // Whether or not the player is grounded.
    public bool canMove = true; //If player can move

    public ParticleSystem trailPS; //Trail particles
    public ParticleSystem dustMotesPS; //Jump impact particles
    private Animator animator;
    private Rigidbody2D rb2D;
    private Vector3 velocity = Vector3.zero;
    const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
    private float limitFallSpeed = 25f; // Limit fall speed

    private void FixedUpdate()
    {
        isGrounded = false;

        // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, k_GroundedRadius, groundLayers);
        for (int i = 0; i < colliders.Length; i++) if (colliders[i].gameObject != gameObject) isGrounded = true;
    }

    public void Move(float move, bool jump)
    {
        if (canMove)
        {
            //only control the player if grounded or airControl is turned on
            if (isGrounded || m_AirControl)
            {
                if (rb2D.velocity.y < -limitFallSpeed)
                    rb2D.velocity = new Vector2(rb2D.velocity.x, -limitFallSpeed);
                // Move the character by finding the target velocity
                rb2D.velocity = new Vector2(move * 10f, rb2D.velocity.y);
            }
            // If the player should jump...
            if (isGrounded && jump)
            {
                // Add a vertical force to the player.
                rb2D.AddForce(new Vector2(0f, m_JumpForce));
                isGrounded = false;
                animator.SetBool("IsJumping", true);
                animator.SetBool("JumpUp", true);
                dustMotesPS.Play();
                trailPS.Play();
                PlayerSFX.instance.PlaySFX(PlayerSFX.instance.playerJump);
            }
            else
            {
                animator.SetBool("IsJumping", false);
                animator.SetBool("JumpUp", false);
            }
        }
    }
    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
}
