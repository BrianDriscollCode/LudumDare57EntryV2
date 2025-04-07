using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{

    private Animator animator;
    private BoxCollider2D boxCollider2D;
    LevelManager levelManager;

    [SerializeField] int neededOrbsToOpen;

    void Start()
    {
        levelManager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();

        animator = GetComponent<Animator>();
        animator.Play("StayClosed");

        var colliders = GetComponents<BoxCollider2D>();

        foreach (var col in colliders)
        {
            if (col.isTrigger)
            {
                // This is your trigger collider
                Debug.Log("Found Trigger Collider");
            }
            else
            {
                // This is your solid/collision collider
                boxCollider2D = col;
                Debug.Log("Found Collision Collider");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && levelManager.collectedOrbs >= neededOrbsToOpen)
        {
            Interact();
        }
    }

    public void Interact()
    {
        Debug.Log("Interacted");
        animator.Play("Open");
        StartCoroutine(DisableColliderAfterDelay(0.5f));
    }

    private IEnumerator DisableColliderAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        if (boxCollider2D != null)
        {
            boxCollider2D.enabled = false;
            Debug.Log("Collision Collider disabled after delay");
        }
    }
}
