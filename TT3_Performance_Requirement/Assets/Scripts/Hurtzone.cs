using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hurtzone : MonoBehaviour
{
    [SerializeField]
    bool killPlayerInOneHit = false;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Player takes damage on contact
            PlayerStats.instance.TakeDamage(killPlayerInOneHit);
        }
    }
}
