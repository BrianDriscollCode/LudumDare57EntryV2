using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PostProcessing : MonoBehaviour
{
    private Volume volume;
    private Vignette vignette;
    private FilmGrain grain;

    private float vignetteTarget = 0f;
    private float grainTarget = 0f;

    [SerializeField] private float transitionSpeed = 2f;

    LevelManager levelManager;

    private void Start()
    {
        levelManager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();

        volume = GetComponent<Volume>();

        if (volume == null || volume.profile == null)
        {
            Debug.LogError("Volume or Volume Profile is missing.");
            return;
        }

        // Try to get the Vignette override
        if (volume.profile.TryGet(out vignette))
        {
            Debug.Log("Vignette found!");
        }
        else
        {
            Debug.LogWarning("Vignette not found in the volume profile.");
        }

        // Try to get the FilmGrain override
        if (volume.profile.TryGet(out grain))
        {
            Debug.Log("Grain found!");
        }
        else
        {
            Debug.LogWarning("Grain not found in the volume profile.");
        }

        vignetteTarget = 0.3f;
        grainTarget = 0.02f;
        grain.active = true;
    }

    private void Update()
    {
        if (levelManager.endGameState) return;

        // Trigger transitions
        if (Input.GetKeyDown(KeyCode.Alpha1) && levelManager.unlockedRealms[1])
        {
            Debug.Log("Level 1 vignette and grain");
            vignetteTarget = 0.3f;
            grainTarget = 0.02f;
            grain.active = true;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && levelManager.unlockedRealms[2])
        {
            Debug.Log("Level 2 vignette and grain");
            vignetteTarget = 0.4f;
            grainTarget = 0.3f;
            grain.active = true;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) && levelManager.unlockedRealms[3])
        {
            Debug.Log("Level 3 vignette and grain");
            vignetteTarget = 0.50f;
            grainTarget = 0.4f;
            grain.active = true; // Optional: depends on whether you want to still animate it
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4) && levelManager.unlockedRealms[4])
        {
            Debug.Log("Level 3 vignette and grain");
            vignetteTarget = 0.75f;
            grainTarget = 0.6f;
            grain.active = true; // Optional: depends on whether you want to still animate it
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5) && levelManager.unlockedRealms[5])
        {
            Debug.Log("Level 3 vignette and grain");
            vignetteTarget = 0.85f;
            grainTarget = 0.8f;
            grain.active = true; // Optional: depends on whether you want to still animate it
        }

        // Smoothly move towards the target values
        if (vignette != null)
        {
            float current = vignette.intensity.value;
            float next = Mathf.Lerp(current, vignetteTarget, Time.deltaTime * transitionSpeed);
            vignette.intensity.Override(next);
        }

        if (grain != null)
        {
            float current = grain.intensity.value;
            float next = Mathf.Lerp(current, grainTarget, Time.deltaTime * transitionSpeed);
            grain.intensity.Override(next);
        }
    }

    public void TriggerFifthPostProcessing()
    {
        Debug.Log("Level 3 vignette and grain");
        vignetteTarget = 0.85f;
        grainTarget = 0.8f;
        grain.active = true; // Optional: depends on whether you want to still animate it
    }
}
