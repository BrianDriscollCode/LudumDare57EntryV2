using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HandlePlayerAnimations : MonoBehaviour
{
    Animator animator;
    Player player;
    LevelManager levelManager;

    bool resetToLastAnim = false;
    [SerializeField] AudioSource audioSource;

    enum playerAnimState
    {
        LEFT,
        RIGHT,
        NON
    }

    private void Start()
    {
        audioSource.enabled = false;
        levelManager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();
        animator = GetComponent<Animator>();
        player = GetComponent<Player>();
    }

    private void Update()
    {

        if (levelManager.lastCutScene)
        {
            if (!resetToLastAnim)
            {
                animator.Play("IdleAnim");
                resetToLastAnim = true;
                audioSource.enabled=false;
            }

            return;
        }


        if (player.currentPlayerState == Player.PlayerState.INDIALOG)
        {
            animator.Play("IdleAnim");
            audioSource.enabled=false;
            return;
        }

        bool isMovingLeft = Input.GetKey(KeyCode.A);
        bool isMovingRight = Input.GetKey(KeyCode.D);

        if (isMovingLeft && player.isGrounded)
        {
            animator.Play("RunAnim");
            transform.localScale = new Vector3(-1, 1, 1);
            //audioSource.Play();
        }
        else if (isMovingRight && player.isGrounded)
        {
            animator.Play("RunAnim");
            transform.localScale = new Vector3(1, 1, 1);
            //audioSource.Play();
        }
        else if (!player.isGrounded)
        {
            animator.Play("Jump");
        }
        else
        {
            animator.Play("IdleAnim");

        }

        if ((isMovingLeft || isMovingRight) && player.isGrounded)
        {
            audioSource.enabled = true;
        }
        else
        {
            audioSource.enabled = false;
        }
    }
}
