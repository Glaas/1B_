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
        PlayPowerUpSFX();
        StartCoroutine(StompSequence());

    }
    IEnumerator StompSequence()
    {
        var player = FindObjectOfType<CharacterController2D>();

        player.enabled = false;
        player.canMove = false;
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        player.GetComponent<Rigidbody2D>().isKinematic = true;

        var playerColliderHeight = player.GetComponent<CapsuleCollider2D>().size.y;




        Vector3 startPos = player.transform.position;
        Vector3 impactPoint = Physics2D.Raycast(player.transform.position, Vector2.down, float.MaxValue, 1 << LayerMask.NameToLayer("Ground")).point + Vector2.up * playerColliderHeight;

        float distance = Vector3.Distance(startPos, impactPoint);
        yield return new WaitForSeconds(.5f);

        float duration = distance / 50;
        float t = 0;
        while (t < duration)
        {
            t += Time.deltaTime;
            player.transform.position = Vector3.Lerp(startPos, impactPoint, t / duration);
            yield return null;
        }
        PlayerSFX.instance.PlaySFX(PlayerSFX.instance.playerRaise);

        yield return new WaitForSeconds(.1f);

        player.enabled = true;
        player.canMove = true;
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        player.GetComponent<Rigidbody2D>().isKinematic = false;
    }
}
