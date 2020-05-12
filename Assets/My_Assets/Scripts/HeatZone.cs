using UnityEngine;

public class HeatZone : MonoBehaviour
{
    public Snowy snowy;
    private void OnTriggerEnter2D(Collider2D collision){
        if ( collision.CompareTag("Player"))
        {
            snowy.Heat();
        }
    }
}
