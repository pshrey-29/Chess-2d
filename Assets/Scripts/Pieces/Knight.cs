using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : ChessPiece
{
    public override List<Vector2Int> GetAvailableMoves()
    {
        //all valid moves for the knight
        List<Vector2Int> availableMoves = new List<Vector2Int>();

        int[][] knightMoves = new int[][] {
            new int[] { 1, 2 },
            new int[] { 2, 1 },
            new int[] { 2, -1 },
            new int[] { 1, -2 },
            new int[] { -1, -2 },
            new int[] { -2, -1 },
            new int[] { -2, 1 },
            new int[] { -1, 2 }
        };

        foreach (var move in knightMoves)
        {
            int newX = currentPosition.x + move[0];
            int newY = currentPosition.y + move[1];
            Vector2Int newTile = new Vector2Int(newX, newY);

            if (IsValidMove(newTile))
            {
                availableMoves.Add(newTile);    
            }
        }

        return availableMoves;
    }
}
