using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Platform : MonoBehaviour
{
    public GameObject landTrigger = null;

    private Collider2D _land = null;

    private ScoreManager _sm;

    int _score = 0;

    void Awake(){
        _land = landTrigger.GetComponent<Collider2D>();
        _sm = FindObjectOfType<ScoreManager>();
    }

    void OnTriggerEnter2D(Collider2D klay){
        if(_land.IsTouching(klay)){
            int num;
            int.TryParse(this.name, out num);
            if(num >  _score){
                _score = num;
                _sm.SetScore(num);
            }
        }
    }

    void OnBecameInvisible(){
        Destroy(gameObject);
    }
}
