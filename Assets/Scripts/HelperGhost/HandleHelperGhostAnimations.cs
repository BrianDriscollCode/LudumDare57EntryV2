using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleHelperGhostAnimations : MonoBehaviour
{
    Animator animator;
    Player player;
    LevelManager levelManager;
    [SerializeField] int identifier;


    private void Start()
    {
        levelManager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        animator = GetComponent<Animator>();
        animator.enabled = false;
    }   

    public void OnAnimationComplete()
    {
        if (identifier == 1)
        {
            Debug.Log("HELPER GHOST DESTROYS ITSELF");
            player.currentPlayerState = Player.PlayerState.INGAME;
            levelManager.ToggleHelperGhostStatus();
            levelManager.numberPanel.number2.color = Color.green;
            Destroy(gameObject);
        }
    }
}
