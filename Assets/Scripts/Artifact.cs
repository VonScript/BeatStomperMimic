using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Artifact : MonoBehaviour
{
    private Rigidbody _rb;
    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Start(){
        _rb.velocity = transform.TransformDirection(Vector2.up) * 2.5f;
        //_rb.AddForce(transform.forward * Time.deltaTime);
    }

    void OnBecameInvisible(){
        Destroy(gameObject);
    }
}
