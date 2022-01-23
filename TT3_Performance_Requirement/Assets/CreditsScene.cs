using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsScene : MonoBehaviour
{
    public float timeBeforeSceneChange = 5;
    void Start()
    {
        //play credits music
    }
    private void Update()
    {
        Timer();
    }
    void Timer()
    {
        timeBeforeSceneChange -= Time.deltaTime;
        if (timeBeforeSceneChange <= 0)
        {
            StartCoroutine(SceneLoader.instance.SceneTransition("MainMenu"));
        }
    }
}
