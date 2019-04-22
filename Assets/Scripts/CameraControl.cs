using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    private Vector2 pos;

    void Awake(){
        pos = transform.position;
    }

    public void MoveUp(){
        transform.Translate(0, 4.75f, 0);
    }

    public void Reset(){
        pos.y = 0;
        transform.position = pos;
    }
}
