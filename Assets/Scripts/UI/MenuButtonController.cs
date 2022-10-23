using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuButtonController : MonoBehaviour
{
    [SerializeField] Animator mainMenuScreen;
    [SerializeField] Animator start;
    [SerializeField] Animator quit;
    public void StartGame()
    {
        StartCoroutine(DelayDisplayOpening());
    }
    IEnumerator DelayDisplayOpening()
    {
        mainMenuScreen.Play("FadeOut");
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadScene("MainScenes");
    }
    IEnumerator DelayDisplayAudioMenu()
    {
        mainMenuScreen.Play("FadeOut");
        yield return new WaitForSeconds(0.2f);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
