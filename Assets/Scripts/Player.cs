using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    public enum PlayerState
    {
        INGAME,
        INDIALOG
    }

    public PlayerState currentPlayerState = PlayerState.INGAME;

    public float moveSpeed = 10f;
    public float jumpForce = 13.25f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;

    private Rigidbody2D rb;
    private bool isGrounded;

    private CapsuleCollider2D capsuleCollider;

    // Wall checks
    public float wallCheckDistance = 1f;
    public Transform rightUpperCheck;
    public Transform rightLowerCheck;
    public Transform leftUpperCheck;
    public Transform leftLowerCheck;

    bool isRightWalled = false;
    bool isLeftWalled = false;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
    }

    void Update()
    {
        if (currentPlayerState == PlayerState.INGAME)
        {
            // Ground check
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

            // Raycast for right wall
            isRightWalled =
                Physics2D.Raycast(rightUpperCheck.position, Vector2.right, wallCheckDistance, groundLayer) ||
                Physics2D.Raycast(rightLowerCheck.position, Vector2.right, wallCheckDistance, groundLayer);

            if (isRightWalled)
            {
                Debug.Log("IsRightWalled");
            }

            // Raycast for left wall
            isLeftWalled =
                Physics2D.Raycast(leftUpperCheck.position, Vector2.left, wallCheckDistance, groundLayer) ||
                Physics2D.Raycast(leftLowerCheck.position, Vector2.left, wallCheckDistance, groundLayer);

            if (isLeftWalled)
            {
                Debug.Log("IsLeftWalled");
            }

            // Horizontal movement
            float move = 0f;

            if (Input.GetKey(KeyCode.D) && (!isRightWalled || isGrounded))
                move = 1f;
            else if (Input.GetKey(KeyCode.A) && (!isLeftWalled || isGrounded))
                move = -1f;

            rb.velocity = new Vector2(move * moveSpeed, rb.velocity.y);

            // Jump
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
        }
        else
        {
            rb.velocity = new Vector2(0f,0f);
        }
        
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;

        if (groundCheck != null)
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);

        // Draw right wall rays
        if (rightUpperCheck != null)
            Gizmos.DrawLine(rightUpperCheck.position, rightUpperCheck.position + Vector3.right * wallCheckDistance);
        if (rightLowerCheck != null)
            Gizmos.DrawLine(rightLowerCheck.position, rightLowerCheck.position + Vector3.right * wallCheckDistance);

        // Draw left wall rays
        if (leftUpperCheck != null)
            Gizmos.DrawLine(leftUpperCheck.position, leftUpperCheck.position + Vector3.left * wallCheckDistance);
        if (leftLowerCheck != null)
            Gizmos.DrawLine(leftLowerCheck.position, leftLowerCheck.position + Vector3.left * wallCheckDistance);
    }
}


