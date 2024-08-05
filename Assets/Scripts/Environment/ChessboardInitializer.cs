using UnityEngine;

namespace Chess.Environment
{
    public class ChessboardInitializer
    {
        private GameObject pawnPrefabDark;
        private GameObject rookPrefabDark;
        private GameObject knightPrefabDark;
        private GameObject bishopPrefabDark;
        private GameObject queenPrefabDark;
        private GameObject kingPrefabDark;
        private GameObject pawnPrefabLight;
        private GameObject rookPrefabLight;
        private GameObject knightPrefabLight;
        private GameObject bishopPrefabLight;
        private GameObject queenPrefabLight;
        private GameObject kingPrefabLight;

        private ChessGrid grid;
        private Chessboard chessboard;
        private Transform chessPieceParent;

        public ChessboardInitializer(ChessGrid a_grid, Chessboard a_chessboard, Chessboard.PiecePrefabs a_piecePrefabs, Transform a_chessPieceParent)
        {
            this.grid = a_grid;
            this.chessboard = a_chessboard;
            this.chessPieceParent = a_chessPieceParent;

            //Setting piece prefabs
            pawnPrefabDark = a_piecePrefabs.pawnPrefabDark;
            rookPrefabDark = a_piecePrefabs.rookPrefabDark;
            knightPrefabDark = a_piecePrefabs.knightPrefabDark;
            bishopPrefabDark = a_piecePrefabs.bishopPrefabDark;
            queenPrefabDark = a_piecePrefabs.queenPrefabDark;
            kingPrefabDark = a_piecePrefabs.kingPrefabDark;
            pawnPrefabLight = a_piecePrefabs.pawnPrefabLight;
            rookPrefabLight = a_piecePrefabs.rookPrefabLight;
            knightPrefabLight = a_piecePrefabs.knightPrefabLight;
            bishopPrefabLight = a_piecePrefabs.bishopPrefabLight;
            queenPrefabLight = a_piecePrefabs.queenPrefabLight;
            kingPrefabLight = a_piecePrefabs.kingPrefabLight;

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
                        GameObject pawn = GameObject.Instantiate(pawnPrefabToInstantiate,
                            grid.GetTileAtPos(new Vector2Int(x, y)).transform.position,
                            Quaternion.identity,
                            chessPieceParent);

                        ChessPiece chessPiece = pawn.GetComponent<Pawn>();
                        chessPiece.currentPosition = new Vector2Int(x, y);

                        chessboard.SetPiece(new Vector2Int(x, y), chessPiece);
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
                            GameObject piece = GameObject.Instantiate(piecePrefab,
                            grid.GetTileAtPos(new Vector2Int(x, y)).transform.position,
                            Quaternion.identity,
                            chessPieceParent);

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
                                chessPiece.currentPosition = new Vector2Int(x, y);

                                chessboard.SetPiece(new Vector2Int(x, y), chessPiece);
                            }
                        }
                    }
                }
            }
        }
    }
}
