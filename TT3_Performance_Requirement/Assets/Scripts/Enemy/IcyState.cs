using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcyState : MonoBehaviour
{
    public bool isAlive = true;
    public List<Vector3> waypoints;
    public float movementSpeed = 1f;

    private void Start()
    {
        StartCoroutine(GoToNextWaypoint());
    }
    public void IcyDeath()
    {
        Destroy(gameObject, 5f);
        GetComponent<AudioSource>().Play();
        IcyDeathAnimation();
    }
    //Deactive all colliders and uses the Rigidbody2D to create a mario-like death animation
    void IcyDeathAnimation()
    {
        isAlive = false;
        foreach (Collider2D collider in GetComponentsInChildren<Collider2D>())
        {
            collider.enabled = false;
        }
        Rigidbody2D rb2d = GetComponent<Rigidbody2D>();
        rb2d.bodyType = RigidbodyType2D.Dynamic;
        rb2d.simulated = true;
        rb2d.gravityScale = 2.5f;
        rb2d.AddForce(new Vector2(2, 7), ForceMode2D.Impulse);
        rb2d.AddTorque(-5, ForceMode2D.Impulse);
    }

    //Patrols between waypoints by moving to the next waypoint after reaching it. Also using the delta of the waypoint to determine the direction of the movement
    //and flips the sprite accordingly
    IEnumerator GoToNextWaypoint()
    {
        while (true)
        {
            for (int i = 0; i < waypoints.Count; i++)
            {
                while (Vector3.Distance(transform.position, waypoints[i]) > 0.1f)
                {
                    transform.position = Vector3.MoveTowards(transform.position, waypoints[i], Time.deltaTime * movementSpeed);
                    //flip sprite if needed
                    if (waypoints[i].x < transform.position.x)
                    {
                        GetComponentInChildren<SpriteRenderer>().flipX = false;
                    }
                    else if (waypoints[i].x > transform.position.x)
                    {
                        GetComponentInChildren<SpriteRenderer>().flipX = true;
                    }
                    yield return null;
                }

            }
        }
    }
    //Visualize waypoints when selected
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        foreach (Vector3 waypoint in waypoints)
        {
            Gizmos.DrawSphere(waypoint, 0.3f);
        }
    }
}
