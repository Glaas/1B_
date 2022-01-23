using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hurtzone : MonoBehaviour
{
    public bool killPlayerInOneHit = false;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerStats.instance.TakeDamage(killPlayerInOneHit);
        }
    }
}