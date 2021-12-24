using UnityEngine;
using UnityEngine.Events;


public class CharacterController2D : MonoBehaviour
{
    [SerializeField] private float m_JumpForce = 400f; // Amount of force added when the player jumps.
    [SerializeField] private bool m_AirControl = false; // Whether or not a player can steer while jumping;
    [SerializeField] private LayerMask groundLayers; // A mask determining what is ground to the character
    [SerializeField] private Transform groundCheck; // A position marking where to check if the player is grounded.

    public bool m_Grounded;            // Whether or not the player is grounded.
    public bool m_FacingRight = true;  // For determining which way the player is currently facing.

    public bool canMove = true; //If player can move
    private float prevVelocityX = 0f;

    public ParticleSystem trailPS; //Trail particles
    public ParticleSystem dustMotesPS; //Jump impact particles
    private Animator animator;
    private Rigidbody2D m_Rigidbody2D;
    private Vector3 velocity = Vector3.zero;
    const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
    private float limitFallSpeed = 25f; // Limit fall speed

    private void FixedUpdate()
    {
        bool wasGrounded = m_Grounded;
        m_Grounded = false;

        // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
        // This can be done using layers instead but Sample Assets will not overwrite your project settings.
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, k_GroundedRadius, groundLayers);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
                m_Grounded = true;
        }
        if (!m_Grounded)
        {
            prevVelocityX = m_Rigidbody2D.velocity.x;
        }
    }

    public void Move(float move, bool jump)
    {
        if (canMove)
        {
            //only control the player if grounded or airControl is turned on
            if (m_Grounded || m_AirControl)
            {
                if (m_Rigidbody2D.velocity.y < -limitFallSpeed)
                    m_Rigidbody2D.velocity = new Vector2(m_Rigidbody2D.velocity.x, -limitFallSpeed);
                // Move the character by finding the target velocity
                m_Rigidbody2D.velocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y);
            }
            // If the player should jump...
            if (m_Grounded && jump)
            {
                // Add a vertical force to the player.
                animator.SetBool("IsJumping", true);
                animator.SetBool("JumpUp", true);
                m_Grounded = false;
                m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
                dustMotesPS.Play();
                trailPS.Play();
            }
            else
            {
                animator.SetBool("IsJumping", false);
                animator.SetBool("JumpUp", false);
            }
        }
        FlipSprite();
    }
    private void FlipSprite()
    {

        //flip sprite renderer x based on delta position x
        if (m_Rigidbody2D.velocity.x > 0 && !m_FacingRight || m_Rigidbody2D.velocity.x < 0 && m_FacingRight)
        {
            m_FacingRight = !m_FacingRight;
            GetComponent<SpriteRenderer>().flipX = !GetComponent<SpriteRenderer>().flipX;
        }

    }
    private void Awake()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
}
