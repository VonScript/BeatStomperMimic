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

    float delta;
    float speed = 2.0f; 
    Vector3 startPos;

    void Awake(){
        _land = landTrigger.GetComponent<Collider2D>();
        _sm = FindObjectOfType<ScoreManager>();
        startPos = transform.position;
        startPos.x += 0.18f;
    }

    void OnTriggerEnter2D(Collider2D klay){
        if(_land.IsTouching(klay)){
            klay.transform.SetParent(this.transform);
            int num;
            int.TryParse(this.name, out num);
            if(num >  _score){
                _score = num;
                _sm.SetScore(num);
            }
        }
    }

    public void Update(){
        if(this.name != "0"){
            int num;
            int.TryParse(this.name, out num);

            if((num % 2) == 0){
                delta = 1.2f;
            }else{
                delta = -1.2f;
            }

            Vector3 v = startPos;
            v.x += delta * Mathf.Sin (Time.time * speed);
            transform.position = v;
        }
    }

    void OnBecameInvisible(){
        Destroy(gameObject);
    }
}
