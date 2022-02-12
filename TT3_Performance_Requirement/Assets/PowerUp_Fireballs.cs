using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp_Fireballs : PowerUp_Base
{
    [SerializeField]
    private GameObject fireballPrefab;
    private PlayerMovement player;

    private void Awake()
    {
        player = FindObjectOfType<PlayerMovement>();
    }
    public override void UsePowerUp()
    {
        base.UsePowerUp();
        Debug.Log(this + " Used");
        Vector2 fireballDir = player.isPlayerFacingRight ? Vector2.right : Vector2.left;
        GameObject projectile = Instantiate(fireballPrefab, (Vector2)player.transform.position + (fireballDir/3) + (Vector2.up * .5f), Quaternion.identity);
        projectile.GetComponent<Rigidbody2D>().AddForce(fireballDir * 10f, ForceMode2D.Impulse);
    }
}
