using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ExitGameTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(FadeSound());
            StartCoroutine(QuitGame());
        }
    }
    IEnumerator QuitGame()
    {

        yield return StartCoroutine(UIManager.instance.Fade("out", 1f));
        yield return new WaitForSeconds(1f);
        Application.Quit();
        print("Quit");

    }
    IEnumerator FadeSound()
    {
        float elapsedTime = 0;
        float waitTime = 1f;

        while (elapsedTime < waitTime)
        {
            AudioListener.volume = Mathf.Lerp(1f, 0f, elapsedTime / waitTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        yield return null;
    }
}
