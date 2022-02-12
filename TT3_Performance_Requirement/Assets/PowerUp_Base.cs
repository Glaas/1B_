using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PowerUp_Base : MonoBehaviour
{
    [SerializeField]
    KeyCode powerKey = KeyCode.E;

    public bool isActive = false;
    public float cooldownDelay;

    void Update()
    {
        if (Input.GetKeyDown(powerKey) && isActive)
        {
            UsePowerUp();
            isActive = false;
            StartCoroutine(PowerUpCooldown());
        }
    }

    public virtual void UsePowerUp()
    {
        Debug.Log(this + " Used");

    }
    
    IEnumerator PowerUpCooldown()
    {
        yield return new WaitForSeconds(cooldownDelay);
        isActive = true;
    }

}
