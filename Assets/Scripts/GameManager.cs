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


    public GameObject cell_1;

    public GameObject cell_2;

    public GameObject cell_3;

    public int level;


    private GameObject _titleScreen = null;

    private GameObject _gameScreen = null;

    private List<GameObject> _backdrop;


    private ArtifactSpawn _artifact;

    private CameraControl _camera;

    private OverlayColours _overlay;

    private PlatformManager _platform;

    private ScoreManager _score;

    private MusicControl _music;


    private void Awake(){
        _artifact = FindObjectOfType<ArtifactSpawn>();
        _camera = FindObjectOfType<CameraControl>();
        _music = FindObjectOfType<MusicControl>();
        _platform = FindObjectOfType<PlatformManager>();
        _overlay = FindObjectOfType<OverlayColours>();
        _score = FindObjectOfType<ScoreManager>();

        _titleScreen = GameObject.Find("TitleScreen");
        _gameScreen = GameObject.Find("GameScreen");

        _backdrop = new List<GameObject> { cell_1, cell_2, cell_3 };
        
        _gameScreen.SetActive(false);
        _score.SetHighScore();
    }

    public void StartGame(){
        state = GameState.GameScreen;

        _score.ClearScore();
        
        _titleScreen.SetActive(false);
        _gameScreen.SetActive(true);
        _artifact.SpawnArtifact();

        _backdrop[level-1].SetActive(true);
        _music.PlaySong(level);
    }

    public void StopGame(){
        _music.StopSong(level);

        _artifact.Clear();
        _platform.Clear();
        _camera.Reset();

        state = GameState.TitleScreen;

        _backdrop[level-1].SetActive(false);
        _overlay.RandomLevel();

        _gameScreen.SetActive(false);
        _titleScreen.SetActive(true);
        
        _score.SetHighScore();
    }
}
