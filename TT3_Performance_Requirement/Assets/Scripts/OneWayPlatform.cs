using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWayPlatform : MonoBehaviour
{
    public bool isPlayerOnPlatform = false;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            isPlayerOnPlatform = true;
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            isPlayerOnPlatform = false;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            isPlayerOnPlatform = false;
            GetComponent<Collider2D>().isTrigger = false;
        }
    }
    private void Update()
    {
        if (isPlayerOnPlatform && Input.GetAxisRaw("Vertical") < 0)
        {
            GetComponent<Collider2D>().isTrigger = true;
        }
    }
}
