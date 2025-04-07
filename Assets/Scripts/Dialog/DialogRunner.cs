using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;



public class DialogRunner : MonoBehaviour
{
    [SerializeField] private GameObject[] panels;
    private int currentPanelIndex = -1;
    private bool canRunDialog = false;

    Player player;

    GameObject HelperGhost;
    Animator HelperGhostAnimator;

    LevelManager levelManager;

    private void Start()
    {
        levelManager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>(); ;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        HelperGhost = GameObject.FindGameObjectWithTag("HelperGhost");
        HelperGhostAnimator = HelperGhost.GetComponent<Animator>();
        SetAllPanelsInactive();
    }

    private void Update()
    {
        if (canRunDialog && Input.GetKeyDown(KeyCode.Space))
        {
            ShowNextPanel();
        }
    }

    public void StartDialog()
    {
        canRunDialog = true;
        currentPanelIndex = -1;
        ShowNextPanel();
    }

    private void ShowNextPanel()
    {
        SetAllPanelsInactive();

        currentPanelIndex++;
        if (currentPanelIndex < panels.Length)
        {
            panels[currentPanelIndex].SetActive(true);
        }
        else if (levelManager.helperGhostGone)
        {
            player.currentPlayerState = Player.PlayerState.INGAME;
        }
        else
        {
            canRunDialog = false; // end of dialog
            HelperGhostAnimator.enabled = true;
            HelperGhostAnimator.Play("Disappear");
            levelManager.unlockedRealms[2] = true;
        }
    }

    private void SetAllPanelsInactive()
    {
        foreach (GameObject panel in panels)
        {
            panel.SetActive(false);
        }
    }
}


