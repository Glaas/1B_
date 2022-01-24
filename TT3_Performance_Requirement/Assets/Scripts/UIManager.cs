using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIManager : MonoBehaviour
{
    //Static reference because we only want one instance of the manager 
    public static UIManager instance;
    public Image fader;
    private TextMeshProUGUI coinsText;
    public AnimationCurve fadeCurve;

    //Allow only one instance of the manager to exist (Singleton pattern)
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
        if (coinsText == null) coinsText = GameObject.Find("CoinsText").GetComponent<TextMeshProUGUI>();
        if (fader == null) fader = GameObject.Find("Fader").GetComponent<Image>();

    }

    public IEnumerator Fade(string inOrOut, float duration)
    {
        float time = 0;
        while (time < duration)
        {
            time += Time.deltaTime;
            //Will fade IN if the argument is "in", and fade OUT if the argument is "out"
            fader.color = inOrOut == "in" ? Color.Lerp(Color.black, Color.clear, time / duration) : Color.Lerp(Color.clear, Color.black, time / duration);
            yield return null;
        }
    }
    public void UpdateCoinsText()
    {
        coinsText.text = "$ = " + PlayerStats.instance.coinsHeld;
        StartCoroutine(CoinTextFeedback(1));
    }
    IEnumerator CoinTextFeedback(float duration)
    {
        float time = 0;
        while (time < duration)
        {
            time += Time.deltaTime;
            //Will fade IN if the argument is "in", and fade OUT if the argument is "out"
            coinsText.color = Color.Lerp(Color.white, Color.yellow, fadeCurve.Evaluate(time / duration));
            coinsText.rectTransform.localScale = Vector3.Lerp(Vector3.one, Vector3.one * 2, fadeCurve.Evaluate(time / duration));

            yield return null;
        }
    }


}