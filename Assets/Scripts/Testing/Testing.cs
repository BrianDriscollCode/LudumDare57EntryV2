using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    LevelManager levelManager;
    [SerializeField] bool runTest;
    [SerializeField] HandleHelperGhostAnimations helperGhost;
    [SerializeField] DialogRunner dialogRunner;
    [SerializeField] Player player;
    [SerializeField] bool TriggerEndGameState;


    private void Start()
    {
        if (!runTest) return;

        levelManager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();
        StartCoroutine(RunTest());

        if (TriggerEndGameState)
        {
            levelManager.endGameState = true;
        }
    }

    IEnumerator RunTest()
    {
        yield return new WaitForSeconds(2f);
        levelManager.collectedOrbs = 1;
        levelManager.IncrementOrb();
        dialogRunner.StartDialog();
        player.currentPlayerState = Player.PlayerState.INDIALOG;
    }
}
