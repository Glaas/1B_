using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //Static reference because we only want one instance of the manager 
    public static UIManager instance;
    public Image fader;

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


}