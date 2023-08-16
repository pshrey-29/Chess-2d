using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bishop : ChessPiece
{
    public override List<Vector2Int> GetAvailableMoves()
    {
        // all valid moves for the bishop
        List<Vector2Int> availableMoves = new List<Vector2Int>();

        //top right
        for (int i=1; currentX+i<8 && currentY+i<8; i++)
        {
            Vector2Int diagonalTile = new Vector2Int(currentX+i, currentY+i);
            if (Chessboard.Instance.IsOccupied(diagonalTile))
            {
                if (IsValidMove(diagonalTile))
                {
                    availableMoves.Add(diagonalTile);
                }
                break;
            }
            else
            {
                availableMoves.Add(diagonalTile);
            }
        }

        //top left
        for (int i=1; currentX-i>=0 && currentY+i<8; i++)
        {
            Vector2Int diagonalTile = new Vector2Int(currentX-i, currentY+i);
            if (Chessboard.Instance.IsOccupied(diagonalTile))
            {
                if (IsValidMove(diagonalTile))
                {
                    availableMoves.Add(diagonalTile);
                }
                break;
            }
            else
            {
                availableMoves.Add(diagonalTile);
            }
        }

        //bottom right
        for (int i=1; currentX+i<8 && currentY-i>=0; i++)
        {
            Vector2Int diagonalTile = new Vector2Int(currentX+i, currentY-i);
            if (Chessboard.Instance.IsOccupied(diagonalTile))
            {
                if (IsValidMove(diagonalTile))
                {
                    availableMoves.Add(diagonalTile);
                }
                break;
            }
            else
            {
                availableMoves.Add(diagonalTile);
            }
        }

        //bottom left
        for (int i=1; currentX-i>=0 && currentY-i>=0; i++)
        {
            Vector2Int diagonalTile = new Vector2Int(currentX-i, currentY-i);
            if (Chessboard.Instance.IsOccupied(diagonalTile))
            {
                if (IsValidMove(diagonalTile))
                {
                    availableMoves.Add(diagonalTile);
                }
                break;
            }
            else
            {
                availableMoves.Add(diagonalTile);
            }
        }

        return availableMoves;
    }

    protected override bool IsValidMove(Vector2Int newPosition)
    {
        if(!Chessboard.Instance.IsOccupiedByOpponent(newPosition, pieceColor)){
            return false;
        }

        return true;
    }
}