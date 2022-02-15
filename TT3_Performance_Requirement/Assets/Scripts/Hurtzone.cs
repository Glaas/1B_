using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hurtzone : MonoBehaviour
{
    [SerializeField]
    bool killPlayerInOneHit = false;

    CharacterController2D player;
    Rigidbody2D playerRB;

    private void Start()
    {
        playerRB = FindObjectOfType<PlayerMovement>().GetComponent<Rigidbody2D>();
        player = FindObjectOfType<CharacterController2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (GetComponent<UnityEngine.Tilemaps.Tilemap>())
            {
                playerRB.velocity = Vector2.zero;
                PlayerStats.instance.TakeDamage(killPlayerInOneHit);

            }
            else
            {
                if (player.isGrounded || GetComponent<IcyState>())
                {
                    playerRB.velocity = Vector2.zero;

                    PlayerStats.instance.TakeDamage(killPlayerInOneHit);
                    StartCoroutine(PlayerKnockback(other.gameObject.transform.position, other.gameObject));
                }
                else if (!player.isGrounded)
                {
                    EnemyDeath();
                }
            }
        }
    }
    public void EnemyDeath()
    {
        playerRB.AddForce(new Vector2(0, 15), ForceMode2D.Impulse);
        GetComponent<AudioSource>().Play();
        if (GetComponentInParent<BlobState>()) GetComponentInParent<BlobState>().BlobDeath();
        else if (GetComponent<IcyState>()) GetComponent<IcyState>().IcyDeath();
    }
    IEnumerator PlayerKnockback(Vector3 currPos, GameObject playerGO)
    {
        float elapsedTime = 0;
        float waitTime = .5f;
        currPos = transform.position;
        float x = playerGO.transform.position.x < transform.position.x ? -5 : 5;
        Vector3 destination = new Vector3(currPos.x + x, currPos.y + 1.5f, currPos.z);

        while (elapsedTime < waitTime)
        {
            playerGO.transform.position = Vector3.Lerp(currPos, destination, (elapsedTime / waitTime));
            elapsedTime += Time.deltaTime;

            yield return null;
        }
        playerGO.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }

}
