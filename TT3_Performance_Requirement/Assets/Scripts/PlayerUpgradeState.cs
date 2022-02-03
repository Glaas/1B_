using UnityEngine;

public class PlayerUpgradeState : MonoBehaviour
{
    //Singleton pattern to ensure only one instance of the player stats exists
    public static PlayerUpgradeState instance;
    private PlayerStats playerStats;

    private Vector3 originalScale = new Vector3(1, 1, 1);
    private Vector3 grownScale = new Vector3(1.25f, 1.5f, 1);


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
        playerStats = GetComponent<PlayerStats>();
    }

    public void UpgradeFireball()
    {
        if (playerStats.hasFireballs) return;
        playerStats.hasFireballs = true;
        GrowPlayer();
    }
    public void UpgradeGroundStomp()
    {
        if (playerStats.hasGroundStomp) return;
        playerStats.hasGroundStomp = true;
        GrowPlayer();
    }
    public void GrowPlayer()
    {
        playerStats.hasGrown = true;
        FindObjectOfType<PlayerMovement>().transform.localScale = grownScale;
    }
    public void ShrinkPlayer()
    {
        playerStats.hasGrown = false;
        FindObjectOfType<PlayerMovement>().transform.localScale = originalScale;
    }



}