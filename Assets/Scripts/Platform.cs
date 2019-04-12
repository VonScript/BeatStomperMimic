using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Platform : MonoBehaviour
{
    //Reference for the platform
    private Rigidbody2D _platform;

    //Boolean whether the rigidbody's physics have been turned on or off for Cubie to pass through
    private bool _seethrough;

    public void Awake(){
        _platform = GetComponent<Rigidbody2D>();
        _platform.simulated = true;
        _seethrough = true;
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Incoming();
        }
    }

    private void Incoming(){
        if(_seethrough == true){
            _platform.simulated = false;
            _seethrough = false;
        }else{
            _platform.simulated = true;
            _seethrough = true;
        }
    }
}
