using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckpointManager : MonoBehaviour
{
    //Singleton pattern because we only want one instance of the checkpoint manager
    public static CheckpointManager instance;

    //Event to make all checkpoints disable their fire and have only one checkpoint lit at a time
    public delegate void OnCheckpointReached();
    public static event OnCheckpointReached OnCheckpointReachedEvent;

    [HideInInspector]
    public Vector2 spawnPoint;
    public AnimationCurve lerpEasingCurve;

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
    //When the player dies, caches his position, and lerps them back to the latest checkpoint, using the easing curve for more elegant animation
    public IEnumerator TakePlayerToLastCheckpoint(float duration)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Vector2 playerPosition = player.transform.position;
        float time = 0;
        while (time < duration)
        {
            time += Time.deltaTime;
            float T = time / duration;
            player.transform.position = Vector2.Lerp(playerPosition, spawnPoint + Vector2.up, lerpEasingCurve.Evaluate(T));
            yield return null;
        }
    }
    //Registers the latest checkpoint and fires the event to make sure to turn off all existing fire animations
    public void SetNewCheckpoint(Vector2 newCheckpoint)
    {
        spawnPoint = newCheckpoint;
        OnCheckpointReachedEvent();
    }
    //This makes sure to set a default spawn point when a new scene is loaded
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        SetNewCheckpoint(GameObject.FindGameObjectWithTag("Player").transform.position);
    }
    void OnEnable() => SceneManager.sceneLoaded += OnSceneLoaded;
    void OnDisable() => SceneManager.sceneLoaded -= OnSceneLoaded;



}
