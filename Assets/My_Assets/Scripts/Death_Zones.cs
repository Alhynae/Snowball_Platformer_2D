
using UnityEngine;

public class Death_Zones : MonoBehaviour
{
    private Transform playerSpawn;
    public Snowy snowy;
    private void Awake()
    {
        playerSpawn = GameObject.FindGameObjectWithTag("PlayerSpawn").transform;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.position = playerSpawn.position;
            snowy.growthState = 1;
        }
        
        //snowy.Death();
    }
}