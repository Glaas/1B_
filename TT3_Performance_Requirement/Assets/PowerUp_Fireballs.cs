using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp_Fireballs : PowerUp_Base
{
    public override void UsePowerUp()
    {
        base.UsePowerUp();
        Debug.Log(this + " Used");

        GameObject.Find("Projectile_Fireball").GetComponent<Rigidbody2D>().AddForce(Vector2.right * 8, ForceMode2D.Impulse);
    }
}
