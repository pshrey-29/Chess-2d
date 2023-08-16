using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ChessPiece : MonoBehaviour
{
    public enum PieceColor { White, Black }

    public PieceColor pieceColor;

    public int currentX;
    public int currentY;

    private bool isSelected = false;
    private bool isMoving = false;
    private Chessboard chessboard;

    private void Start()
    {
        chessboard = Chessboard.Instance;
        chessboard.RegisterChessPiece(this);
    }

    public abstract List<Vector2Int> GetAvailableMoves();

    protected abstract bool IsValidMove(Vector2Int newPosition);

    public virtual void MoveToPosition(Vector2Int newPosition)
    {
        if (chessboard == null)
            return;

        //change this check to "is this new position from available moves"
        if (IsValidMove(newPosition))
        {
            // Clear the current position in the chessboard
            chessboard.SetPiece(new Vector2Int(currentX, currentY), null);

            // Update the current position of the chess piece
            currentX = newPosition.x;
            currentY = newPosition.y;

            // Set the new position in the chessboard
            chessboard.SetPiece(newPosition, this);
            //if its capture move, remove that piece from allchesspieces list

            // Move the GameObject to the new position visually
            transform.position = chessboard.GetTile(newPosition).transform.position;
        }
    }

    public void HandleSelection()
    {
        if (isSelected)
        {
            Deselect();
        }
        else
        {
            DeselectAllOtherPieces();
            Select();
        }
    }

    private void DeselectAllOtherPieces()
    {
        foreach (ChessPiece otherPiece in chessboard.GetAllChessPieces())
        {
            if (otherPiece != this && otherPiece.isSelected)
            {
                otherPiece.Deselect();
            }
        }
    }

    private void Select()
    {
        isSelected = true;
        List<Vector2Int> availableMoves = GetAvailableMoves();
        chessboard.HighlightAvailableMoves(availableMoves);
    }

    private void Deselect()
    {
        isSelected = false;
        chessboard.ClearAllHighlights();
    }

    protected void OnMouseDown()
    {
        HandleSelection();
    }

    private void OnMouseEnter()
    {
        Tile tile = chessboard.GetTile(new Vector2Int(currentX, currentY));
        if (tile != null)
        {
            tile.SetMouseOverPiece(true);
        }
    }

    private void OnMouseExit()
    {
        Tile tile = chessboard.GetTile(new Vector2Int(currentX, currentY));
        if (tile != null)
        {
            tile.SetMouseOverPiece(false);
        }
    }

    //getters
    public bool IsSelected()
    {
        return isSelected;
    }

    public bool IsMoving()
    {
        return isMoving;
    }

    private void OnDestroy()
    {
        chessboard.UnregisterChessPiece(this);
    }
}
