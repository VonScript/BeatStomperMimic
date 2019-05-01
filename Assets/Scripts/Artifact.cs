using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artifact : MonoBehaviour
{
    private Rigidbody _rb;

    private void Awake(){
        _rb = GetComponent<Rigidbody>();
    }

    private void OnBecameInvisible(){
        Destroy(gameObject);
    }

    private void Start(){
        _rb.velocity = transform.TransformDirection(Vector2.up) * 2.5f;
    }
}
