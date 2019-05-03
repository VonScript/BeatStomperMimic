using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpControl : MonoBehaviour
{
    public bool jump = false;

    public bool boost = false;

    public ParticleSystem boom;


    private float _forceUp = 12f;

    private float _forceDown = -24f;

    private float _minAngle = -90f;

    private float _maxAngle = 45f;

    private float _minTrajectory = -4f;

    private float _maxTrajectory = 4f;

    private float _rotationMultiplier = 5f;


    private OverlayColours _oc;

    private GameManager _gm;

    private PlatformManager _pm;

    private ScoreManager _sm;


    private Rigidbody2D _klay;

    private Collider2D _klayCollider;

    private Vector2 _velocity;


    private bool _airborne;

    private bool _first = true;

    
    private void Awake()
    {
        _oc = FindObjectOfType<OverlayColours>();
        _gm = FindObjectOfType<GameManager>();
        _pm = FindObjectOfType<PlatformManager>();
        _sm = FindObjectOfType<ScoreManager>();

        _klay = GetComponent<Rigidbody2D>();
        _klayCollider = GetComponent<Collider2D>();
        _velocity = _klay.velocity;
    }

    private IEnumerator Blackstar(){
        boom.Play();
        yield return new WaitForSeconds(0.5f);
        boom.Stop();
    }

    private void FixedUpdate(){
        float angle = Mathf.Clamp(_klay.velocity.y * _rotationMultiplier, _minAngle, _maxAngle);
        _klay.MoveRotation(angle);

        _airborne = true;
    }

    private void Jump(){   
        float x_axis;

        //The first jump is always straight up, including after a score boost
        if(_first){ 
            x_axis = 0f;
            _first = false;
        }else{ 
            x_axis = Random.Range(_minTrajectory, _maxTrajectory);
        }

        if(!jump){
            if(!_airborne){
                _velocity.y = _forceUp;
                _velocity.x = x_axis;

                _klay.velocity = _velocity;
                jump = true;
            }
        }else{
            if(_airborne){
                _velocity.y = _forceDown;
                _velocity.x = 0f;

                _klay.velocity = _velocity;
                jump = false;
            }
        }
    }

    private void OnBecameInvisible(){
        _gm.StopGame();
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collider){
        StartCoroutine(Blackstar());

        if(collider.name == "ScoringTrigger"){
            if(jump) jump = false;
        }

        if(collider.name == "Breakout"){
            _sm.boost = true;
            _oc.InvertColours();
            Destroy(_pm.up);
            _first = true;
        }
    }

    void OnTriggerStay2D(Collider2D collider){
        if(collider.name == "ScoringTrigger"){
            _airborne = false;
        }
    }

    private void Update(){
        if (Input.GetButtonDown("Jump")){
            Jump();
        }
    }
}
