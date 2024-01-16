using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameInput : MonoBehaviour
{
    [Inject] private Grid _grid;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
            _grid.MoveCells(Directions.Left);
        if (Input.GetKeyDown(KeyCode.DownArrow))
            _grid.MoveCells(Directions.Right);
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            _grid.MoveCells(Directions.Up);
        if (Input.GetKeyDown(KeyCode.RightArrow))
            _grid.MoveCells(Directions.Down);
    }
}
