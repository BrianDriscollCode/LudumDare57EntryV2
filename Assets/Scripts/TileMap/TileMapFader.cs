using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class TilemapFader : MonoBehaviour
{
    private TilemapRenderer tilemapRenderer;
    private Tilemap tilemap;

    public float fadeDuration = 0.5f;

    void Awake()
    {
        tilemapRenderer = GetComponent<TilemapRenderer>();
        tilemap = GetComponent<Tilemap>();
    }

    public void FadeIn()
    {
        gameObject.SetActive(true);
        StartCoroutine(FadeTilemap(0f, 1f));
    }

    public void FadeOut()
    {
        StartCoroutine(FadeTilemap(1f, 0f, () => gameObject.SetActive(false)));
    }

    private IEnumerator FadeTilemap(float startAlpha, float endAlpha, System.Action onComplete = null)
    {
        float elapsed = 0f;
        Color color = tilemap.color;

        while (elapsed < fadeDuration)
        {
            float alpha = Mathf.Lerp(startAlpha, endAlpha, elapsed / fadeDuration);
            tilemap.color = new Color(color.r, color.g, color.b, alpha);
            elapsed += Time.deltaTime;
            yield return null;
        }

        tilemap.color = new Color(color.r, color.g, color.b, endAlpha);
        onComplete?.Invoke();
    }


}

