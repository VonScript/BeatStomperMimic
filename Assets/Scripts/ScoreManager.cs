using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI score;

    public TextMeshProUGUI highScore;

    private int playerScore;

    private int playerHighScore = 0;

    private CameraControl _cc;

    private PlatformManager _pm;

    void Awake()
    {
        _cc = FindObjectOfType<CameraControl>();
        _pm = FindObjectOfType<PlatformManager>();
        score.SetText("0");
    }

    public void SetScore(int newscore){
        if(newscore > playerScore){
            playerScore = newscore;
            score.SetText(newscore.ToString());
            _cc.MoveUp();
            _pm.SpawnPlatform();
            Debug.Log(newscore + " - " + playerScore);
        }
    }

    public void HighScore(){
        if(playerScore > playerHighScore) playerHighScore = playerScore;

        highScore.SetText(playerHighScore.ToString());
    }

    public void ClearScore(){
        playerScore = 0;
        score.SetText("0");
    }
}
