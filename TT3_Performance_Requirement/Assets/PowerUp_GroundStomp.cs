using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp_GroundStomp : PowerUp_Base
{
    public override void UsePowerUp()
    {
        base.UsePowerUp();
        Debug.Log(this + " Used");
        if (FindObjectOfType<CharacterController2D>().isGrounded) return;
    }
}
