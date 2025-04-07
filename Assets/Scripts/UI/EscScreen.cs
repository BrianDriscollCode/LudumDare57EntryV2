using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class EscScreen : MonoBehaviour
{
    [SerializeField] Button button;
    [SerializeField] CanvasGroup canvasGroup;
    [SerializeField] float fadeDuration;
    
    enum UIState
    {
        ACTIVE,
        TRANSITION,
        INACTIVE
    }

    UIState currentState = UIState.INACTIVE;

    private void Start()
    {
        canvasGroup.DOFade(0f, 0.0f)
                .OnComplete(() => currentState = UIState.INACTIVE);
    }

    public void OnButtonPress()
    {
        Debug.Log("Button Pressed");
        SceneManager.LoadScene("Level1");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleUI();
        }
    }

    private void ToggleUI()
    {
        if (currentState == UIState.INACTIVE)
        {
            FadeInPanel();
            currentState = UIState.TRANSITION;
        }
        else if (currentState == UIState.ACTIVE)
        {
            FadeOutPanel();
            currentState = UIState.TRANSITION;
        }
        else
        {
            return;
        }
    }

    // Fade out the canvas (panel)
    private void FadeOutPanel()
    {
        if (canvasGroup != null)
        {
            // Tween the alpha of the CanvasGroup to fade out (alpha = 0)
            canvasGroup.DOFade(0f, fadeDuration)
                .OnComplete(() => currentState = UIState.INACTIVE);
        }
    }

    // Fade in the canvas (optional)
    public void FadeInPanel()
    {
        if (canvasGroup != null)
        {
            canvasGroup.DOFade(1f, fadeDuration)
                .OnComplete(() => currentState = UIState.ACTIVE);
        }
    }
}
