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
        for(int j=1; currentY+j<8; j++){
            Vector2Int upwardTile = new Vector2Int(currentX, currentY+j);
            if (Chessboard.Instance.IsOccupied(upwardTile))
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
        for(int j=1; currentY-j>=0 ;j++){
            Vector2Int downwardTile = new Vector2Int(currentX, currentY-j);
            if (Chessboard.Instance.IsOccupied(downwardTile))
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
        for(int i=1; currentX+i<8 ;i++){
            Vector2Int forwardTile = new Vector2Int(currentX+i, currentY);
            if (Chessboard.Instance.IsOccupied(forwardTile))
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
        for(int i=1; currentX-i>=0 ;i++){
            Vector2Int backwardTile = new Vector2Int(currentX-i, currentY);
            if (Chessboard.Instance.IsOccupied(backwardTile))
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

    protected override bool IsValidMove(Vector2Int newPosition)
    {
        if(!Chessboard.Instance.IsOccupiedByOpponent(newPosition, pieceColor)){
            return false;
        }

        return true;
    }
}
