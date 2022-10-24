using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuButtonController : MonoBehaviour
{
    public Animator mainMenuScreen;
    public Animator start;

    public void StartGame()
    {
        StartCoroutine(DelayDisplayOpening());
    }
    public void settingButton()
    {
        StartCoroutine(DelayDisplaysetting());
    }
    public void ExitButton()
    {
        StartCoroutine(DelayDisplayExit());
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    IEnumerator DelayDisplaysetting()
    {
        mainMenuScreen.Play("SettingFadeIn");
        yield return new WaitForSeconds(0.2f);
    }
    IEnumerator DelayDisplayExit()
    {
        mainMenuScreen.Play("SettingFadeOut");
        yield return new WaitForSeconds(0.2f);
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
    

}
