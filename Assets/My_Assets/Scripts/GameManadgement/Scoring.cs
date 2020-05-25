using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Scoring : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioClip;
    public Text textScore;
    private int score;

    public void AddScore(int count){
        score += count;
        audioSource.PlayOneShot(audioClip);
        textScore.text =  score.ToString() + " /350";
    }
    
}
