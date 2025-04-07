using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightManager : MonoBehaviour
{
    [SerializeField] Light2D light1;
    [SerializeField] Light2D light2;
    [SerializeField] Light2D light2Point5;
    [SerializeField] Light2D light3;

    enum Room 
    {
        room1,
        room2,        
        room3,
        room4
    }

    Room currentRoom;


    private void Start()
    {
        currentRoom = Room.room1;

        light1.gameObject.SetActive(true);
        light2.gameObject.SetActive(false);
        light2Point5.gameObject.SetActive(false);
        light3.gameObject.SetActive(false);
    }

    private void Update()
    {
     
    }


    public void SetRoom(int roomNumber)
    {
        if (roomNumber == 1)
        {
            currentRoom = Room.room1;
        }
        else if (roomNumber == 2)
        {
            currentRoom = Room.room2;
        }
        else if (roomNumber == 3)
        {
            currentRoom = Room.room3;
        }
        else if (roomNumber == 4)
        {
            currentRoom = Room.room4;
        }
        else
        {
            Debug.LogError("Room number does not match. Room number: " + roomNumber);
        }

        Debug.Log("Current Room: " + currentRoom);

        if (currentRoom == Room.room1)
        {
      
            light1.gameObject.SetActive(true);
            
            light2.gameObject.SetActive(false);
            light2Point5.gameObject.SetActive(false);
            light3.gameObject.SetActive(false);
            Debug.Log("Room 1 lights on");
        }
        else if (currentRoom == Room.room2)
        {
            light1.gameObject.SetActive(false);
            light2.gameObject.SetActive(true);
            light2Point5.gameObject.SetActive(true);
            light3.gameObject.SetActive(false);
            Debug.Log("Room 2 lights on");
        }
        else if (currentRoom == Room.room3)
        {   
            light1.gameObject.SetActive(false);
            light2.gameObject.SetActive(false);
            light2Point5.gameObject.SetActive(false);
            light3.gameObject.SetActive(true);

            Debug.Log("Room 3 lights on");
        }
    }
}
