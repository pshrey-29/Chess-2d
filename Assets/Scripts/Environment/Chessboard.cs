using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chess.Environment
{
    public class Chessboard : MonoBehaviour
    {
        [Serializable]
        public struct PiecePrefabs
        {
            public GameObject pawnPrefabDark;
            public GameObject rookPrefabDark;
            public GameObject knightPrefabDark;
            public GameObject bishopPrefabDark;
            public GameObject queenPrefabDark;
            public GameObject kingPrefabDark;
            public GameObject pawnPrefabLight;
            public GameObject rookPrefabLight;
            public GameObject knightPrefabLight;
            public GameObject bishopPrefabLight;
            public GameObject queenPrefabLight;
            public GameObject kingPrefabLight;
        }

        public static Chessboard Instance;
        [SerializeField] private PiecePrefabs piecePrefabs;
        [SerializeField] private Transform chessPieceParent, gridContainer;
        [SerializeField] private Tile tilePrefab;
        private ChessPiece[,] pieces = new ChessPiece[8, 8];
        private List<ChessPiece> allChessPieces = new List<ChessPiece>();
        private ChessGrid grid;
        private ChessboardInitializer chessboardInitializer;

        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(gameObject);

            Init();
        }

        private void Init()
        {
            grid = new ChessGrid(tilePrefab, Camera.main.transform, gridContainer);
            chessboardInitializer = new ChessboardInitializer(grid, this, piecePrefabs, chessPieceParent);
        }

        public void SetPiece(Vector2Int position, ChessPiece piece)
        {
            pieces[position.x, position.y] = piece;
        }

        public ChessPiece GetPiece(Vector2Int position)
        {
            if (IsValidPosition(position))
                return pieces[position.x, position.y];
            return null;
        }

        public void RegisterChessPiece(ChessPiece piece)
        {
            allChessPieces.Add(piece);
        }

        public void UnregisterChessPiece(ChessPiece piece)
        {
            allChessPieces.Remove(piece);
        }

        public List<ChessPiece> GetAllChessPieces()
        {
            return allChessPieces;
        }

        public Tile GetTile(Vector2Int position)
        {
            if (IsValidPosition(position))
            {
                return grid.GetTileAtPos(new Vector2Int(position.x, position.y));
            }

            return null;
        }

        public List<Tile> GetAllTiles()
        {
            List<Tile> allTiles = new List<Tile>();
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    Tile tile = GetTile(new Vector2Int(x, y));
                    if (tile != null)
                    {
                        allTiles.Add(tile);
                    }
                }
            }

            return allTiles;
        }

        public Vector2Int GetTileCoordinatesAtMousePosition(Vector3 mousePosition)
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(mousePosition);
            int layerMask = LayerMask.GetMask("Tile");

            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, Mathf.Infinity, layerMask);

            if (hit)
            {
                // Debug.Log("Hit collider: " + hit.collider.gameObject.name);
                Tile tile = hit.collider.GetComponent<Tile>();
                if (tile != null)
                {
                    string[] nameParts = tile.name.Split(' ');
                    if (nameParts.Length == 3 && int.TryParse(nameParts[1], out int x) && int.TryParse(nameParts[2], out int y))
                    {
                        return new Vector2Int(x, y);
                    }
                }
            }

            return new Vector2Int(-1, -1); // Invalid coordinates
        }

        public bool IsOccupiedByOpponent(Vector2Int position, ChessPiece.PieceColor currentPlayerColor)
        {
            ChessPiece piece = GetPiece(position);
            return piece != null && piece.pieceColor != currentPlayerColor;
        }

        public bool IsOccupied(Vector2Int position)
        {
            if (IsValidPosition(position))
                return pieces[position.x, position.y] != null;
            return false;
        }

        public bool IsValidPosition(Vector2Int position)
        {
            return position.x >= 0 && position.x < 8 && position.y >= 0 && position.y < 8;
        }

        public void HighlightAvailableMoves(List<Vector2Int> availableMoves)
        {
            foreach (Vector2Int move in availableMoves)
            {
                Tile tile = GetTile(move);
                if (tile != null)
                {
                    tile.HighlighTileAvailableMove();
                }
            }
        }

        public void ClearAllHighlights()
        {
            List<Tile> allTiles = GetAllTiles();
            foreach (var tile in allTiles)
            {
                if (tile != null)
                {
                    tile.ClearHighlight();
                }
            }
        }
    }
}