using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : ChessPiece
{
    public override List<Vector2Int> GetAvailableMoves()
    {
        //all valid moves for the pawn
        List<Vector2Int> availableMoves = new List<Vector2Int>();

        //IMP:: move direction depends upon player- not implemented yet
        Vector2Int forwardTile = new Vector2Int(currentX, currentY + 1);
        if (!Chessboard.Instance.IsOccupied(forwardTile))
        {
            availableMoves.Add(forwardTile); //can't capture forward tile
        }

        //capture moves in diagonal directions
        Vector2Int captureLeft = new Vector2Int(currentX - 1, currentY + 1);
        if (Chessboard.Instance.IsOccupiedByOpponent(captureLeft, pieceColor))
        {
            availableMoves.Add(captureLeft);
        }

        Vector2Int captureRight = new Vector2Int(currentX + 1, currentY + 1);
        if (Chessboard.Instance.IsOccupiedByOpponent(captureRight, pieceColor))
        {
            availableMoves.Add(captureRight);
        }

        return availableMoves;
    }

    protected override bool IsValidMove(Vector2Int newPosition)
    {

        return true;
    }
}
