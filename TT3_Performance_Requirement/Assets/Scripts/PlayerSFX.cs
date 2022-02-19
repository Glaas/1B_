using UnityEngine;

//Manages all SFX related to the player. Since the player is most often at the center of the screen, it
//doesn't make sense to have an AudioSource on it. This makes it easier to manage the SFX.
public class PlayerSFX : MonoBehaviour
{
    public AudioClip playerDeath;
    public AudioClip playerRaise;
    public AudioClip playerJump;
    public AudioClip playerHurt;
    public AudioClip playerPickupUpgrade;
    public AudioClip groundStomp;
    public AudioClip doorEnter;

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
