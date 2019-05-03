using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicControl : MonoBehaviour
{
    public AudioSource song_1;

    public AudioSource song_2;

    public AudioSource song_3;


    private List<AudioSource> _songs;

    private GameManager _gm;


    private void Awake(){
        _gm = FindObjectOfType<GameManager>();
        _songs = new List<AudioSource> { song_1, song_2, song_3 };
    }

    public void PlaySong(int level){
        if(_gm.state == GameState.GameScreen && _gm.level == level){
            _songs[level-1].Play();
        }
    }

    public void StopSong(int level){
        _songs[level-1].Stop();
    }
}
