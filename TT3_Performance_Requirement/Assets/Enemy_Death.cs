using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Death : MonoBehaviour
{
    public float force = 10f;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Rigidbody2D playerrb2d = other.GetComponent<Rigidbody2D>();

            float currVelocity = playerrb2d.velocity.y;

            playerrb2d.velocity = new Vector2(playerrb2d.velocity.x, 0);

            FindObjectOfType<PlayerMovement>().GetComponent<Rigidbody2D>().AddForce(new Vector2(0, Mathf.Abs(currVelocity) * .65f), ForceMode2D.Impulse);
            GetComponent<AudioSource>().Play();

            GetComponentInParent<BlobState>().BlobDeath();
        }
    }

}
