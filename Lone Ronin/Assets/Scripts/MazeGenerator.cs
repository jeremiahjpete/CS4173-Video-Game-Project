using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Flags]
public enum WallState // creating new flags for walls
{
    LEFT = 1,
    RIGHT = 2,
    UP = 4,
    DOWN = 8,

    VISITED = 128, // checking if a cell was visited for creating the maze
}

public struct Position // position coordinates for wall placement
{
    public int X;
    public int Y;
}

public struct Neighbor // Neighbors given so no shared walls are deleted during maze generation
{
    public Position Position; // creating position of wall
    public WallState SharedWall; // Creating a state for the wall so it is shared
}

public static class MazeGenerator // main maze generator
{
    private static WallState GetOppositeWall(WallState wall) // create another wall to create thicker walls
    {
        switch (wall) // switch for the random rotation of the walls
        {
            case WallState.RIGHT : return WallState.LEFT;
            case WallState.LEFT : return WallState.RIGHT;
            case WallState.UP : return WallState.DOWN;
            case WallState.DOWN : return WallState.UP;
            default: return WallState.LEFT;
        }
    }

    private static WallState[,] ApplyRecursiveBacktracker(WallState[,] maze, int width, int height) // recursive backtracker for maze generation with width and height limiters
    {
        var rng = new System.Random(/*seed*/); // random seed generates maze
        var positionStack = new Stack<Position>(); // create a new stack that holds the position of all the walls
        var position = new Position { X = rng.Next(0, width), Y = rng.Next(0, height) }; // create a new random position for the wall
        maze[position.X, position.Y] |= WallState.VISITED; // count the wall just generated as visited so new walls wont be generated on top of it
        positionStack.Push(position); // push the position of the wall onto the stack

        while(positionStack.Count > 0) // while there is still something in the stack
        {
            var current = positionStack.Pop(); // pop the top off the stack
            var neighbors = GetUnvisitedNeighbors(current, maze, width, height); // assigns unvisited neighbors to the variable 'neighbors'
            if(neighbors.Count > 0) // if the count of neighbors is greater than 0
            {
                positionStack.Push(current); // push the current variable
                var randIndex = rng.Next(0, neighbors.Count);
                var randomNeighbor = neighbors[randIndex]; // picks a random neighbor and adds it to a random part of the index
                var nPosition = randomNeighbor.Position; // variable for the position of a random neighbor
                maze[current.X, current.Y] &= ~randomNeighbor.SharedWall; // removes one shared wall so there are no double walls
                maze[nPosition.X, nPosition.Y] &= ~GetOppositeWall(randomNeighbor.SharedWall); // keeps the opposite wall

                maze[nPosition.X, nPosition.Y] |= WallState.VISITED; // marks the cell as visited

                positionStack.Push(nPosition); // push the visited position to the stack
            }
        }

        return maze; // generate the maze
    }

    private static List<Neighbor> GetUnvisitedNeighbors(Position p, WallState[,] maze, int width, int height) // finds unvisited neighbors with width and height limiters
    {
        var list = new List<Neighbor>(); // generate a new list of neighbors
        if(p.X > 0) //left
        {
            if(!maze[p.X - 1, p.Y].HasFlag(WallState.VISITED)) // if the current cell has not been visited
            {
                list.Add(new Neighbor // creates a new neighbor and adds it to the list
                {
                    Position = new Position // adds the position to the list
                    {
                        X = p.X - 1,
                        Y = p.Y
                    },
                    SharedWall = WallState.LEFT // flags the shared wall as the left wall
                });
            }
        }
        if (p.Y > 0) //down
        {
            if (!maze[p.X, p.Y - 1].HasFlag(WallState.VISITED)) // if the current cell has not been visited
            {
                list.Add(new Neighbor // creates a new neighbor and adds it to the list
                {
                    Position = new Position // adds the position to the list
                    {
                        X = p.X,
                        Y = p.Y - 1
                    },
                    SharedWall = WallState.DOWN // flags the shared wall as the bottom wall
                });
            }
        }
        if (p.Y < height - 1) // up
        {
            if (!maze[p.X, p.Y + 1].HasFlag(WallState.VISITED)) // if the current cell has not been visited
            {
                list.Add(new Neighbor // creates a new neighbor and adds it to the list
                {
                    Position = new Position // adds the position to the list
                    {
                        X = p.X,
                        Y = p.Y + 1
                    },
                    SharedWall = WallState.UP // flags the shared wall as the top wall
                });
            }
        }
        if (p.X < width - 1) //right
        {
            if (!maze[p.X + 1, p.Y].HasFlag(WallState.VISITED)) // if the current cell has not been visited
            {
                list.Add(new Neighbor // creates a new neighbor and adds it to the list
                {
                    Position = new Position // adds the position to the lsit
                    {
                        X = p.X + 1,
                        Y = p.Y
                    },
                    SharedWall = WallState.RIGHT // flags the shared wall as the right wall
                });
            }
        }
        return list; // return the list
    }

    public static WallState[,] Generate(int width, int height) // method that gives wall states to each maze wall with width and height limiters
    {
        WallState[,] maze = new WallState[width, height]; // generates a position of a wall in the maze
        WallState initial = WallState.RIGHT | WallState.LEFT | WallState.UP | WallState.DOWN; // generating initial wall states for the walls
        for (int i = 0; i < width; ++i)
        {
            for (int j = 0; j < height; ++j)
            {
                maze[i, j] = initial;
            }
        }



        return ApplyRecursiveBacktracker(maze, width, height); // apply the recursive backtracker to generate the maze
    }
}
