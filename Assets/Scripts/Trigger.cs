using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    [Tooltip("A flag to indicate the trigger's behaviour: false will score, true is game over")]
    public bool oops = false;

    private ScoreManager _score;

    private GameManager _gm;

    private void Awake(){

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(!oops){
            if(!_gm.activePlatformState){
                _gm.activePlatformState = true;
                _score.AddScore();
            }
        }else{
            _gm.StopGame();
        }
    }

}
