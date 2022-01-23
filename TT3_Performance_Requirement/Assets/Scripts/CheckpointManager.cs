using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckpointManager : MonoBehaviour
{
    public static CheckpointManager instance;
    public Vector2 _spawnPoint;
    public AnimationCurve _spawnCurve;
    public delegate void OnCheckpointReached();
    public static event OnCheckpointReached OnCheckpointReachedEvent;

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
    public IEnumerator TakePlayerToLastCheckpoint(float duration)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Vector2 playerPosition = player.transform.position;
        float time = 0;
        while (time < duration)
        {
            time += Time.deltaTime;
            float T = time / duration;
            player.transform.position = Vector2.Lerp(playerPosition, _spawnPoint, _spawnCurve.Evaluate(T));
            yield return null;
        }
    }
    public void SetNewCheckpoint(Vector2 newCheckpoint)
    {
        _spawnPoint = newCheckpoint;
        OnCheckpointReachedEvent();
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        SetNewCheckpoint(GameObject.FindGameObjectWithTag("Player").transform.position);
    }
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }



}
