using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid
{
    private int[,] _cellGrid;
    private Points _points;
    private GridDrawer _drawer;

    public int[,] CellGrid => _cellGrid;

    public void Construct(Vector2Int gridSize, GridDrawer drawer, Points points)
    {
        CreateGrid(gridSize.x, gridSize.y);
        _drawer = drawer;
        _points = points;
    }

    private void CreateGrid(int width, int height)
    {
        _cellGrid = new int[width, height];
        for (int x = 0; x < _cellGrid.GetLength(0); x++)
            for (int y = 0; y < _cellGrid.GetLength(1); y++)
            {
                {
                    _cellGrid[x, y] = new int();
                }
            }

        AddRandomEmptyCell();
        AddRandomEmptyCell();
        AddRandomEmptyCell();
    }

    public void MoveCells(Directions direction)
    {
        if (direction == Directions.Up)
        {
            for (int x = 0; x < _cellGrid.GetLength(0); x++)
                for (int y = 1; y < _cellGrid.GetLength(1); y++)
                {
                    if (_cellGrid[x, y] != 0)
                    {
                        int targetLevel = 0;
                        for (int z = y - 1; z >= 0; z--)
                        {
                            if (_cellGrid[x, z] == 0)
                                continue;
                            else if (_cellGrid[x, z] != 0 && _cellGrid[x, z] != _cellGrid[x, y])
                            {
                                targetLevel = z + 1;
                                break;
                            }
                            else if (_cellGrid[x, z] == _cellGrid[x, y])
                            {
                                targetLevel = z;
                                break;
                            }
                        }

                        if (targetLevel == y)
                            continue;
                        if (_cellGrid[x, targetLevel] == _cellGrid[x, y])
                        {
                            _points.AddPoints(_cellGrid[x, y]);
                            _cellGrid[x, y] = 0;
                            _cellGrid[x, targetLevel] *= 2;

                            //add movement info
                        }
                        else
                        {
                            _cellGrid[x, targetLevel] = _cellGrid[x, y];
                            _cellGrid[x, y] = 0;
                        }
                    }
                }
        }
        else if (direction == Directions.Down)
        {
            for (int x = 0; x < _cellGrid.GetLength(0); x++)
                for (int y = _cellGrid.GetLength(1) - 2; y >= 0; y--)
                {
                    if (_cellGrid[x, y] != 0)
                    {
                        int targetLevel = _cellGrid.GetLength(1) - 1;
                        for (int z = y + 1; z < _cellGrid.GetLength(1); z++)
                        {
                            if (_cellGrid[x, z] == 0)
                                continue;
                            else if (_cellGrid[x, z] != 0 && _cellGrid[x, z] != _cellGrid[x, y])
                            {
                                targetLevel = z - 1;
                                break;
                            }
                            else if (_cellGrid[x, z] == _cellGrid[x, y])
                            {
                                targetLevel = z;
                                break;
                            }
                        }

                        if (targetLevel == y)
                            continue;
                        if (_cellGrid[x, targetLevel] == _cellGrid[x, y])
                        {
                            _points.AddPoints(_cellGrid[x, y]);
                            _cellGrid[x, y] = 0;
                            _cellGrid[x, targetLevel] *= 2;

                            //add movement info
                        }
                        else
                        {
                            _cellGrid[x, targetLevel] = _cellGrid[x, y];
                            _cellGrid[x, y] = 0;
                        }

                    }
                }
        }
        else if (direction == Directions.Right)
        {
            for (int x = _cellGrid.GetLength(0) - 2; x >= 0; x--)
                for (int y = 0; y < _cellGrid.GetLength(1); y++)
                {
                    if (_cellGrid[x, y] != 0)
                    {
                        int targetLevel = _cellGrid.GetLength(0) - 1;
                        for (int z = x + 1; z < _cellGrid.GetLength(0); z++)
                        {
                            if (_cellGrid[z, y] == 0)
                                continue;
                            else if (_cellGrid[z, y] != 0 && _cellGrid[z, y] != _cellGrid[x, y])
                            {
                                targetLevel = z - 1;
                                break;
                            }
                            else if (_cellGrid[z, y] == _cellGrid[x, y])
                            {
                                targetLevel = z;
                                break;
                            }
                        }

                        if (targetLevel == x)
                            continue;
                        if (_cellGrid[targetLevel, y] == _cellGrid[x, y])
                        {
                            _points.AddPoints(_cellGrid[x, y]);
                            _cellGrid[x, y] = 0;
                            _cellGrid[targetLevel, y] *= 2;

                            //add movement info
                        }
                        else
                        {
                            _cellGrid[targetLevel, y] = _cellGrid[x, y];
                            _cellGrid[x, y] = 0;
                        }

                    }
                }
        }
        else if (direction == Directions.Left)
        {
            for (int x = 1; x < _cellGrid.GetLength(1); x++)
                for (int y = 0; y < _cellGrid.GetLength(1); y++)
                {
                    if (_cellGrid[x, y] != 0)
                    {
                        int targetLevel = 0;
                        for (int z = x - 1; z >= 0; z--)
                        {
                            if (_cellGrid[z, y] == 0)
                                continue;
                            else if (_cellGrid[z, y] != 0 && _cellGrid[z, y] != _cellGrid[x, y])
                            {
                                targetLevel = z + 1;
                                break;
                            }
                            else if (_cellGrid[z, y] == _cellGrid[x, y])
                            {
                                targetLevel = z;
                                break;
                            }
                        }

                        if (targetLevel == x)
                            continue;
                        if (_cellGrid[targetLevel, y] == _cellGrid[x, y])
                        {
                            _points.AddPoints(_cellGrid[x, y]);
                            _cellGrid[x, y] = 0;
                            _cellGrid[targetLevel, y] *= 2;

                            //add movement info
                        }
                        else
                        {
                            _cellGrid[targetLevel, y] = _cellGrid[x, y];
                            _cellGrid[x, y] = 0;
                        }

                    }
                }
        }

        //if (!CheckEnd())
        AddRandomEmptyCell();

        _drawer.RedrawGrid();
    }

    private bool CheckEnd()
    {
        return false;
    }

    private void AddRandomEmptyCell()
    {
        int x, y;
        do
        {
            x = Random.Range(0, _cellGrid.GetLength(0));
            y = Random.Range(0, _cellGrid.GetLength(1));
        } while (_cellGrid[x, y] != 0);

        _cellGrid[x, y] = 2;
    }
}
