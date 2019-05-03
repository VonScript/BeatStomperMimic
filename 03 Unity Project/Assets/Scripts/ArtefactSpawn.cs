using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtefactSpawn : MonoBehaviour
{
    public GameObject cubePrefab;

    public GameObject oblongPrefab;

    public GameObject textPrefab;


    private Bounds _bounds;

    private GameManager _gm;

    private BoxCollider2D _spawner;

    
    private void Awake(){
        _gm = FindObjectOfType<GameManager>();

        _spawner = GetComponent<BoxCollider2D>();
        _bounds = _spawner.bounds;
    }

    private IEnumerator ArtefactSelect(GameObject prefab, int level){
        while(_gm.state == GameState.GameScreen && _gm.level == level){
            Vector3 pos = transform.position;
            pos.x = Random.Range(-_bounds.extents.x, _bounds.extents.x);
            pos.z = 10f;

            if(level == 2){
                int x = Random.Range(-45, 45);
                int y = Random.Range(-45, 45);
                int z = Random.Range(-45, 45);

                Instantiate(prefab, pos, Quaternion.Euler(x, y, z));        
            }else{
                Instantiate(prefab, pos, Quaternion.identity);
            }
            yield return new WaitForSeconds(1f);
        }
    }

    public void Clear(){
        GameObject[] artefact = GameObject.FindGameObjectsWithTag("Artefact");
        foreach (GameObject a in artefact) Destroy(a); 
    }

    public void SpawnArtefact(){
        if(_gm.state == GameState.GameScreen){
            switch(_gm.level){
                case 1: StartCoroutine(ArtefactSelect(textPrefab, 1));
                break;

                case 2: StartCoroutine(ArtefactSelect(cubePrefab, 2));
                break;

                case 3: StartCoroutine(ArtefactSelect(oblongPrefab, 3));
                break;

                default:
                break;
            }
        }
    }
}
