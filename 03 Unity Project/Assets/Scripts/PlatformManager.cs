using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public GameObject platformPrefab = null;

    public GameObject klayPrefab = null;

    public GameObject powerUpPrefab = null;

    public GameObject up;


    public int platformNum = 0;


    private Bounds _bounds;

    private GameManager _gm;

    private JumpControl _jc;

    private float _scale = 0;


    private GameObject _klay;

    private Rigidbody2D _objRB = null;


    private float _yAxis = 0.9f;


    private void Awake(){
        _gm = FindObjectOfType<GameManager>();
    }

    private void FirstPlatform(){
        Vector2 pos = transform.position;
        pos.y = -4f;

        GameObject obj = Instantiate(platformPrefab, pos, Quaternion.identity);
        obj.name = platformNum.ToString();

        _objRB = obj.GetComponent<Rigidbody2D>();
        platformNum++;
    }

    private void LastFirstborn(){
        Vector2 pos = transform.position;
        pos.y = -3f;

        _klay = Instantiate(klayPrefab, pos, Quaternion.identity);
        _jc = _klay.GetComponent<JumpControl>();
    }

    private void Update(){
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
                LastFirstborn();
            }
        }
    }

    public void Clear(){
        GameObject[] platforms = GameObject.FindGameObjectsWithTag("Platform");
        foreach (GameObject p in platforms) Destroy(p); 
        platformNum = 0;
        _yAxis = 0.9f;
        _scale = 0;
    }

    public void SpawnPlatform(){
        Vector2 pos = transform.position;
        pos.y = _yAxis;
        _yAxis += 4.75f;

        GameObject obj = Instantiate(platformPrefab, pos, Quaternion.identity);

        if(_scale <= 1.5f){
            Component[] boxes = obj.GetComponentsInChildren<BoxCollider2D>();
            foreach(BoxCollider2D box in boxes) box.transform.localScale -= new Vector3(_scale, 0, 0);
            _scale =+ 0.005f;
        }

        _bounds = obj.GetComponentInChildren<BoxCollider2D>().bounds;
        float newBounds = _bounds.extents.x - 0.5f;

        if((platformNum % 10) == 0){
            pos.x = Random.Range(-newBounds, newBounds);
            up = Instantiate(powerUpPrefab, pos, Quaternion.identity);
            up.name = "Breakout";
            up.transform.SetParent(obj.transform);
        }

        obj.name = platformNum.ToString();

        _objRB = obj.GetComponent<Rigidbody2D>();
        platformNum++;
    }
}
