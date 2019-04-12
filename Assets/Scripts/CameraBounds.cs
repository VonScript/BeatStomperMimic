using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraBounds : MonoBehaviour
{
    public static Vector2 bottomLeft, topRight;

    private void Awake()
    {
        Camera cam = GetComponent<Camera>();

        bottomLeft = cam.ViewportToWorldPoint(Vector3.zero);
        topRight = cam.ViewportToWorldPoint(Vector3.one);
    }
}
