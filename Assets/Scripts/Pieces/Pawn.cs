using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : ChessPiece
{
    public override List<Vector2Int> GetAvailableMoves()
    {
        //all valid moves for the pawn
        List<Vector2Int> availableMoves = new List<Vector2Int>();

        int dir = this.pieceColor == PieceColor.White ? 1 : -1;

        Vector2Int forwardTile = new Vector2Int(currentPosition.x, currentPosition.y + dir);
        if (!chessboard.IsOccupied(forwardTile))
        {
            availableMoves.Add(forwardTile); //can't capture forward tile
        }

        if (currentPosition.y == 1 || currentPosition.y == 6)
        {
            Vector2Int forwardTwoTile = new Vector2Int(currentPosition.x, currentPosition.y + dir * 2);
            if (!chessboard.IsOccupied(forwardTwoTile) && !chessboard.IsOccupied(forwardTile))
            {
                availableMoves.Add(forwardTwoTile); //can't capture forward tile
            }
        }

        //capture moves in diagonal directions
        Vector2Int captureLeft = new Vector2Int(currentPosition.x - 1, currentPosition.y + dir);
        if (chessboard.IsOccupiedByOpponent(captureLeft, pieceColor))
        {
            availableMoves.Add(captureLeft);
        }

        Vector2Int captureRight = new Vector2Int(currentPosition.x + 1, currentPosition.y + dir);
        if (chessboard.IsOccupiedByOpponent(captureRight, pieceColor))
        {
            availableMoves.Add(captureRight);
        }

        return availableMoves;
    }
}
