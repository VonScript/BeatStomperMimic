using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpControl : MonoBehaviour
{
    private float _forceUp = 12f;

    private float _forceDown = -40f;

    private float _rotationMultiplier = 5f;

    private float _minAngle = -90f;

    private float _maxAngle = 45f;

    private float _minTrajectory = -2.5f;

    private float _maxTrajectory = 2.5f;

    private float _pause = 0.25f;

    private Rigidbody2D _klay;

    private bool _first = true;

    private Vector2 _velocity;

    public bool jump = false;

    GameManager _gm;

    PlatformManager _pm;

    void Awake()
    {
        _gm = FindObjectOfType<GameManager>();
        _pm = FindObjectOfType<PlatformManager>();
        _klay = GetComponent<Rigidbody2D>();
        _velocity = _klay.velocity;
    }

    void FixedUpdate()
    {
        float angle = Mathf.Clamp(_klay.velocity.y * _rotationMultiplier, _minAngle, _maxAngle);
        _klay.MoveRotation(angle);
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    void Jump(){   
        float x_axis;

        //The first jump is always straight up, including after a power trip
        if(_first){ 
            x_axis = 0f;
            _first = false;
        }else{ 
            x_axis = Random.Range(_minTrajectory, _maxTrajectory);
        }

        if(!jump){
            _velocity.y = _forceUp;
            _velocity.x = x_axis;

            _klay.velocity = _velocity;
            jump = true;
        }else{
            //StartCoroutine(DropTheBeat());

            _velocity.y = _forceDown;
            _velocity.x = 0f;

            _klay.velocity = _velocity;
            jump = false;
        }
    }

    //Slight pause in the air before Klay slams down
    IEnumerator DropTheBeat(){
        _klay.simulated = false;
        yield return new WaitForSeconds(_pause);
        _klay.simulated = true;
    }

    public void PowerTrip(){
        _first = true;
    }

    void OnBecameInvisible(){
        _gm.StopGame();
    }
}
