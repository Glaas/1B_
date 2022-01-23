using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            CheckpointManager.instance.SetNewCheckpoint(transform.position);
            EnableFire();
        }
    }

    private void OnEnable()
    {
        CheckpointManager.OnCheckpointReachedEvent += DisableFire;

    }
    private void OnDisable()
    {
        CheckpointManager.OnCheckpointReachedEvent -= DisableFire;
    }
    public void EnableFire()
    {

        GetComponentInChildren<Animator>().SetBool("Enabled", true);
        print("fire from " + gameObject.name);

    }
    public void DisableFire()
    {
        GetComponentInChildren<Animator>().SetBool("Enabled", false);
        print("fire off from " + gameObject.name);
    }
}
