using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public Platform platformPrefab;

    private float _min;

    private float _max;

    private Trigger _trigger;

    private void Awake(){
        _min = CameraBounds.bottomLeft.x;
        _max = CameraBounds.topRight.x;
    }


    public void StartGame()
    {
        Vector3 pos = transform.position;
        pos.y = -3.78f;
        Instantiate<Platform>(platformPrefab, pos, Quaternion.identity);

        OneHop();
    }

    private void Update(){
        //if platform has changed
        OneHop();
    }

    private void OneHop()
    {
        while (GameManager.state == GameState.Game)
        {
            while(!_trigger.oops){

                Vector3 pos = transform.position;

                pos.y = 1.264f;
                pos.x = Random.Range(_min, _max);

                Instantiate<Platform>(platformPrefab, pos, Quaternion.identity);
            }
        }
    }
}
