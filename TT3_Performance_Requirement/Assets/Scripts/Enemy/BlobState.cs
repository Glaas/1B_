using System.Reflection.Emit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobState : MonoBehaviour
{
    //Can be adjusted from inspector or set by other classes
    [Range(-10, 10)]
    public float movementSpeed = 1f;

    public bool isAlive = true;
    void Update()
    {
        //move left every frame if alive
        if (isAlive) transform.position += Vector3.left * movementSpeed * Time.deltaTime;
    }

    public void BlobDeath()
    {
        Destroy(gameObject, 5f);
        GetComponent<AudioSource>().Play();
        BlobDeathAnimation();
    }
    //Deactive all colliders and uses the Rigidbody2D to create a mario-like death animation
    void BlobDeathAnimation()
    {
        isAlive = false;
        foreach (Collider2D collider in GetComponentsInChildren<Collider2D>())
        {
            collider.enabled = false;
        }
        Rigidbody2D rb2d = GetComponent<Rigidbody2D>();
        rb2d.bodyType = RigidbodyType2D.Dynamic;
        rb2d.simulated = true;
        rb2d.gravityScale = 2.5f;
        rb2d.AddForce(new Vector2(2, 7), ForceMode2D.Impulse);
        rb2d.AddTorque(-5, ForceMode2D.Impulse);
    }
}
