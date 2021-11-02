using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{

    public GameObject tilePrefab;

    public Sprite[] tileSprites;

    GameObject[,] gridTiles;

    public int gridWidth;
    public int gridHeight;

    // Start is called before the first frame update
    void Start()
    {
        gridTiles = new GameObject[gridWidth, gridHeight];
        for(int x = 0; x < gridWidth; x++)
        {
            for(int y = 0; y < gridHeight; y++)
            {
                MakeTile(x, y);
            }
        }
        //Debug.Log(gridTiles[0, 0].GetComponent<SpriteRenderer>().sprite);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MakeTile(int xPos, int yPos) {
        GameObject newTile = Instantiate(tilePrefab);
        int randTile = Random.Range(0, tileSprites.Length);
        newTile.GetComponent<SpriteRenderer>().sprite = tileSprites[randTile];
        newTile.transform.position = new Vector3(transform.position.x + xPos, transform.position.y + yPos, 0);
        TileData myData = newTile.GetComponent<TileData>();
        if(randTile == 0)
        {
            myData.tileSpeed = 4;
        } else if(randTile == 1)
        {
            myData.tileSpeed = 1;
        } else if(randTile == 2)
        {
            myData.tileSpeed = 7;
        }
        myData.gridX = xPos;
        myData.gridY = yPos;
        gridTiles[xPos, yPos] = newTile;
    }
}
