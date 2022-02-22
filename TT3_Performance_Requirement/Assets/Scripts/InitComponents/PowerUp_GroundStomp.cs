using System.Collections;
using UnityEngine;

public class PowerUp_GroundStomp : PowerUp_Base
{
    public LayerMask layersAffectedByGroundStomp;
    public override void UsePowerUp()
    {
        //Do not use if the player is not in the air
        if (FindObjectOfType<CharacterController2D>().isGrounded) return;

        PlayPowerUpSFX();

        StartCoroutine(StompSequence());

    }
    IEnumerator StompSequence()
    {
        var player = FindObjectOfType<CharacterController2D>();

        //Disable player movement
        player.enabled = false;
        player.canMove = false;
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        player.GetComponent<Rigidbody2D>().isKinematic = true;

        //Determine point of impact and add half the size of the player so it lands on its feet
        var playerColliderHeight = player.GetComponent<CapsuleCollider2D>().size.y;
        Vector3 startPos = player.transform.position;
        Vector3 impactPoint = Physics2D.Raycast(player.transform.position, Vector2.down, float.MaxValue, layersAffectedByGroundStomp).point + Vector2.up * playerColliderHeight;

        float distance = Vector3.Distance(startPos, impactPoint);
        //Do a pause in mid-air to add a bit of oompf.
        yield return new WaitForSeconds(.85f);

        //Use the distance obtained above to determine the speed of the player's fall
        float duration = distance / 50;
        float t = 0;
        while (t < duration)
        {
            t += Time.deltaTime;
            player.transform.position = Vector3.Lerp(startPos, impactPoint, t / duration);
            yield return null;
        }
        //I love me some screenshake. Visual and audio feedback.
        ScreenshakeManager.instance.ScreenShake(.6f);
        PlayerSFX.instance.PlaySFX(PlayerSFX.instance.groundStomp);

        //Apply damage to all elements succeptible to ground stomp (could be written more elegantly)
        foreach (Collider2D c in Physics2D.OverlapCircleAll(player.transform.position, 1.5f))
        {
            if (c.GetComponent<Destructible>())
            {
                c.GetComponent<Destructible>().TakeDamage();
            }
            if (c.GetComponent<BlobState>())
            {
                c.GetComponent<BlobState>().BlobDeath();
            }
            if (c.GetComponent<IcyState>())
            {
                c.GetComponent<IcyState>().IcyDeath();
            }
        }

        //Small delay for game feel, adds weight to the impact
        yield return new WaitForSeconds(.1f);

        //Re-enable player movement
        player.enabled = true;
        player.canMove = true;
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        player.GetComponent<Rigidbody2D>().isKinematic = false;
    }

}
