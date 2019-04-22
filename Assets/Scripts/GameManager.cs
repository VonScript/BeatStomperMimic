using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState{
    TitleScreen,
    GameScreen
}

public class GameManager : MonoBehaviour
{
    public static GameManager main { get; private set; }

    public GameState state = GameState.TitleScreen;

    public int level;

    private GameObject _titleScreen = null;

    private GameObject _gameScreen = null;

    private ArtifactSpawn _artifact;

    private PlatformManager _platform;

    private ScoreManager _score;

    private CameraControl _camera;

    void Awake(){
        _artifact = FindObjectOfType<ArtifactSpawn>();
        _platform = FindObjectOfType<PlatformManager>();
        _score = FindObjectOfType<ScoreManager>();
        _camera = FindObjectOfType<CameraControl>();

        _titleScreen = GameObject.Find("TitleScreen");
        _gameScreen = GameObject.Find("GameScreen");

        _gameScreen.SetActive(false);
        _score.HighScore();
    }

    public void StartGame(){
        state = GameState.GameScreen;
        _score.ClearScore();
        _titleScreen.SetActive(false);
        _gameScreen.SetActive(true);
        _artifact.SpawnArtifact();
    }

    public void StopGame(){
        _platform.Clear();
        _camera.Reset();
        state = GameState.TitleScreen;
        _gameScreen.SetActive(false);
        _titleScreen.SetActive(true);
        _score.HighScore();
    }
}
