using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chess.Environment
{
    public class ChessGrid
    {
        private int width = 8, height = 8;
        private Tile tilePrefab;
        private Transform cam, gridContainer;
        private Dictionary<Vector2Int, Tile> tiles;
        
        public ChessGrid(Tile a_tilePrefab, Transform a_cam, Transform a_gridContainer)
        {
            tilePrefab = a_tilePrefab;
            cam = a_cam;
            gridContainer = a_gridContainer;

            GenerateGrid();
        }



        void GenerateGrid()
        {
            tiles = new Dictionary<Vector2Int, Tile>();
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    var spawnedTile = GameObject.Instantiate(tilePrefab, new Vector3(x, y), Quaternion.identity, gridContainer);
                    spawnedTile.name = $"Tile {x} {y}";

                    bool isOffset = (x + y) % 2 == 1;
                    spawnedTile.FillColor(isOffset);

                    tiles[new Vector2Int(x, y)] = spawnedTile;
                }
            }

            cam.transform.position = new Vector3((float)width / 2 - 0.5f, (float)height / 2 - 0.5f, -10);
        }

        public Tile GetTileAtPos(Vector2Int pos)
        {
            if (tiles.TryGetValue(pos, out var tile))
            {
                return tile;
            }

            return null;
        }
    }
}