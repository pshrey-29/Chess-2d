using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rook : ChessPiece
{
    public override List<Vector2Int> GetAvailableMoves()
    {
        //all valid moves for the rook
        List<Vector2Int> availableMoves = new List<Vector2Int>();

        //vertical line moves
        for(int j=1; currentPosition.y+j<8; j++){
            Vector2Int upwardTile = new Vector2Int(currentPosition.x, currentPosition.y+j);
            if (chessboard.IsOccupied(upwardTile))
            {
                if(IsValidMove(upwardTile)){
                    availableMoves.Add(upwardTile);
                }
                break; //can't jump a piece
            }
            else
            {
                availableMoves.Add(upwardTile);
            }
        }
        for(int j=1; currentPosition.y-j>=0 ;j++){
            Vector2Int downwardTile = new Vector2Int(currentPosition.x, currentPosition.y-j);
            if (chessboard.IsOccupied(downwardTile))
            {
                if(IsValidMove(downwardTile)){
                    availableMoves.Add(downwardTile);
                }
                break; //can't jump a piece
            }
            else
            {
                availableMoves.Add(downwardTile);
            }
        }
        
        //horizontal dir moves
        for(int i=1; currentPosition.x+i<8 ;i++){
            Vector2Int forwardTile = new Vector2Int(currentPosition.x+i, currentPosition.y);
            if (chessboard.IsOccupied(forwardTile))
            {
                if(IsValidMove(forwardTile)){
                    availableMoves.Add(forwardTile);
                }
                break; //can't jump a piece
            }
            else
            {
                availableMoves.Add(forwardTile);
            }
        }
        for(int i=1; currentPosition.x-i>=0 ;i++){
            Vector2Int backwardTile = new Vector2Int(currentPosition.x-i, currentPosition.y);
            if (chessboard.IsOccupied(backwardTile))
            {
                if(IsValidMove(backwardTile)){
                    availableMoves.Add(backwardTile);
                }
                break; //can't jump a piece
            }
            else
            {
                availableMoves.Add(backwardTile);
            }
        }

        return availableMoves;
    }
}
