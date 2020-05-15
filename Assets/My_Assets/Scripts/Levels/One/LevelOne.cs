using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelOne : MonoBehaviour
{
    public Snowy snowy;
    
    private Transform playerSpawn;
    
    //Cold_Heat
    public float zoneTimer;
    public float actualZoneTimer;
    void Start()
    {
        //Time = 1
        Time.timeScale = 1f;
        PauseMenu.GameIsPaused = false;

        //Initializing
        playerSpawn = GameObject.FindGameObjectWithTag("PlayerSpawn").transform;
        snowy.rb.position = playerSpawn.position;
        snowy.growthState = 1;

        //ColdHeat
        actualZoneTimer = zoneTimer;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
