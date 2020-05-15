using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeatZone : MonoBehaviour
{
    public LevelOne levelOne;
    public Snowy snowy;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if ( collision.CompareTag("Player"))
        {
            if (snowy.health > 0)
            {
                if (levelOne.actualZoneTimer > 0) //Cooldown
                {
                    levelOne.actualZoneTimer -= Time.deltaTime;
                    snowy.transform.localScale += new Vector3(-.0015f,-.0015f,-.0015f);
                    snowy.health -= 0.3f;
                } 
                else if (levelOne.actualZoneTimer < 0)
                {
                    levelOne.actualZoneTimer = levelOne.zoneTimer;
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
         if ( collision.CompareTag("Player"))
         {
             levelOne.actualZoneTimer = levelOne.zoneTimer;
         }
    }
}
