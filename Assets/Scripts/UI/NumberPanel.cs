using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class NumberPanel : MonoBehaviour
{
    [SerializeField] public Image number1;
    [SerializeField] public Image number2;
    [SerializeField] public Image number3;
    [SerializeField] public Image number4;
    [SerializeField] public Image number5;

    [SerializeField] Image number1Filled;
    [SerializeField] Image number2Filled;
    [SerializeField] Image number3Filled;
    [SerializeField] Image number4Filled;
    [SerializeField] Image number5Filled;

    LevelManager levelManager;

    

    private void Start()
    {
        levelManager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();

        number1.color = Color.white;      // White for number 1
        number2.color = Color.grey;      // Green for number 2
        number3.color = Color.grey; // Purple for number 3
        number4.color = Color.grey; // Orange for number 4
        number5.color = Color.grey;        // Red for number 5

        // Optionally, you can also set the filled images to their respective colors
        number1Filled.color = Color.white;
        number2Filled.color = Color.green;
        number3Filled.color = new Color(0.5f, 0f, 0.5f);
        number4Filled.color = new Color(1f, 0.647f, 0f);
        number5Filled.color = Color.red;
    }

    private void FixedUpdate()
    {
        if (levelManager.currentRealmState == LevelManager.RealmState.ONE)
        {
            number1.gameObject.SetActive(false);
            number1Filled.gameObject.SetActive(true);

            //Others
            number2Filled.gameObject.SetActive(false);
            number2.gameObject.SetActive(true);
            number3Filled.gameObject.SetActive(false);
            number3.gameObject.SetActive(true);
            number4Filled.gameObject.SetActive(false);
            number4.gameObject.SetActive(true);
            number5Filled.gameObject.SetActive(false);
            number5.gameObject.SetActive(true);
        }
        else if (levelManager.currentRealmState == LevelManager.RealmState.TWO)
        {
            number2.gameObject.SetActive(false);
            number2Filled.gameObject.SetActive(true);

            number1Filled.gameObject.SetActive(false);
            number1.gameObject.SetActive(true);
            number3Filled.gameObject.SetActive(false);
            number3.gameObject.SetActive(true);
            number4Filled.gameObject.SetActive(false);
            number4.gameObject.SetActive(true);
            number5Filled.gameObject.SetActive(false);
            number5.gameObject.SetActive(true);
        }
        else if (levelManager.currentRealmState == LevelManager.RealmState.THREE)
        {
            number3.gameObject.SetActive(false);
            number3Filled.gameObject.SetActive(true);

            number1Filled.gameObject.SetActive(false);
            number1.gameObject.SetActive(true);
            number2Filled.gameObject.SetActive(false);
            number2.gameObject.SetActive(true);
            number4Filled.gameObject.SetActive(false);
            number4.gameObject.SetActive(true);
            number5Filled.gameObject.SetActive(false);
            number5.gameObject.SetActive(true);
        }
        else if (levelManager.currentRealmState == LevelManager.RealmState.FOUR)
        {
            number4.gameObject.SetActive(false);
            number4Filled.gameObject.SetActive(true);

            number1Filled.gameObject.SetActive(false);
            number1.gameObject.SetActive(true);
            number2Filled.gameObject.SetActive(false);
            number2.gameObject.SetActive(true);
            number3Filled.gameObject.SetActive(false);
            number3.gameObject.SetActive(true);
            number5Filled.gameObject.SetActive(false);
            number5.gameObject.SetActive(true);
        }
        else if (levelManager.currentRealmState == LevelManager.RealmState.FIVE)
        {
            number5.gameObject.SetActive(false);
            number5Filled.gameObject.SetActive(true);

            number1Filled.gameObject.SetActive(false);
            number1.gameObject.SetActive(true);
            number2Filled.gameObject.SetActive(false);
            number2.gameObject.SetActive(true);
            number3Filled.gameObject.SetActive(false);
            number3.gameObject.SetActive(true);
            number4Filled.gameObject.SetActive(false);
            number4.gameObject.SetActive(true);
        }
    }
}
