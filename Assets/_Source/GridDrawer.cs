using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class GridDrawer : MonoBehaviour
{
    [SerializeField] GridLayoutGroup _glGroup;

    [Inject] Grid _grid;
    [Inject] Points _points;
    [SerializeField] private TextMeshProUGUI _textPrefab;
    [SerializeField] Vector2Int _gridSize;
    private TextMeshProUGUI[,] _fields;
    private void Start()
    {
        _grid.Construct(_gridSize, this, _points);
        _fields = new TextMeshProUGUI[_gridSize.x, _gridSize.y];

        _glGroup.constraintCount = _grid.CellGrid.GetLength(1);

        for (int x = 0; x < _grid.CellGrid.GetLength(0); x++)
            for (int y = 0; y < _grid.CellGrid.GetLength(1); y++)
                _fields[x,y] = Instantiate(_textPrefab, _glGroup.transform);

        _glGroup.cellSize = new Vector2(_glGroup.GetComponent<RectTransform>().rect.width/_gridSize.x,
            _glGroup.GetComponent<RectTransform>().rect.height / _gridSize.y);

        RedrawGrid();
    }

    public void RedrawGrid()
    {
        for (int x = 0; x < _grid.CellGrid.GetLength(0); x++)
            for (int y = 0; y < _grid.CellGrid.GetLength(1); y++)
                _fields[x, y].text = _grid.CellGrid[x, y].ToString();
    }
}
