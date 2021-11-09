using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeRenderer : MonoBehaviour
{
    [SerializeField]
    [Range(1, 50)] // limits the maze width from anywhere between 1 and 50
    private int width = 10; // default value is 10, can be changed

    [SerializeField]
    [Range(1, 50)] // limits the maze height from anywhere between 1 and 50
    private int height = 10; // default value is 10, can be changed

    [SerializeField]
    private Transform wallPrefab = null; // generating private field for the wall prefab

    [SerializeField]
    private float size = 1f; // generating the size of the walls

    [SerializeField]
    private Transform floorPrefab = null; // generating private field for the floor prefab

    // Start is called before the first frame update
    void Start()
    {
        var maze = MazeGenerator.Generate(width, height); // generate the maze within width and height limiters
        Draw(maze); // create the maze
    }

    private void Draw(WallState[,] maze) // method for drawing the maze
    {
        var floor = Instantiate(floorPrefab, transform); // create the floor prefab first
        floor.localScale = new Vector3(width, 1, height); // floor is as large as the width times the height

        for (int i = 0; i < width; ++i) // for the width of the maze limit
        {
            for (int j = 0; j < height; ++j) // for the length of the maze limit
            {
                var cell = maze[i, j]; // generate a cell at the point i, j
                var position = new Vector3(-width / 2 + i, 0, -height / 2 + j); // generate a new wall position

                if (cell.HasFlag(WallState.UP)) // if the cell has a wall at the top
                {
                    var topWall = Instantiate(wallPrefab, transform) as Transform;
                    topWall.position = position + new Vector3(0, 0, size); // generates a new top wall to the top edge of the cell
                    topWall.localScale = new Vector3(size * 2, topWall.localScale.y, topWall.localScale.z);
                }
                if (cell.HasFlag(WallState.LEFT)) // if the cell has a wall to the left
                {
                    var leftWall = Instantiate(wallPrefab, transform) as Transform;
                    leftWall.position = position + new Vector3(-size, 0, 0); // generates a new left wall to the left edge of the cell
                    leftWall.localScale = new Vector3(size * 2, leftWall.localScale.y, leftWall.localScale.z);
                    leftWall.eulerAngles = new Vector3(0, 90, 0);
                }
                if (i == width - 1) // if the cell is to the furthest right
                {
                    if (cell.HasFlag(WallState.RIGHT)) // if the cell has a wall to the right
                    {
                        var rightWall = Instantiate(wallPrefab, transform) as Transform;
                        rightWall.position = position + new Vector3(size, 0, 0); // generate a new right wall to the right edge of the cell
                        rightWall.localScale = new Vector3(size * 2, rightWall.localScale.y, rightWall.localScale.z);
                        rightWall.eulerAngles = new Vector3(0, 90, 0);
                    }
                }
                if(j == 0) // if the cell is at the bottom of the board
                {
                    if (cell.HasFlag(WallState.DOWN)) // if the cell has a wall at the bottom
                    {
                        var bottomWall = Instantiate(wallPrefab, transform) as Transform;
                        bottomWall.position = position + new Vector3(0, 0, -size); // generate a new bottom wall on the bottom edge of the cell
                        bottomWall.localScale = new Vector3(size * 2, bottomWall.localScale.y, bottomWall.localScale.z);
                    }
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
