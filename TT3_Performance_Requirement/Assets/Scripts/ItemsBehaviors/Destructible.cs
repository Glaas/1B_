using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Destructible : MonoBehaviour
{
    private int currentHealth = 1;
    [SerializeField]
    private AudioClip hurtSound;
    [SerializeField]
    private AudioClip deathSound;


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<Fireball>())
        {
            TakeDamage();
            if (other.collider.gameObject.GetComponent<Fireball>())
            {
                Destroy(other.collider.gameObject);
            }
        }
    }
    //When taking damage, check if it has healthpoints left over, if not, destroy itself
    public virtual void TakeDamage()
    {
        PlayDamageSFX();
        currentHealth--;
        if (currentHealth <= 0)
        {
            Die();
        }

    }
    //Destroy after a delay to ensure that audio has finished playing and particle systems too
    public virtual void Die()
    {
        PlayDeathSFX();
        GetComponentInChildren<SpriteRenderer>().enabled = false;
        GetComponentInChildren<Collider2D>().enabled = false;

        Destroy(gameObject, 5);
    }
    //Audio feedback for taking damage
    public virtual void PlayDamageSFX()
    {
        GetComponent<AudioSource>().PlayOneShot(hurtSound);
    }
    public virtual void PlayDeathSFX()
    {
        GetComponent<AudioSource>().PlayOneShot(deathSound);
    }
}
