using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orb : MonoBehaviour
{
    LevelManager levelManager;
    BoxCollider2D BoxCollider2D;

    bool inUse = false;

    private void Start()
    {
        BoxCollider2D = GetComponent<BoxCollider2D>();
        levelManager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !inUse)
        {
            inUse = true;
            levelManager.IncrementOrb();
            Destroy(gameObject);
        }
    }
}
