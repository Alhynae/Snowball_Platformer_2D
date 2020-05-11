using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoring : MonoBehaviour
{
    public Text textScore;
    private int score;

    public void AddScore(int count){
        score += count;
        textScore.text =  score.ToString();
    }
    
}
