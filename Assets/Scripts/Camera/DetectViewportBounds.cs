using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DetectViewportBounds : MonoBehaviour
{

    [SerializeField] GameObject player;  // Player reference (can be assigned in the Inspector or passed dynamically)
    private bool isTweening = false;  // Flag to ensure tween is only created once per boundary exit

    void Update()
    {
        if (player != null)
        {

            Vector3 viewportPos = Camera.main.WorldToViewportPoint(player.transform.position);


            if (viewportPos.x < 0 && !isTweening)
            {
                Debug.Log("Player left the screen");

                Vector3 targetPosition = transform.position + new Vector3(-40, 0, 0);
                transform.DOMove(targetPosition, 1f);

                isTweening = true;

                StartCoroutine(resetIsTweening(1f));

            }
            else if (viewportPos.x > 1 && !isTweening)  
            {
                Debug.Log("Player right the screen");

  
                Vector3 targetPosition = transform.position + new Vector3(40, 0, 0);
                transform.DOMove(targetPosition, 1f);  


                isTweening = true;

                StartCoroutine(resetIsTweening(1f));
            }

            if (viewportPos.y < 0 && !isTweening)
            {
                Vector3 targetPosition = transform.position + new Vector3(0, -22.5f, 0);
                transform.DOMove(targetPosition, 1f);
                Debug.Log("Player bottom the screen");
                isTweening = true;
                StartCoroutine(resetIsTweening(1f));
            }
            else if (viewportPos.y > 1 && !isTweening)
            {
                Vector3 targetPosition = transform.position + new Vector3(0,22.5f, 0);
                transform.DOMove(targetPosition, 1f);
                Debug.Log("Player top the screen");
                isTweening = true;
                StartCoroutine(resetIsTweening(1f));
            }
        }
        else
        {
            Debug.LogWarning("Player reference not assigned!");
        }
    }

    private IEnumerator resetIsTweening(float delay)
    {
        yield return new WaitForSeconds(delay);
        isTweening = false;
    }




}
