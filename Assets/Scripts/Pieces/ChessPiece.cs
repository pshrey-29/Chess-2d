using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Chess.Environment;

public abstract class ChessPiece : MonoBehaviour
{
    public enum PieceColor { White, Black }

    [SerializeField] private PieceColor m_pieceColor;
    public PieceColor pieceColor{get{return m_pieceColor;}}

    public Vector2Int currentPosition;

    private bool isSelected = false;
    private bool isMoving = false;
    protected Chessboard chessboard;

    private void Start()
    {
        chessboard = Chessboard.Instance;
        chessboard.RegisterChessPiece(this);
    }

    public abstract List<Vector2Int> GetAvailableMoves();

    public virtual void MoveToPosition(Vector2Int newPosition)
    {
        if (chessboard == null)
            return;

        

        //change this check to "is this new position from available moves"
        if (IsValidMove(newPosition))
        {
            // Clear the current position in the chessboard
            chessboard.SetPiece(currentPosition, null);

            // Update the current position of the chess piece
            currentPosition = newPosition;

            // Set the new position in the chessboard
            chessboard.SetPiece(newPosition, this);
            //if its capture move, remove that piece from allchesspieces list


            // Move the GameObject to the new position visually
            transform.position = chessboard.GetTile(newPosition).transform.position;
        }
    }

    protected bool IsValidMove(Vector2Int newPosition)
    {
        //tile exist on chessboard
        if (!Chessboard.Instance.IsValidPosition(newPosition))
        {
            return false;
        }

        if(Chessboard.Instance.IsOccupied(newPosition))
        {
            if (Chessboard.Instance.IsOccupiedByOpponent(newPosition, pieceColor))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        return true;
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
