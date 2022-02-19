using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    //Singleton pattern to ensure only one instance of the player stats exists
    public static PlayerStats instance;

    private PlayerUpgradeState playerUpgradeState;

    //These fields needs to be public because they will be read and written from other classes
    public int coinsHeld;
    public bool canTakeDamage = true;

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
        playerUpgradeState = GetComponent<PlayerUpgradeState>();
    }
    private void Start()
    {
        //Make sure player starts at zero
        coinsHeld = 0;
        canTakeDamage = true;
    }
    public void TakeDamage(bool killInOneHit = false)
    {
        if (!canTakeDamage) return;
        //If the player has one upgrade, disable it, unless the damage kills in one hit, like spikes
        if (!killInOneHit)
        {
            if (playerUpgradeState.hasFireballs || playerUpgradeState.hasGroundStomp)
            {
                playerUpgradeState.hasFireballs = false;
                playerUpgradeState.hasGroundStomp = false;
                playerUpgradeState.ShrinkPlayer();
                canTakeDamage = false;
                PlayerSFX.instance.PlaySFX(PlayerSFX.instance.playerHurt);
                StartCoroutine(InvincibilitySequence());
                UIManager.instance.UpdateUpgradeSprite(string.Empty, false);
                return;
            }
        }
        StartCoroutine(DeathSequence());
    }
    //Rend player invincibility for a short time and adds visual feedback by turning sprite red
    public IEnumerator InvincibilitySequence()
    {
        PlayerMovement playerMovement = FindObjectOfType<PlayerMovement>();

        playerMovement.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(.5f);
        canTakeDamage = true;
        playerMovement.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }
    //Make the player unable to move, while playing a death animation and transporting it to the spawn point, with audio feedback
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
