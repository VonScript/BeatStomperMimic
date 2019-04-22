using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverlayColours : MonoBehaviour
{
    public UnityEngine.UI.RawImage img;

    private Texture2D _backgroundTexture ;

    private GameManager _gm;

    public int level = 0;


    private Color _black = new Color(0, 0, 0, 0.5f);
    private Color _blue = new Color(0, 0, 1, 0.5f);
    private Color _bronze = new Color(1, 0.4f, 0.05f, 0.5f);
    private Color _red = new Color(1, 0, 0, 0.5f);
    private Color _green = new Color(0, 0.5f, 0, 0.5f);
    private Color _grey = new Color(0.5f, 0.5f, 0.5f, 0.5f);
    private Color _gold = new Color(1, 0.9f, 0.1f, 0.5f);
    private Color _purple = new Color(0.25f, 0, 1, 0.5f);
    private Color _white = new Color(1, 1, 1, 0.5f);

    void Awake()
    {
        level = Random.Range(1, 3);
        _gm = FindObjectOfType<GameManager>();

        _backgroundTexture  = new Texture2D(1, 3);
        _backgroundTexture.wrapMode = TextureWrapMode.Clamp;
        _backgroundTexture.filterMode = FilterMode.Bilinear;

        switch(level){
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

    void SetColor( Color color1, Color color2, Color color3 )
    {
        _backgroundTexture.SetPixels( new Color[] { color1, color2, color3 } );
        _backgroundTexture.Apply();
        img.texture = _backgroundTexture;

        _gm.level = level;
    }

    public void LevelOne(){
        SetColor(_purple, _red, _grey);
        level = 1;
    }

    public void LevelTwo(){
        SetColor(_green, _blue, _white);
        level = 2;
    }

    public void LevelThree(){
        SetColor(_black, _bronze, _gold);
        level = 3;
    }
}
