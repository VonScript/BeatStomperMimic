using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum GameState
{
    TitleScreen, Game
}

public class GameManager : MonoBehaviour
{
    public static GameManager current { get; private set; }

    public static GameState state { get; private set; } = GameState.TitleScreen;

    public bool jumpState = false;

    public bool activePlatformState = false;

    public bool aiborneState = false;

    private TextMeshProUGUI _finalScoreText;

    private ScoreManager _scoreManager;


    private void Awake(){
        if (current == null){
            current = this;
            DontDestroyOnLoad(gameObject);
        }else{
            DestroyImmediate(gameObject);
        }

        _scoreManager = GetComponent<ScoreManager>();
    }

    public void StartGame(){
        state = GameState.Game;

        FindObjectOfType<PlatformManager>().StartGame();

        GameObject.Find("GetReady").SetActive(false);
    }

    public void StopGame(){
        state = GameState.TitleScreen;
        
        _finalScoreText.SetText(string.Format("{0}"), _scoreManager.score);
    }

}
