using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public Scoring scoring;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision){
        if ( collision.CompareTag("Player")){
            Destroy(this.gameObject);

            scoring.AddScore(1);
        }
    }
}
