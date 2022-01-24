using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            //When player touches the checkoint, set as latest checkpoint and activate fire
            CheckpointManager.instance.SetNewCheckpoint(transform.position);
            EnableFire();
        }
    }
    //Enable or disable the animation of the fire
    public void EnableFire() => GetComponentInChildren<Animator>().SetBool("Enabled", true);
    public void DisableFire() => GetComponentInChildren<Animator>().SetBool("Enabled", false);
    //Subscribes and unsubscribes to the event
    private void OnEnable() => CheckpointManager.OnCheckpointReachedEvent += DisableFire;
    private void OnDisable() => CheckpointManager.OnCheckpointReachedEvent -= DisableFire;
}
