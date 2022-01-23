using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int value;
    private float delayBeforeDestroy;

    private AudioSource audioSource;
    private ParticleSystem ps;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        ps = GetComponent<ParticleSystem>();
    }

    private void Start()
    {
        //Determine how long the coin will stay on screen before being destroyed
        delayBeforeDestroy = GetComponent<ParticleSystem>().main.duration;
        if (GetComponent<AudioSource>().clip.length > delayBeforeDestroy)
        {
            delayBeforeDestroy = GetComponent<AudioSource>().clip.length;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //Add the value of the coin to the player's score
            PlayerStats.instance.AddCoins(value);
            //Make coin non-interactable for the duration of effects to play
            GetComponentInChildren<SpriteRenderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
            //Play sound
            GetComponent<AudioSource>().Play();
            //Play particle system
            GetComponent<ParticleSystem>().Play();


            //Destroy the coin after a while
            Destroy(gameObject, delayBeforeDestroy);
        }
    }
}
