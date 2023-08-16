using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public enum GameState
    {
        WaitingForInput,
        PieceSelected,
        PieceMoving,
        GameOver
    }

    private Chessboard chessboard;
    private ChessPiece selectedPiece;
    private List<Vector2Int> availableMoves;

    private GameState currentState = GameState.WaitingForInput;
    private ChessPiece.PieceColor currentPlayer = ChessPiece.PieceColor.White;

    private void Start()
    {
        chessboard = Chessboard.Instance;
    }

    public void UpdateState()
    {
        switch (currentState)
        {
            case GameState.WaitingForInput:
                HandleWaitingForInput();
                break;

            case GameState.PieceSelected:
                HandlePieceSelected();
                break;

            case GameState.PieceMoving:
                HandlePieceMoving();
                break;

            case GameState.GameOver:
                break;
        }
    }

    private void HandleWaitingForInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2Int selectedTile = GetTileAtMousePosition();
            ChessPiece piece = chessboard.GetPiece(selectedTile);
            Debug.Log(selectedTile);
            if (piece != null && piece.pieceColor == currentPlayer)
            {
                selectedPiece = piece;
                selectedPiece.HandleSelection();
                currentState = GameState.PieceSelected;
            }
        }
    }

    private void HandlePieceSelected()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2Int targetTile = GetTileAtMousePosition();

            if (availableMoves.Contains(targetTile))
            {
                selectedPiece.MoveToPosition(targetTile);
                currentState = GameState.PieceMoving;
            }
            else
            {
                selectedPiece.HandleSelection();
                currentState = GameState.WaitingForInput;
            }

            Debug.Log("handle piece selected");
        }
    }

    private void HandlePieceMoving()
    {
        if (!selectedPiece.IsMoving())
        {
            Chessboard.Instance.ClearAllHighlights();
            currentState = GameState.WaitingForInput;

            //change player turn
            currentPlayer = (currentPlayer == ChessPiece.PieceColor.White) ? ChessPiece.PieceColor.Black : ChessPiece.PieceColor.White;
        }
    }

    private Vector2Int GetTileAtMousePosition()
    {
        // Implement logic to convert mouse position to chessboard tile coordinates
        // You may need to use raycasting to determine the clicked tile
        // This will depend on how your chessboard and tiles are set up
        // For this example, let's assume that you have a function that can convert screen position to tile coordinates
        return Chessboard.Instance.GetTileCoordinatesAtMousePosition(Input.mousePosition);
    }

    public ChessPiece.PieceColor CurrentPlayerColor(){
        return currentPlayer;
    }

}
