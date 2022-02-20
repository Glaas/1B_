using UnityEngine;

public class CreditsScene : MonoBehaviour
{
    [SerializeField]
    private float timeBeforeSceneChange = 5;
    private bool hasTransitionStarted = false;

    private void Update()
    {
        Timer();
    }
    void Timer()
    {
        timeBeforeSceneChange -= Time.deltaTime;
        if (timeBeforeSceneChange <= 0 && !hasTransitionStarted)
        {
            //This bool ensures the coroutine only runs once
            hasTransitionStarted = true;
            StartCoroutine(SceneLoader.instance.SceneTransition("MainMenu"));
        }
    }
}
