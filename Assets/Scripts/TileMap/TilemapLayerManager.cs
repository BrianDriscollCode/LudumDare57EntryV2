using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Tilemaps;


public class TilemapLayerManager : MonoBehaviour
{
    bool LockedIntoEndGame = false;

    public TilemapFader[] layers;
    private int currentIndex = 0;

    LevelManager levelManager;

    [SerializeField] AudioSource audioSource;


    bool cooldown = false;


    private void Start()
    {
        levelManager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();

        TilemapFader Layer1 = GameObject.Find("Layer1")?.GetComponent<TilemapFader>();
        TilemapFader Layer2 = GameObject.Find("Layer2")?.GetComponent<TilemapFader>();
        TilemapFader Layer3 = GameObject.Find("Layer3")?.GetComponent<TilemapFader>();
        TilemapFader Layer4 = GameObject.Find("Layer4")?.GetComponent<TilemapFader>();
        TilemapFader Layer5 = GameObject.Find("Layer5")?.GetComponent<TilemapFader>();

        layers = new TilemapFader[] { Layer1, Layer2, Layer3, Layer4, Layer5 };

        // Set color of Layer0 (Layer1 in GameObject name)
        if (Layer1 != null)
            Layer1.GetComponent<Tilemap>().color = Color.white; // or any color you want

        // Set color of Layer1 (Layer2 in GameObject name)
        if (Layer2 != null)
            Layer2.GetComponent<Tilemap>().color = Color.green;

        // Set color of Layer1 (Layer2 in GameObject name)
        if (Layer3 != null)
            Layer3.GetComponent<Tilemap>().color = new Color(0.5f, 0f, 0.5f);
            //Layer3.GetComponent<Tilemap>().color = Color.grey;

        // Set color of Layer1 (Layer2 in GameObject name)
        if (Layer4 != null)
            Layer4.GetComponent<Tilemap>().color = new Color(1f, 0.647f, 0f);
            //Layer4.GetComponent<Tilemap>().color = Color.grey;

        if (Layer5 != null)
            Layer5.GetComponent<Tilemap>().color = Color.red;
            //Layer5.GetComponent<Tilemap>().color = Color.grey;

        HideAllExcept(currentIndex);

    }


    void Update()
    {
        if (levelManager.endGameState && !LockedIntoEndGame)
        {   
            LockedIntoEndGame = true;
            SwitchToLayer(4);
        }

        if (LockedIntoEndGame)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1) && levelManager.unlockedRealms[1])
            SwitchToLayer(0);
        else if (Input.GetKeyDown(KeyCode.Alpha2) && levelManager.unlockedRealms[2])
            SwitchToLayer(1);
        else if (Input.GetKeyDown(KeyCode.Alpha3) && levelManager.unlockedRealms[3])
            SwitchToLayer(2);
        else if (Input.GetKeyDown(KeyCode.Alpha4) && levelManager.unlockedRealms[4])
            SwitchToLayer(3);
        else if (Input.GetKeyDown(KeyCode.Alpha5) && levelManager.unlockedRealms[5])
            SwitchToLayer(4);

        Debug.Log("Cooldown: " + cooldown);
    }

    void SwitchToLayer(int index)
    {
        Debug.Log("passedIndex: " + index + "|| currentIndex: " + currentIndex);
        

        if (index == currentIndex || layers[index] == null || cooldown)
        {
            return;
        }

        currentIndex = index;
        audioSource.Play();


        if (currentIndex == 0)
        {
            levelManager.currentRealmState = LevelManager.RealmState.ONE;
        }
        else if (currentIndex == 1)
        {
            levelManager.currentRealmState = LevelManager.RealmState.TWO;
        }
        else if (currentIndex == 2)
        {
            levelManager.currentRealmState = LevelManager.RealmState.THREE;
        }
        else if (currentIndex == 3)
        {
            levelManager.currentRealmState = LevelManager.RealmState.FOUR;
        }
        else if (currentIndex == 4)
        {
            levelManager.currentRealmState = LevelManager.RealmState.FIVE;
        }
        else
        {
            Debug.LogError("Index: " + currentIndex + " -Index does not fit in current indexing - TilemapLayerManager");
        }

        Debug.Log("Current Tilemap Index: " + currentIndex);
        Debug.Log("CurrentRealmStaet: " + levelManager.currentRealmState);


        if (index < 0 || index >= layers.Length) return;

        cooldown = true;
        StartCoroutine(CooldownCountdown());
        
        for (int i = 0; i < layers.Length; i++)
        {
            if (i == index)
            {
                layers[i].FadeIn();
            }
            else
            {
                if (layers[i].isActiveAndEnabled)
                {
                    layers[i]?.FadeOut();
                }
            }
        }

        
    }

    private IEnumerator CooldownCountdown()
    {
        Debug.Log(">> Cooldown started");
        yield return new WaitForSeconds(1);
        cooldown = false;
        Debug.Log(">> Cooldown ended");
    }

    void HideAllExcept(int index)
    {
        for (int i = 0; i < layers.Length; i++)
        {
            if (layers[i] == null) continue;

            if (i == index)
            {
                layers[i].gameObject.SetActive(true); // or use your FadeIn() if needed
            }
            else
            {
                layers[i].gameObject.SetActive(false); // or FadeOut() if you're animating
            }
        }
    }


}

