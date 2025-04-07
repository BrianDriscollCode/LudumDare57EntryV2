using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Runtime.CompilerServices;
using UnityEngine.SceneManagement;

public class LastSceneManager : MonoBehaviour
{
    [SerializeField] GameObject HeavenlyLights;

    [SerializeField] Player player;
    [SerializeField] GameObject flyPoint;
    [SerializeField] float moveDuration = 8f; // Duration for the movement

    [SerializeField] private CanvasGroup startCanvasGroup;
    [SerializeField] float startFadeDuration = 4f;

    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] float fadeDuration = 4f; // Duration for fading

    [SerializeField] private CanvasGroup CanvasGroupUI;
    [SerializeField] float UIfadeDuration = 2f;

    private void Start()
    {

        FadeOutStartPanel();
        HeavenlyLights.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            FloatGirl();
        }
    }

    public void StartLastCutScene()
    {
        Debug.Log("START LAST CUTSCENE");
        StartCoroutine(RunLastCutScene());
    }

    IEnumerator RunLastCutScene()
    {
        RestoreGirl();
        yield return new WaitForSeconds(2);

        FloatGirl();
        ActivateHeavenlyLights();
    }


    private void RestoreGirl()
    {
        player.GetComponent<Animator>().Play("Restored");
        player.transform.localScale = new Vector3(1, 1, 1);
    }

    private void FloatGirl()
    {
        player.GetComponent<Animator>().Play("Floating");
        player.transform.localScale = new Vector3(1, 1, 1);
        MovePlayerToFlyPoint();
    }

    private void ActivateHeavenlyLights()
    {
        HeavenlyLights.SetActive(true);
    }

    private void MovePlayerToFlyPoint()
    {
        // Use DOPath if you want to make a path, or use DOMove for a straight line.
        player.transform.DOMove(flyPoint.transform.position, moveDuration)
            .SetEase(Ease.Linear)  // Linear easing for smooth movement
            .OnComplete(() => Debug.Log("Player has reached the fly point!"));

        StartCoroutine(StartFade());
        StartCoroutine(EndGame());
    }

    IEnumerator StartFade()
    {
        FadeOutPanel();
        yield return new WaitForSeconds(2);
        FadeInPanel();
    }

    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(6.5f);
        SceneManager.LoadScene("StartScreen");
    }

    // Fade out the canvas (panel)
    private void FadeOutPanel()
    {
        if (canvasGroup != null)
        {
            // Tween the alpha of the CanvasGroup to fade out (alpha = 0)
            CanvasGroupUI.DOFade(0f, fadeDuration)
                .OnComplete(() => Debug.Log("Canvas faded out!"));
        }
    }

    // Fade in the canvas (optional)
    public void FadeInPanel()
    {
        if (canvasGroup != null)
        {
            canvasGroup.DOFade(1f, fadeDuration)
                .OnComplete(() => Debug.Log("Canvas faded in!"));
        }
    }

    private void FadeOutStartPanel()
    {
        if (canvasGroup != null)
        {
            // Tween the alpha of the CanvasGroup to fade out (alpha = 0)
            startCanvasGroup.DOFade(0f, startFadeDuration)
                .OnComplete(() => Debug.Log("Canvas faded out!"));
        }
    }
}
