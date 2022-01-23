using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public static CheckpointManager instance;
    public Vector2 _spawnPoint;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void TakePlayerToLastCheckpoint()
    {
        FindObjectOfType<PlayerMovement>().gameObject.transform.position = _spawnPoint;
    }
}
