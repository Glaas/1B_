using System.Collections;
using UnityEngine;


public class PowerUp_Base : MonoBehaviour
{
    [SerializeField]
    KeyCode powerKey = KeyCode.E;
    [SerializeField]
    private AudioClip powerUpUsedSFX;

    public bool isActive = false;
    [SerializeField]
    float cooldownDelay;

    //Checks if the power key is pressed and if the power is not on cooldown
    void Update()
    {
        if ((Input.GetKeyDown(powerKey) || Input.GetButtonDown("Fire2")) && isActive)
        {
            UsePowerUp();
            isActive = false;
            StartCoroutine(PowerUpCooldown());
        }
    }

    //Base method for power ups, overriden in child classes to define different behavior
    public virtual void UsePowerUp() { }
    public virtual void PlayPowerUpSFX() { PlayerSFX.instance.PlaySFX(powerUpUsedSFX); }

    //Simple coroutine to delay powerup usage
    IEnumerator PowerUpCooldown()
    {
        yield return new WaitForSeconds(cooldownDelay);
        isActive = true;
    }

}
