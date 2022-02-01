using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    //Singleton pattern to ensure only one instance of the player stats exists
    public static PlayerStats instance;

    //These three fields needs to be public because they will be read and written from other classes
    public int coinsHeld;
    public bool hasFireballs;
    public bool hasGroundStomp;

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
    private void Start()
    {
        //Make sure player starts at zero
        coinsHeld = 0;
        hasFireballs = false;
        hasGroundStomp = false;
    }
    public void TakeDamage(bool killInOneHit = false)
    {
        //If the player has one upgrade, disable it, unless the damage kills in one hit, like spikes
        if (!killInOneHit)
        {
            if (hasFireballs || hasGroundStomp)
            {
                hasFireballs = false;
                hasGroundStomp = false;
                return;
            }
        }
        StartCoroutine(DeathSequence());
    }
    IEnumerator DeathSequence()
    {
        PlayerSFX.instance.PlaySFX(PlayerSFX.instance.playerDeath);

        FindObjectOfType<PlayerMovement>().canMove = false;
        Rigidbody2D playerRigidbody = FindObjectOfType<PlayerMovement>().GetComponent<Rigidbody2D>();

        playerRigidbody.velocity = Vector2.zero;
        playerRigidbody.isKinematic = true;
        yield return new WaitForSeconds(.1f);
        playerRigidbody.GetComponent<Animator>().SetTrigger("Death");
        yield return new WaitForSeconds(1f);
        yield return StartCoroutine(CheckpointManager.instance.TakePlayerToLastCheckpoint(1.2f));
        yield return new WaitForSeconds(1f);

        playerRigidbody.isKinematic = false;
        FindObjectOfType<PlayerMovement>().canMove = true;
        playerRigidbody.GetComponent<Animator>().SetTrigger("Raise");
        PlayerSFX.instance.PlaySFX(PlayerSFX.instance.playerRaise);


    }

    public void AddCoins(int amount)
    {
        coinsHeld += amount;
        UIManager.instance.UpdateCoinsText();
    }

}
