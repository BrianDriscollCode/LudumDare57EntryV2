using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleHelperGhostAnimations : MonoBehaviour
{
    Animator animator;
    Player player;
    LevelManager levelManager;
    [SerializeField] int identifier;
    LastSceneManager lastSceneManager;


    private void Start()
    {
        lastSceneManager = GameObject.FindGameObjectWithTag("LastSceneManager").GetComponent<LastSceneManager>();
        levelManager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        animator = GetComponent<Animator>();
        animator.Play("Idle_Ghost");
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

        /*if (identifier == 2)
        {
            Debug.Log("HELPER GHOST DESTROYS ITSELF");
            lastSceneManager.StartLastCutScene();
        }*/
    }
}
