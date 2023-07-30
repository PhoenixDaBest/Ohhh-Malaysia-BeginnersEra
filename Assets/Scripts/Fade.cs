using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour
{
    public GameObject blackBG;

    void Start()
    {
        blackBG.GetComponent<SpriteRenderer>().material.color = new Color(0f, 0f, 0f, 2f);

        StartCoroutine(FadeIn());
    }

    public void StartButton()
    {
        StartCoroutine(FadeOut());

        //UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

    IEnumerator FadeOut()
    { 
        float fadeRate = 0.01f;
        float i = 0f;

        do
        {
            blackBG.GetComponent<SpriteRenderer>().material.color = new Color(0f, 0f, 0f, i);
            i += fadeRate;
            yield return new WaitForSeconds(.00001f);
        } while (i <= 2);

        yield return new WaitForSeconds(2);

        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

    IEnumerator FadeIn()
    {
        float fadeRate = 0.01f;
        float i = 2f;

        do
        {
            blackBG.GetComponent<SpriteRenderer>().material.color = new Color(0f, 0f, 0f, i);
            i -= fadeRate;
            yield return new WaitForSeconds(.00001f);
        } while (i >= 0);

        //yield return new WaitForSeconds(2);

        //UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
}
