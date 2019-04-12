using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int score { get; private set; }

    private int _realTimeScoreText;

    public void AddScore(){
        score++;
        Debug.Log("Current Score: " + score);
    }
}
