using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class GridDrawer : MonoBehaviour
{
    [SerializeField] GridLayoutGroup _glGroup;

    [Inject] GridHandler _gridHandler;
    [Inject] Points _points;
    [SerializeField] private TextMeshProUGUI _textPrefab;
    [SerializeField] Vector2Int _gridSize;
    [SerializeField] UIDrawer _uiDrawer;
    private TextMeshProUGUI[,] _fields;

    private void Start()
    {
        _gridHandler.Construct(_gridSize, this, _points, _uiDrawer);
        _fields = new TextMeshProUGUI[_gridSize.x, _gridSize.y];

        _glGroup.constraintCount = _gridHandler.Grid.CellGrid.GetLength(1);

        for (int x = 0; x < _gridHandler.Grid.CellGrid.GetLength(0); x++)
            for (int y = 0; y < _gridHandler.Grid.CellGrid.GetLength(1); y++)
                _fields[x, y] = Instantiate(_textPrefab, _glGroup.transform);

        _glGroup.cellSize = new Vector2(_glGroup.GetComponent<RectTransform>().rect.width / _gridSize.x,
            _glGroup.GetComponent<RectTransform>().rect.height / _gridSize.y);

        RedrawGrid();
    }

    public void RedrawGrid()
    {
        for (int x = 0; x < _gridHandler.Grid.CellGrid.GetLength(0); x++)
            for (int y = 0; y < _gridHandler.Grid.CellGrid.GetLength(1); y++)
                _fields[x, y].text = _gridHandler.Grid.CellGrid[x, y].ToString();
    }
}
