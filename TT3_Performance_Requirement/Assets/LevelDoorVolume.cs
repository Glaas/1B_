using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDoorVolume : MonoBehaviour
{
    //Editor code//
    [HideInInspector]
    public string scenePath;
    //Editor code//
    public string levelToLoad;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(SceneLoader.instance.SceneTransition(levelToLoad));
        }

    }
}
