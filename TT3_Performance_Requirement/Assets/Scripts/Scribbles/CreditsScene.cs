using UnityEngine;
using TMPro;
public class CreditsScene : MonoBehaviour
{
    [SerializeField]
    private float timeBeforeSceneChange = 15;
    private bool hasTransitionStarted = false;
    [SerializeField]
    TextMeshProUGUI timerText;

    private void Update()
    {
        Timer();
    }
    void Timer()
    {
        timeBeforeSceneChange -= Time.deltaTime;
        timerText.text = "You will be redirected to the main menu in " + Mathf.Round(timeBeforeSceneChange).ToString();
        if (timeBeforeSceneChange <= 0 && !hasTransitionStarted)
        {
            //This bool ensures the coroutine only runs once
            hasTransitionStarted = true;
            StartCoroutine(SceneLoader.instance.SceneTransition("MainMenu"));
        }
    }
}
