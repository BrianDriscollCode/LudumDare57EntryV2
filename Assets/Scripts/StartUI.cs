using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartUI : MonoBehaviour
{
    [SerializeField] Button button;

    public void OnButtonClick()
    {
        SceneManager.LoadScene("Level1");
    }

}
