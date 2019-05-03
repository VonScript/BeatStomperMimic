using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI score;

    public TextMeshProUGUI currentScore;

    public TextMeshProUGUI highScore;


    public bool boost;


    private CameraControl _cc;

    private PlatformManager _pm;


    private int playerScore;

    private int playerHighScore = 0;

    private int boostScore = 20;


    private void Awake()
    {
        _cc = FindObjectOfType<CameraControl>();
        _pm = FindObjectOfType<PlatformManager>();
    }

    public void ClearScore(){
        playerScore = 0;
        score.SetText("0");
    }

    public void SetHighScore(){
        int hs = PlayerPrefs.GetInt("Highscore");
        playerHighScore = hs;

        if(playerScore > playerHighScore) playerHighScore = playerScore;

        currentScore.SetText(playerScore.ToString());
        highScore.SetText(playerHighScore.ToString());
        PlayerPrefs.SetInt("Highscore", playerHighScore);
    }

    public void SetScore(int newscore){
        if(newscore > playerScore){
            if(boost){
                newscore += boostScore;
                _pm.platformNum += boostScore;
                boost = false;
            }

            playerScore = newscore;
            score.SetText(newscore.ToString());
            _cc.MoveUp(); 
            _pm.SpawnPlatform();
        }
    }
}
