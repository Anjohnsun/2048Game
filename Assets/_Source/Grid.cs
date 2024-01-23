using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid
{
    public int[,] CellGrid;

    public Grid(Vector2Int gridSize)
    {
        CreateGrid(gridSize.x, gridSize.y);
    }

    private void CreateGrid(int width, int height)
    {
        CellGrid = new int[width, height];
        for (int x = 0; x < CellGrid.GetLength(0); x++)
            for (int y = 0; y < CellGrid.GetLength(1); y++)
            {
                {
                    CellGrid[x, y] = new int();
                }
            }
    }
}
