using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessboardInitializer : MonoBehaviour
{
    [SerializeField] private GameObject pawnPrefabDark;
    [SerializeField] private GameObject rookPrefabDark;
    [SerializeField] private GameObject knightPrefabDark;
    [SerializeField] private GameObject bishopPrefabDark;
    [SerializeField] private GameObject queenPrefabDark;
    [SerializeField] private GameObject kingPrefabDark;
    [SerializeField] private GameObject pawnPrefabLight;
    [SerializeField] private GameObject rookPrefabLight;
    [SerializeField] private GameObject knightPrefabLight;
    [SerializeField] private GameObject bishopPrefabLight;
    [SerializeField] private GameObject queenPrefabLight;
    [SerializeField] private GameObject kingPrefabLight;

    private GridGenerator gridGenerator;
    private Chessboard chessboard;

    // Start is called before the first frame update
    void Start()
    {
        gridGenerator = FindObjectOfType<GridGenerator>();
        chessboard = Chessboard.Instance;

        GenerateChessboard();
    }

    private void GenerateChessboard()
    {
        for (int x = 0; x < 8; x++)
        {
            for (int y = 0; y < 8; y++)
            {
                // Generate pawns for both white and black sides
                if (y == 1 || y == 6)
                {
                    GameObject pawnPrefabToInstantiate = (y == 1) ? pawnPrefabLight : pawnPrefabDark;
                    GameObject pawn = Instantiate(pawnPrefabToInstantiate, 
                        gridGenerator.GetTileAtPos(new Vector2Int(x, y)).transform.position, 
                        Quaternion.identity,
                        gameObject.transform);

                    ChessPiece chessPiece = pawn.GetComponent<Pawn>();
                    chessPiece.currentX = x;
                    chessPiece.currentY = y;

                    chessboard.SetPiece(new Vector2Int(x, y), chessPiece);
                    // ...
                }

                // Generate other pieces for the starting position
                if (y == 0 || y == 7)
                {
                    GameObject piecePrefab = null;
                    if (x == 0 || x == 7)
                        piecePrefab = (y == 0) ? rookPrefabLight : rookPrefabDark;
                    else if (x == 1 || x == 6)
                        piecePrefab = (y == 0) ? knightPrefabLight : knightPrefabDark;
                    else if (x == 2 || x == 5)
                        piecePrefab = (y == 0) ? bishopPrefabLight : bishopPrefabDark;
                    else if (x == 3)
                        piecePrefab = (y == 0) ? queenPrefabLight : queenPrefabDark;
                    else if (x == 4)
                        piecePrefab = (y == 0) ? kingPrefabLight : kingPrefabDark;

                    if (piecePrefab != null)
                    {
                        GameObject piece = Instantiate(piecePrefab, 
                        gridGenerator.GetTileAtPos(new Vector2Int(x, y)).transform.position, 
                        Quaternion.identity,
                        gameObject.transform);

                        ChessPiece chessPiece = null;
                        if (piecePrefab == rookPrefabLight || piecePrefab == rookPrefabDark)
                        {
                            chessPiece = piece.GetComponent<Rook>();
                        }
                        else if (piecePrefab == knightPrefabLight || piecePrefab == knightPrefabDark)
                        {
                            chessPiece = piece.GetComponent<Knight>();
                        }
                        else if (piecePrefab == bishopPrefabLight || piecePrefab == bishopPrefabDark)
                        {
                            chessPiece = piece.GetComponent<Bishop>();
                        }
                        else if (piecePrefab == queenPrefabLight || piecePrefab == queenPrefabDark)
                        {
                            chessPiece = piece.GetComponent<Queen>();
                        }
                        else if (piecePrefab == kingPrefabLight || piecePrefab == kingPrefabDark)
                        {
                            chessPiece = piece.GetComponent<King>();
                        }

                        if (chessPiece != null)
                        {
                            chessPiece.currentX = x;
                            chessPiece.currentY = y;

                            chessboard.SetPiece(new Vector2Int(x, y), chessPiece);
                        }
                    }
                }
            }
        }
    }
}
