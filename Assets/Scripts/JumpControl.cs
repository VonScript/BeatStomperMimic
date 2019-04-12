using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(CapsuleCollider2D))]
public class JumpControl : MonoBehaviour
{
    [Tooltip("The upwards force by which the player will be pushed.")]
    public float forceUp = 10f;

    [Tooltip("The downwards force by which the player will drop.")]
    public float forceDown = -20f;

    [Tooltip("The rotation multiplier, to make turning more accurate.")]
    public float rotationMultiplier = 5f;

    [Tooltip("The minimum angle for the square to turn.")]
    public float minAngle = -90f;

    [Tooltip("The maximum angle for the square to turn.")]
    public float maxAngle = 45f;

    [Tooltip("The minimum range for the square's trajectory upwards.")]
    public float minTrajectory = -10f;

    [Tooltip("The maximum range for the square's trajectory upwards.")]
    public float maxTrajectory = 10f;

    [Tooltip("The duration of the pause before the square drops.")]
    public float pause = 0.05f;

    //I decided to name the square with a face Cubie
    private Rigidbody2D _cubie;

    //Flag for jump and land button
    private GameManager _gm;

    //Flag for first jump of the level, and after power up
    private bool _first = true;

    private Vector2 _velocity;

    private void Awake()
    {
        _cubie = GetComponent<Rigidbody2D>();
        _velocity = _cubie.velocity;
    }

    private void FixedUpdate()
    {
        float angle = Mathf.Clamp(_cubie.velocity.y * rotationMultiplier, minAngle, maxAngle);
        _cubie.MoveRotation(angle);
    }

    private void onCollisionEnter2D(Collider2D collider){
        _gm.jumpState = false;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    // Causes the player to "jump".
    private void Jump(){   
        float x_axis;

        //The first jump is always straight up, including after a power trip
        if(_first){ 
            x_axis = 0f;
            _first = false;
        }else{ 
            x_axis = Random.Range(minTrajectory, maxTrajectory);
        }

        if(!_gm.jumpState){
            _velocity.y = forceUp;
            _velocity.x = x_axis;

            _cubie.velocity = _velocity;

            _gm.jumpState = true;
        }else{
            StartCoroutine(DropTheBeat());

            _velocity.y = forceDown;
            _velocity.x = 0f;

            _cubie.velocity = _velocity;
            _gm.jumpState = false;
        }
    }

    //Slight pause in the air before Cubie slams down
    private IEnumerator DropTheBeat(){
            _cubie.simulated = false;
            yield return new WaitForSeconds(pause);
            _cubie.simulated = true;
    }

    private void PowerTrip(){

    }
}