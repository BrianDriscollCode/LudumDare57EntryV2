using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTrigger : MonoBehaviour
{
    [SerializeField] int roomValue;
    [SerializeField] LightManager lightManager;


    private void OnTriggerExit2D(Collider2D collision)
    {
        lightManager.SetRoom(roomValue);
    }
}
