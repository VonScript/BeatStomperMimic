using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    private Vector3 pos;

    void Awake(){
        pos = transform.position;
    }

    public void MoveUp(){
        transform.Translate(0, 4.75f, 0);
    }

    public void Reset(){
        pos.y = 0;
        pos.z = -10f;
        transform.position = pos;
    }
}
