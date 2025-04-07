using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class BeginningScene : MonoBehaviour
{
    [SerializeField] CanvasGroup canvasGroup;
    [SerializeField] float fadeDuration;

    private void Start()
    {
        FadeOutPanel();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FadeInPanel();
        }
    }
   
    private void FadeOutPanel()
    {
        if (canvasGroup != null)
        {
            // Tween the alpha of the CanvasGroup to fade out (alpha = 0)
            canvasGroup.DOFade(0f, fadeDuration)
                .OnComplete(() => Debug.Log("Fade out finished"));
        }
    }

    // Fade in the canvas (optional)
    public void FadeInPanel()
    {
        if (canvasGroup != null)
        {
            canvasGroup.DOFade(1f, fadeDuration)
                .OnComplete(() => SceneManager.LoadScene("Level1")); 
        }
    }
}
