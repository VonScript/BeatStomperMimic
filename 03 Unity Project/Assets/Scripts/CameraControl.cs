using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    private Vector3 _pos;

    private Vector3 _startPos;

    private Vector3 _target;

    private float _up = 4.75f;


    private void Awake(){
        _startPos = transform.position;
        _pos = _startPos;
        _target = _startPos;
    }

    private IEnumerator Offworld(){
        bool move = true;

        if(_target.y != (_pos.y + _up)) _target.y = _pos.y + _up;

        while (move){
            transform.position = Vector3.MoveTowards(transform.position, _target, 0.5f);
            _pos = transform.position;

            if(_pos.y == _target.y){
                move = false;
                yield return null;
            }

            yield return new WaitForSeconds(0.015f);
        }

    }

    public void MoveUp(){
        _target.y += _up;
        StartCoroutine(Offworld());
    }

    public void Reset(){
        _pos = _startPos;
        _target = _startPos;
        transform.position = _startPos;
    }
}
