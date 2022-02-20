using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp_Fireballs : PowerUp_Base
{
    [SerializeField]
    private GameObject fireballPrefab;
    //Throw a fireball in the direction the player is facing
    public override void UsePowerUp()
    {
        PlayerMovement player = FindObjectOfType<PlayerMovement>();

        PlayPowerUpSFX();
        //Determine which way the player is facing, then instance a fireball prefab, and apply a force to it
        Vector2 fireballDir = player.isPlayerFacingRight ? Vector2.right : Vector2.left;
        GameObject projectile = Instantiate(fireballPrefab, (Vector2)player.transform.position + (fireballDir / 3) + (Vector2.up * .5f), Quaternion.identity);
        projectile.GetComponent<Rigidbody2D>().AddForce(fireballDir * 10f, ForceMode2D.Impulse);
    }
}
