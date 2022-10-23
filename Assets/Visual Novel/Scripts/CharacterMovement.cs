using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using Yarn;
using Yarn.Compiler;
using UnityEngine.SceneManagement;
public class CharacterMovement : MonoBehaviour
{
    public void BackToMainScenes()
    {
        SceneManager.LoadScene("MainScenes");
    }
}
