using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OverlayColours : MonoBehaviour
{
    public UnityEngine.UI.RawImage img;

    public GameObject twenty = null;

    public TextMeshProUGUI songTitle = null;

    public int level = 0;


    private Texture2D _backgroundTexture ;

    private Material _material;

    private GameManager _gm;


    //Colours
    private Color _black = new Color(0, 0, 0, 0.5f);

    private Color _blue = new Color(0, 0, 0.25f, 0.5f);

    private Color _bronze = new Color(1, 0.4f, 0.05f, 0.5f);

    private Color _red = new Color(1, 0, 0, 0.5f);

    private Color _cyan = new Color(0.1f, 1, 0.9f, 0.5f);

    private Color _grey = new Color(0.5f, 0.5f, 0.5f, 0.5f);

    private Color _gold = new Color(1, 0.9f, 0.1f, 0.5f);

    private Color _purple = new Color(0.25f, 0, 0.1f, 0.5f);

    private Color _white = new Color(1, 1, 1, 0.5f);

    
    private void Awake()
    {
        twenty.SetActive(false);

        level = Random.Range(1, 3);
        _gm = FindObjectOfType<GameManager>();

        _material = GetComponent<Material>();

        _backgroundTexture  = new Texture2D(1, 3);
        _backgroundTexture.wrapMode = TextureWrapMode.Clamp;
        _backgroundTexture.filterMode = FilterMode.Bilinear;

        SetLevel(level);
    }

    private void SetColor(Color color1, Color color2, Color color3){
        _backgroundTexture.SetPixels( new Color[] { color1, color2, color3 } );
        _backgroundTexture.Apply();
        
        img.texture = _backgroundTexture;
    }

    private void SetLevel(int lvl){
        switch(lvl){
            case 1: LevelOne();
            break;

            case 2: LevelTwo();
            break;

            case 3: LevelThree();
            break;

            default: SetColor(_black, _grey, _white);
            break;
        }
    }

    private IEnumerator GiftForYou(){
        img.material.SetFloat("_Threshold", 1);
        twenty.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        twenty.SetActive(false);
        img.material.SetFloat("_Threshold", 0);
    }

    public void InvertColours(){
        StartCoroutine(GiftForYou());
    }

    public void LevelOne(){
        SetColor(_red, _grey, _purple);
        level = 1;
        _gm.level = level;

        songTitle.SetText("Switchback (Drop Remix)");
    }

    public void LevelTwo(){
        SetColor(_white, _cyan, _blue);
        level = 2;
        _gm.level = level;

        songTitle.SetText("The Chosen One");
    }

    public void LevelThree(){
        SetColor(_black, _bronze, _gold);
        level = 3;
        _gm.level = level;

        songTitle.SetText("The Best It's Gonna Get (Instrumental)");
    }

    public void RandomLevel(){
        level = Random.Range(1, 3);
        SetLevel(level);
    }
}
