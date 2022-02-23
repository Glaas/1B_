using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDoorVolume : MonoBehaviour
{
    [SerializeField]
    private string levelToLoad;
    private void OnTriggerEnter2D(Collider2D other)
    {
        //On contact, transitions to the next scene
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(SceneLoader.instance.SceneTransition(levelToLoad));
        }
    }
}
