using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HandlePlayerAnimations : MonoBehaviour
{
    Animator animator;
    Player player;
    LevelManager levelManager;

    enum playerAnimState
    {
        LEFT,
        RIGHT,
        NON
    }

    private void Start()
    {
        levelManager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();
        animator = GetComponent<Animator>();
        player = GetComponent<Player>();
    }

    private void Update()
    {

        if (player.currentPlayerState == Player.PlayerState.INDIALOG)
        {
            animator.Play("IdleAnim");
            return;
        }

        bool isMovingLeft = Input.GetKey(KeyCode.A);
        bool isMovingRight = Input.GetKey(KeyCode.D);

        if (isMovingLeft)
        {
            animator.Play("RunAnim");
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (isMovingRight)
        {
            animator.Play("RunAnim");
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            animator.Play("IdleAnim");
        }
    }
}
