using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtifactSpawn : MonoBehaviour
{
    public GameObject cubePrefab;

    public GameObject oblongPrefab;

    public GameObject textPrefab;

    private OverlayColours _oc;

    private GameManager _gm;

    private BoxCollider2D _spawner;

    private Bounds _bounds;

    void Awake(){
        _gm = FindObjectOfType<GameManager>();
        _oc = FindObjectOfType<OverlayColours>();
        _spawner = GetComponent<BoxCollider2D>();
        _bounds = _spawner.bounds;
    }

    public void SpawnArtifact(){
        if(_gm.state == GameState.GameScreen){
            switch(_oc.level){
                case 1: StartCoroutine(Switchback());
                break;

                case 2: StartCoroutine(Cube());
                break;

                case 3: StartCoroutine(Lines());
                break;

                default:
                break;
            }
        }
    }

    IEnumerator Switchback(){
        while(_gm.state == GameState.GameScreen && _oc.level == 1){
            Vector3 pos = transform.position;
            pos.x = Random.Range(-_bounds.extents.x, _bounds.extents.x);
            pos.z = 10f;

            Instantiate(textPrefab, pos, Quaternion.Euler(0, 0, 0));
            yield return new WaitForSeconds(1f);
        }
    }

    IEnumerator Cube(){
        while(_gm.state == GameState.GameScreen && _oc.level == 2){
            Vector3 pos = transform.position;
            pos.x = Random.Range(-_bounds.extents.x, _bounds.extents.x);
            pos.z = 10f;

            int x = Random.Range(-45, 45);
            int y = Random.Range(-45, 45);
            int z = Random.Range(-45, 45);

            Instantiate(cubePrefab, pos, Quaternion.Euler(x, y, z));
            yield return new WaitForSeconds(1f);
        }
    }

    IEnumerator Lines(){
        while(_gm.state == GameState.GameScreen && _oc.level == 3){
            Vector3 pos = transform.position;
            pos.x = Random.Range(-_bounds.extents.x, _bounds.extents.x);
            pos.z = 10f;

            Instantiate(oblongPrefab, pos, Quaternion.identity); 
            yield return new WaitForSeconds(1f);
        }
    }
}
