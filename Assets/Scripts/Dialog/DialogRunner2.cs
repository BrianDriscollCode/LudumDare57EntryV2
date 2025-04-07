using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;



public class DialogRunner2 : MonoBehaviour
{
    [SerializeField] private GameObject[] panels;
    private int currentPanelIndex = -1;
    private bool canRunDialog = false;

    Player player;

    GameObject HelperGhost;
    Animator HelperGhostAnimator;
    Animator HelperGhostAnimator2;

    LevelManager levelManager;
    LastSceneManager lastSceneManager;

    private void Start()
    {
        lastSceneManager = GameObject.FindGameObjectWithTag("LastSceneManager").GetComponent<LastSceneManager>();
        levelManager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>(); ;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        HelperGhost = GameObject.FindGameObjectWithTag("HelperGhost");
        HelperGhostAnimator = HelperGhost.GetComponent<Animator>();
        HelperGhostAnimator2 = GameObject.FindGameObjectWithTag("HelperGhost2").GetComponent<Animator>();
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
        else
        {
            lastSceneManager.StartLastCutScene();
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


