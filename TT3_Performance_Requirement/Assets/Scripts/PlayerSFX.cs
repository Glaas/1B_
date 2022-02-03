using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSFX : MonoBehaviour
{
    public AudioClip playerDeath;
    public AudioClip playerRaise;
    public AudioClip playerJump;
    public AudioClip playerHurt;
    public AudioClip playerPickupUpgrade;

    public static PlayerSFX instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySFX(AudioClip clip) => GetComponent<AudioSource>().PlayOneShot(clip);

}
