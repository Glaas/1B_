using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    private void Start()
    {
        //Self destruct after 2 seconds
        Destroy(gameObject, 2f);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            if (other.gameObject.GetComponent<BlobState>())
            {
                other.gameObject.GetComponent<BlobState>().BlobDeath();
            }
        }
    }
}