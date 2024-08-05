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
        for (int i=1; currentPosition.x+i<8 && currentPosition.y+i<8; i++)
        {
            Vector2Int diagonalTile = new Vector2Int(currentPosition.x+i, currentPosition.y+i);
            if (chessboard.IsOccupied(diagonalTile))
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
        for (int i=1; currentPosition.x-i>=0 && currentPosition.y+i<8; i++)
        {
            Vector2Int diagonalTile = new Vector2Int(currentPosition.x-i, currentPosition.y+i);
            if (chessboard.IsOccupied(diagonalTile))
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
        for (int i=1; currentPosition.x+i<8 && currentPosition.y-i>=0; i++)
        {
            Vector2Int diagonalTile = new Vector2Int(currentPosition.x+i, currentPosition.y-i);
            if (chessboard.IsOccupied(diagonalTile))
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
        for (int i=1; currentPosition.x-i>=0 && currentPosition.y-i>=0; i++)
        {
            Vector2Int diagonalTile = new Vector2Int(currentPosition.x-i, currentPosition.y-i);
            if (chessboard.IsOccupied(diagonalTile))
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
}