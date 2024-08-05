using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : ChessPiece
{
    public override List<Vector2Int> GetAvailableMoves()
    {
        //all valid moves for the king
        List<Vector2Int> availableMoves = new List<Vector2Int>();

        int[][] kingMoves = new int[][] {
            new int[] { -1, 1  }, new int[] { 0, 1  }, new int[] { 1, 1  },
            new int[] { -1, 0  },                      new int[] { 1, 0  },
            new int[] { -1, -1 }, new int[] { 0, -1 }, new int[] { 1, -1 }
        };

        foreach (var move in kingMoves)
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
