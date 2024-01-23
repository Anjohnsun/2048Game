using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridHandler
{
    private GridDrawer _gridDrawer;
    private UIDrawer _uiDrawer;
    private Points _points;
    private Grid _grid;
    public Grid Grid
    {
        get => _grid;
    }

    private int _movements = 0;

    public void Construct(Vector2Int gridSize, GridDrawer drawer, Points points, UIDrawer uiDrawer)
    {
        _grid = new Grid(gridSize);
        _gridDrawer = drawer;
        _points = points;
        _uiDrawer = uiDrawer;

        AddRandomEmptyCell();
        AddRandomEmptyCell();

        AppMetrica.Instance.ReportEvent("Game Started");
    }

    public void RecreateGrid()
    {
        _grid = new Grid(new Vector2Int(_grid.CellGrid.GetLength(0), _grid.CellGrid.GetLength(1)));
        _points.SetToZero();

        AddRandomEmptyCell();
        AddRandomEmptyCell();

        _gridDrawer.RedrawGrid();
    }

    public void MoveCells(Directions direction)
    {
        _movements++;

        if (direction == Directions.Up)
        {
            AppMetrica.Instance.ReportEvent("Move UP");
            for (int x = 0; x < _grid.CellGrid.GetLength(0); x++)
                for (int y = 1; y < _grid.CellGrid.GetLength(1); y++)
                {
                    if (_grid.CellGrid[x, y] != 0)
                    {
                        int targetLevel = 0;
                        for (int z = y - 1; z >= 0; z--)
                        {
                            if (_grid.CellGrid[x, z] == 0)
                                continue;
                            else if (_grid.CellGrid[x, z] != 0 && _grid.CellGrid[x, z] != _grid.CellGrid[x, y])
                            {
                                targetLevel = z + 1;
                                break;
                            }
                            else if (_grid.CellGrid[x, z] == _grid.CellGrid[x, y])
                            {
                                targetLevel = z;
                                break;
                            }
                        }

                        if (targetLevel == y)
                            continue;
                        if (_grid.CellGrid[x, targetLevel] == _grid.CellGrid[x, y])
                        {
                            _points.AddPoints(_grid.CellGrid[x, y]);
                            _grid.CellGrid[x, y] = 0;
                            _grid.CellGrid[x, targetLevel] *= 2;

                            //add movement info
                        }
                        else
                        {
                            _grid.CellGrid[x, targetLevel] = _grid.CellGrid[x, y];
                            _grid.CellGrid[x, y] = 0;
                        }
                    }
                }
        }
        else if (direction == Directions.Down)
        {
            AppMetrica.Instance.ReportEvent("Move DOWN");
            for (int x = 0; x < _grid.CellGrid.GetLength(0); x++)
                for (int y = _grid.CellGrid.GetLength(1) - 2; y >= 0; y--)
                {
                    if (_grid.CellGrid[x, y] != 0)
                    {
                        int targetLevel = _grid.CellGrid.GetLength(1) - 1;
                        for (int z = y + 1; z < _grid.CellGrid.GetLength(1); z++)
                        {
                            if (_grid.CellGrid[x, z] == 0)
                                continue;
                            else if (_grid.CellGrid[x, z] != 0 && _grid.CellGrid[x, z] != _grid.CellGrid[x, y])
                            {
                                targetLevel = z - 1;
                                break;
                            }
                            else if (_grid.CellGrid[x, z] == _grid.CellGrid[x, y])
                            {
                                targetLevel = z;
                                break;
                            }
                        }

                        if (targetLevel == y)
                            continue;
                        if (_grid.CellGrid[x, targetLevel] == _grid.CellGrid[x, y])
                        {
                            _points.AddPoints(_grid.CellGrid[x, y]);
                            _grid.CellGrid[x, y] = 0;
                            _grid.CellGrid[x, targetLevel] *= 2;

                            //add movement info
                        }
                        else
                        {
                            _grid.CellGrid[x, targetLevel] = _grid.CellGrid[x, y];
                            _grid.CellGrid[x, y] = 0;
                        }

                    }
                }
        }
        else if (direction == Directions.Right)
        {
            AppMetrica.Instance.ReportEvent("Move RIGHT");
            for (int x = _grid.CellGrid.GetLength(0) - 2; x >= 0; x--)
                for (int y = 0; y < _grid.CellGrid.GetLength(1); y++)
                {
                    if (_grid.CellGrid[x, y] != 0)
                    {
                        int targetLevel = _grid.CellGrid.GetLength(0) - 1;
                        for (int z = x + 1; z < _grid.CellGrid.GetLength(0); z++)
                        {
                            if (_grid.CellGrid[z, y] == 0)
                                continue;
                            else if (_grid.CellGrid[z, y] != 0 && _grid.CellGrid[z, y] != _grid.CellGrid[x, y])
                            {
                                targetLevel = z - 1;
                                break;
                            }
                            else if (_grid.CellGrid[z, y] == _grid.CellGrid[x, y])
                            {
                                targetLevel = z;
                                break;
                            }
                        }

                        if (targetLevel == x)
                            continue;
                        if (_grid.CellGrid[targetLevel, y] == _grid.CellGrid[x, y])
                        {
                            _points.AddPoints(_grid.CellGrid[x, y]);
                            _grid.CellGrid[x, y] = 0;
                            _grid.CellGrid[targetLevel, y] *= 2;

                            //add movement info
                        }
                        else
                        {
                            _grid.CellGrid[targetLevel, y] = _grid.CellGrid[x, y];
                            _grid.CellGrid[x, y] = 0;
                        }

                    }
                }
        }
        else if (direction == Directions.Left)
        {
            AppMetrica.Instance.ReportEvent("Move LEFT");
            for (int x = 1; x < _grid.CellGrid.GetLength(1); x++)
                for (int y = 0; y < _grid.CellGrid.GetLength(1); y++)
                {
                    if (_grid.CellGrid[x, y] != 0)
                    {
                        int targetLevel = 0;
                        for (int z = x - 1; z >= 0; z--)
                        {
                            if (_grid.CellGrid[z, y] == 0)
                                continue;
                            else if (_grid.CellGrid[z, y] != 0 && _grid.CellGrid[z, y] != _grid.CellGrid[x, y])
                            {
                                targetLevel = z + 1;
                                break;
                            }
                            else if (_grid.CellGrid[z, y] == _grid.CellGrid[x, y])
                            {
                                targetLevel = z;
                                break;
                            }
                        }

                        if (targetLevel == x)
                            continue;
                        if (_grid.CellGrid[targetLevel, y] == _grid.CellGrid[x, y])
                        {
                            _points.AddPoints(_grid.CellGrid[x, y]);
                            _grid.CellGrid[x, y] = 0;
                            _grid.CellGrid[targetLevel, y] *= 2;

                            //add movement info
                        }
                        else
                        {
                            _grid.CellGrid[targetLevel, y] = _grid.CellGrid[x, y];
                            _grid.CellGrid[x, y] = 0;
                        }

                    }
                }
        }

        if (CheckEnd())
        {
            _uiDrawer.ShowEndPanel();
            AppMetrica.Instance.ReportEvent("Game Ended");
            AppMetrica.Instance.ReportEvent("Results of the game:", GetTheInfoOfGame());
        }
        else
            AddRandomEmptyCell();


        _gridDrawer.RedrawGrid();
    }

    private IDictionary<string, object> GetTheInfoOfGame()
    {
        IDictionary<string, object> results = new Dictionary<string, object>();
        
        int max = 0;
        int sum = 0;

        for (int x = 0; x < _grid.CellGrid.GetLength(1); x++)
            for (int y = 0; y < _grid.CellGrid.GetLength(1); y++)
            {
                if (_grid.CellGrid[x, y] > max)
                    max = _grid.CellGrid[x,y];
                sum += _grid.CellGrid[x, y];
            }

        results.Add("Max value", max);
        results.Add("Average value", sum / (_grid.CellGrid.GetLength(0)+ _grid.CellGrid.GetLength(1)));
        results.Add("Movements done", _movements);

        return results;
    }

    private bool CheckEnd()
    {
        for (int x = 1; x < _grid.CellGrid.GetLength(1); x++)
            for (int y = 0; y < _grid.CellGrid.GetLength(1); y++)
            {
                if (_grid.CellGrid[x, y] == 0)
                    return false;
            }

        //up slide check
        for (int x = 0; x < _grid.CellGrid.GetLength(1); x++)
            for (int y = 1; y < _grid.CellGrid.GetLength(1); y++)
            {
                if (_grid.CellGrid[x, y] == _grid.CellGrid[x, y - 1] || _grid.CellGrid[x, y - 1] == 0)
                    return false;
            }
        //down slide check
        for (int x = 0; x < _grid.CellGrid.GetLength(1); x++)
            for (int y = 0; y < _grid.CellGrid.GetLength(1) - 1; y++)
            {
                if (_grid.CellGrid[x, y] == _grid.CellGrid[x, y + 1] || _grid.CellGrid[x, y + 1] == 0)
                    return false;
            }
        //right slide check
        for (int x = 0; x < _grid.CellGrid.GetLength(1) - 1; x++)
            for (int y = 0; y < _grid.CellGrid.GetLength(1); y++)
            {
                if (_grid.CellGrid[x, y] == _grid.CellGrid[x + 1, y] || _grid.CellGrid[x + 1, y] == 0)
                    return false;
            }
        //left slide check
        for (int x = 1; x < _grid.CellGrid.GetLength(1); x++)
            for (int y = 0; y < _grid.CellGrid.GetLength(1); y++)
            {
                if (_grid.CellGrid[x, y] == _grid.CellGrid[x - 1, y] || _grid.CellGrid[x - 1, y] == 0)
                    return false;
            }

        return true;
    }

    private void AddRandomEmptyCell()
    {
        bool emptyCellExists = false;
        for (int x = 0; x < _grid.CellGrid.GetLength(1); x++)
            for (int y = 0; y < _grid.CellGrid.GetLength(1); y++)
            {
                if (_grid.CellGrid[x, y] == 0)
                {
                    emptyCellExists = true;
                }
            }

        if (emptyCellExists)
        {
            int x2, y2;
            do
            {
                x2 = Random.Range(0, _grid.CellGrid.GetLength(0));
                y2 = Random.Range(0, _grid.CellGrid.GetLength(1));
            } while (_grid.CellGrid[x2, y2] != 0);

            _grid.CellGrid[x2, y2] = 2;
        } else
        {
            Debug.Log("No empty cells!");
        }

    }
}
