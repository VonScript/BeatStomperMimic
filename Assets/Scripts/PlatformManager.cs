using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public GameObject platformPrefab = null;

    public GameObject klay = null;

    private JumpControl _jc;

    private GameManager _gm;

    Rigidbody2D _objRB = null;

    int _platformNum = 0;

    float yAxis = 0.9f;

    void Awake(){
        _gm = FindObjectOfType<GameManager>();
        _jc = klay.GetComponent<JumpControl>();
    }

    void Update(){
        if(Input.GetButtonDown("Jump")){
            if(_gm.state == GameState.GameScreen){
                    if(!_jc.jump){
                        _objRB.simulated = false;
                    }else{
                        _objRB.simulated = true;
                    }
            }else if(_gm.state == GameState.TitleScreen){
                _gm.StartGame();
                FirstPlatform();
                SpawnPlatform();

                //Realigning Klay
                Vector3 pos = klay.transform.position;
                pos.x = 0;
                pos.y = -3;
                pos.z = 0;
                klay.transform.position = pos;
            }
        }
    }

    void FirstPlatform(){
        Vector2 pos = transform.position;
        pos.y = -4f;

        GameObject obj = Instantiate(platformPrefab, pos, Quaternion.identity);
        obj.name = _platformNum.ToString();

        _objRB = obj.GetComponent<Rigidbody2D>();
        _platformNum++;
    }

    public void SpawnPlatform(){
        Vector2 pos = transform.position;
        pos.y = yAxis;
        yAxis += 4.75f;

        GameObject obj = Instantiate(platformPrefab, pos, Quaternion.identity);
        obj.name = _platformNum.ToString();

        _objRB = obj.GetComponent<Rigidbody2D>();
        _platformNum++;
    }

    public void Clear(){
        GameObject[] platforms = GameObject.FindGameObjectsWithTag("Platform");
        foreach (GameObject p in platforms) Destroy(p); 
        _platformNum = 0;
        yAxis = 0.9f;
    }
}
