using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp_Fireballs : PowerUp_Base
{
    [SerializeField]
    private GameObject fireballPrefab;


    public override void UsePowerUp()
    {
        base.UsePowerUp();
        PlayerMovement player = FindObjectOfType<PlayerMovement>();
        Debug.Log(this + " Used");
        PlayPowerUpSFX();
        Vector2 fireballDir = player.isPlayerFacingRight ? Vector2.right : Vector2.left;
        GameObject projectile = Instantiate(fireballPrefab, (Vector2)player.transform.position + (fireballDir / 3) + (Vector2.up * .5f), Quaternion.identity);
        projectile.GetComponent<Rigidbody2D>().AddForce(fireballDir * 10f, ForceMode2D.Impulse);
    }
}
