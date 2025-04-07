using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
 

    private void Start()
    {
        LoadStartScreen();
    }

    void LoadGameScene()
    {
        SceneManager.LoadScene("Game");
    }

    void LoadStartScreen()
    {
        SceneManager.LoadScene("StartScreen");
    }
   
}
