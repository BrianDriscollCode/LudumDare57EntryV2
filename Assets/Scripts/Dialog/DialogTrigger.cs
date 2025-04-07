using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DialogTrigger : MonoBehaviour
{
    [SerializeField] private DialogRunner dialogRunner; // Drag your DialogRunner object here
    private BoxCollider2D BoxCollider2D;
    Player player;

    [SerializeField] bool TriggerEndState;
    [SerializeField] bool TriggerLastCutScene;
    LevelManager levelManager;
    private void Start()
    {
        levelManager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        BoxCollider2D = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            dialogRunner.StartDialog();
            Debug.Log("Player entered dialog trigger.");
            BoxCollider2D.enabled = false;
            player.currentPlayerState = Player.PlayerState.INDIALOG;

            if (TriggerEndState)
            {
                levelManager.endGameState = true;
            }
        }
    }
}

