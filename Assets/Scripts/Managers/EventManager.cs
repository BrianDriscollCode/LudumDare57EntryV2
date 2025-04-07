using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    public static event UnityAction OpenDoor;
    public static void OnOpenDoor() => OpenDoor?.Invoke();
}
