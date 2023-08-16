using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    private int width = 8, height = 8;
    [SerializeField] private Tile tilePrefab;
    [SerializeField] private Transform cam;

    private Dictionary<Vector2Int, Tile> tiles;

    void GenerateGrid() {
        tiles = new Dictionary<Vector2Int, Tile>();
        for(int x=0; x<width; x++){
            for(int y=0; y<height; y++){
                var spawnedTile = Instantiate(tilePrefab, new Vector3(x,y), Quaternion.identity, gameObject.transform);
                spawnedTile.name = $"Tile {x} {y}";

                bool isOffset = (x+y)%2 == 1;
                spawnedTile.FillColor(isOffset);

                tiles[new Vector2Int(x,y)] = spawnedTile;
            }
        }

        cam.transform.position = new Vector3((float)width/2 -0.5f, (float)height/2 -0.5f, -10);
    }

    // Start is called before the first frame update
    void Start()
    {
        GenerateGrid();   
    }

    public Tile GetTileAtPos(Vector2Int pos){
        if(tiles.TryGetValue(pos, out var tile)){
            return tile;
        }

        return null;
    }
}
