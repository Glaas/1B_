using System.Reflection.Emit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobState : MonoBehaviour
{
    [Range(0, 10)]
    public float movementSpeed = 1f;
    // Start is called before the first frame update

    public bool isAlive = true;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //move left every frame
        if (isAlive)
        {
            transform.position += Vector3.left * movementSpeed * Time.deltaTime;
        }

    }

    public void BlobDeath()
    {
        Destroy(gameObject,5f);
        GetComponent<AudioSource>().Play();
        BlobDeathAnimation();
    }
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
