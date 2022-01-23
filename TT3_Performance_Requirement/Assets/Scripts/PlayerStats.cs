using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats instance;

    public int _coins;
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
        _coins = 0;
        hasFireballs = false;
        hasGroundStomp = false;
    }
    public void TakeDamage(bool killInOneHit = false)
    {
        Debug.Log("Player took damage");
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
        FindObjectOfType<PlayerMovement>().canMove = false;
        Rigidbody2D playerRigidbody = FindObjectOfType<PlayerMovement>().GetComponent<Rigidbody2D>();

        playerRigidbody.velocity = Vector2.zero;
        playerRigidbody.isKinematic = true;
        yield return new WaitForSeconds(.1f);
        playerRigidbody.GetComponent<Animator>().SetTrigger("Death");
        yield return new WaitForSeconds(1f);
        yield return StartCoroutine(CheckpointManager.instance.TakePlayerToLastCheckpoint(2));
        yield return new WaitForSeconds(1f);

        playerRigidbody.isKinematic = false;
        FindObjectOfType<PlayerMovement>().canMove = true;
        playerRigidbody.GetComponent<Animator>().SetTrigger("Raise");


    }

    public void AddCoins(int amount)
    {
        _coins += amount;
        UIManager.instance.UpdateCoinsText();
    }

}
