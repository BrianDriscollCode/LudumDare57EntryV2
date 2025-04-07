using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public bool lastCutScene = false;

    public bool endGameState = false;
    [SerializeField] PostProcessing postProcessing;
    bool inEndGameState = false;

    public enum RealmState
    {
        ONE, TWO, THREE, FOUR, FIVE
    }

    public RealmState currentRealmState = RealmState.ONE;

    public int collectedOrbs = 0;

    public Dictionary<int, bool> unlockedRealms;

    public bool helperGhostGone = false;

    public AudioSource audioSource;
    bool playAudioSource = false;

    public NumberPanel numberPanel;

    private void Start()
    {

        numberPanel = GameObject.FindGameObjectWithTag("NumberPanel").GetComponent<NumberPanel>();

        audioSource = GetComponent<AudioSource>();
        unlockedRealms = new Dictionary<int, bool>();

        unlockedRealms.Add(1, true);
        unlockedRealms.Add(2, false);
        unlockedRealms.Add(3, false);
        unlockedRealms.Add(4, false);
        unlockedRealms.Add(5, false);
    }

    private void Update()
    {
        if (playAudioSource)
        {
            playAudioSource = false;
            audioSource.Play();
        }

        if (endGameState && !inEndGameState)
        {
            postProcessing.TriggerFifthPostProcessing();
            inEndGameState = true;
        }
    }

    public void IncrementOrb()
    {
        collectedOrbs += 1;
        playAudioSource = true;

        if (collectedOrbs >= 2)
        {
            unlockedRealms[3] = true;
            numberPanel.number3.color = new Color(0.5f, 0f, 0.5f);
        }

        if (collectedOrbs >= 3)
        {
            unlockedRealms[4] = true;
            numberPanel.number4.color = new Color(1f, 0.647f, 0f);
        }

        if (collectedOrbs >= 4)
        {
            unlockedRealms[5] = true;
            numberPanel.number5.color = Color.red;
        }

    }

    public void ToggleHelperGhostStatus()
    {
        helperGhostGone = true;
    }

}