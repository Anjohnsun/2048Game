using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameInput : MonoBehaviour
{
    [Inject] private GridHandler _grid;

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            _grid.MoveCells(Directions.Left);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            _grid.MoveCells(Directions.Right);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _grid.MoveCells(Directions.Up);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            _grid.MoveCells(Directions.Down);
        }

    }

    public void OnRightButtonClick()
    {
        _grid.MoveCells(Directions.Down);
    }
    public void OnLeftButtonClick()
    {
        _grid.MoveCells(Directions.Up);
    }
    public void OnUpButtonClick()
    {
        _grid.MoveCells(Directions.Left);
    }
    public void OnDownButtonClick()
    {
        _grid.MoveCells(Directions.Right);
    }
}
