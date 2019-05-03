using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Platform : MonoBehaviour
{
    private Collider2D _land = null;

    private Rigidbody2D _rb;

    private ScoreManager _sm;


    private float _delta;

    private int _score = 0;

    private Vector3 _startPos;


    public GameObject scoreTrigger = null;


    void Awake(){
        _land = scoreTrigger.GetComponent<Collider2D>();
        
        _sm = FindObjectOfType<ScoreManager>();
        _rb = GetComponent<Rigidbody2D>();

        _startPos = transform.position;
    }

    private void OnBecameInvisible(){
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D klay){
        if(_land.IsTouching(klay)){
            klay.transform.SetParent(this.transform);
            int num;
            int.TryParse(this.name, out num);
            if(num > _score){
                _score = num;
                _sm.SetScore(num);
            }
        }
    }

    private void Update(){
        if(this.name != "0"){
            int num;
            int.TryParse(this.name, out num);

            if((num % 2) == 0){
                _delta = 1.2f;
            }else{
                _delta = -1.2f;
            }

            Vector3 v = _startPos;
            v.x += _delta * Mathf.Sin(Time.time * 2f);
            transform.position = v;
        }
    }
}
