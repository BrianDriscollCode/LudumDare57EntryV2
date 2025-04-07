using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastSceneManager : MonoBehaviour
{
    [SerializeField] GameObject HeavenlyLights;

    [SerializeField] Player player;

    private void Start()
    {
        HeavenlyLights.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            FloatGirl();
        }
    }

    private void RestoreGirl()
    {
        player.GetComponent<Animator>().Play("Restored");
        player.transform.localScale = new Vector3(1, 1, 1);
    }

    private void FloatGirl()
    {
        player.GetComponent<Animator>().Play("Floating");
        player.transform.localScale = new Vector3(1, 1, 1);
    }

    private void ActivateHeavenlyLights()
    {
        HeavenlyLights.SetActive(true);
    }

}
