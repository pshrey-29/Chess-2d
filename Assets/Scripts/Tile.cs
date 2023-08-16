using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private Color darkColor, lightColor;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private GameObject highlight;
    [SerializeField] private GameObject highlightAvailable;

    private bool isMouseOverTile = false;
    private bool isMouseOverPiece = false;

    public void FillColor(bool offset){
        spriteRenderer.color = offset ? darkColor : lightColor;
    }

    public void HighlighTileAvailableMove(){
        highlightAvailable.SetActive(true);
    }

    public void ClearHighlight()
    {
        highlightAvailable.SetActive(false);
    }

    void Update()
    {
        // Handle highlighting based on both tile and piece mouse over
        highlight.SetActive(isMouseOverTile || isMouseOverPiece);
    }

    void OnMouseEnter(){
        SetMouseOverTile(true);
    }

    void OnMouseExit(){
        SetMouseOverTile(false);
    }

     public void SetMouseOverTile(bool value)
    {
        isMouseOverTile = value;
    }

    public void SetMouseOverPiece(bool value)
    {
        isMouseOverPiece = value;
    }

}
