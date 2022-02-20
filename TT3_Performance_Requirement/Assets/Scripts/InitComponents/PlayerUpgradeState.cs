using UnityEngine;
//Class mostly using data, could be rewritten using scriptable objects like in the Unity talk from 2017
public class PlayerUpgradeState : MonoBehaviour
{
    //Singleton pattern to ensure only one instance of the player stats exists
    public static PlayerUpgradeState instance;
    private PlayerStats playerStats;

    private PowerUp_Fireballs fireballClass;
    private PowerUp_GroundStomp groundStompClass;

    public bool hasGrown = false;
    public bool hasFireballs = false;
    public bool hasGroundStomp = false;

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
        fireballClass = GetComponent<PowerUp_Fireballs>();
        groundStompClass = GetComponent<PowerUp_GroundStomp>();

        fireballClass.enabled = false;
        groundStompClass.enabled = false;

        hasGrown = false;
        hasFireballs = false;
        hasGroundStomp = false;
    }


    //Ensures only one upgrade is active at a time
    public void UpgradeFireball()
    {
        if (hasFireballs) return;
        fireballClass.enabled = true;
        hasFireballs = true;

        groundStompClass.enabled = false;
        hasGroundStomp = false;
        GrowPlayer();
    }
    public void UpgradeGroundStomp()
    {
        if (hasGroundStomp) return;
        hasGroundStomp = true;
        groundStompClass.enabled = true;

        hasFireballs = false;
        fireballClass.enabled = false;
        GrowPlayer();
    }
    //Updates UI and tweaks player scale to make it grow and shrink
    public void GrowPlayer()
    {
        hasGrown = true;
        UIManager.instance.UpdateUpgradeSprite(hasFireballs == true ? "fireballs" : "groundstomp", true);
        FindObjectOfType<PlayerMovement>().transform.localScale = grownScale;
    }
    public void ShrinkPlayer()
    {
        hasGrown = false;
        FindObjectOfType<PlayerMovement>().transform.localScale = originalScale;

        if (groundStompClass.enabled) groundStompClass.enabled = false;
        if (fireballClass.enabled) fireballClass.enabled = false;
    }



}