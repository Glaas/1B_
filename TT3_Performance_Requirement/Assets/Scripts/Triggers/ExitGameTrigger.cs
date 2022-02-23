using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ExitGameTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Fades out the volume of the whole program, then exits after a fade to black
            StartCoroutine(FadeSound());
            StartCoroutine(QuitGame());
        }
    }
    IEnumerator QuitGame()
    {
        //Fades out the volume of the whole program, then exits after a fade to black
        yield return StartCoroutine(UIManager.instance.Fade("out", 1f));
        yield return new WaitForSeconds(1f);
        Application.Quit();
        print("Quit");

    }
    //Just a normal lerp to fade out the volume of the whole program
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

    private void Start()
    {
        if (PlayerUpgradeState.instance.hasGrown) PlayerUpgradeState.instance.ShrinkPlayer();
    }
}
