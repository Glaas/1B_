using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            print("Collided with player" + other.gameObject.name);
            CheckpointManager.instance._spawnPoint = transform.position;
            GetComponentInChildren<Animator>().SetTrigger("Enable");
        }
    }
}
