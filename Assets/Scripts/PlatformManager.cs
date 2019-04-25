using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public GameObject platformPrefab = null;

    public GameObject klayPrefab = null;

    //public GameObject powerCubePrefab = null;

    private GameObject _klay;

    private JumpControl _jc;

    private GameManager _gm;

    Rigidbody2D _objRB = null;

    int _platformNum = 0;

    float yAxis = 0.9f;

    void Awake(){
        _gm = FindObjectOfType<GameManager>();
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
                LastFirstborn();
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

    void LastFirstborn(){
        Vector2 pos = transform.position;
        pos.y = -3f;

        _klay = Instantiate(klayPrefab, pos, Quaternion.identity);
        _jc = _klay.GetComponent<JumpControl>();
    }

    public void SpawnPlatform(){
        Vector2 pos = transform.position;
        pos.y = yAxis;
        yAxis += 4.75f;

        GameObject obj = Instantiate(platformPrefab, pos, Quaternion.identity);
        obj.name = _platformNum.ToString();

        if((_platformNum % 10) == 0){
            Vector2 pos = transform.position;
            pos.x = Random.Range(-1.2f, 1.2f);
            //Instantiate(powerCubePrefab, pos, Quaternion.identity);

        }

        _objRB = obj.GetComponent<Rigidbody2D>();
        _platformNum++;
    }

    public void Clear(){
        GameObject[] platforms = GameObject.FindGameObjectsWithTag("Platform");
        foreach (GameObject p in platforms) Destroy(p); 
        _platformNum = 0;
        yAxis = 0.9f;

        Destroy(_klay);
    }

    public void Breakout(){
        Debug.Log("This is my birthright!");
        _jc.PowerTrip();
    }
}
