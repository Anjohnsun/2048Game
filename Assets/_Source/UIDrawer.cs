using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class UIDrawer : MonoBehaviour
{
    [Inject] GridHandler _gridHandler;
    [SerializeField] private GameObject _endPanel;

    private void Start()
    {
        _endPanel.SetActive(false);
    }

    public void ShowEndPanel()
    {
        _endPanel.SetActive(true);
    }

    public void ResetGrid()
    {
        _endPanel.SetActive(false); 
        _gridHandler.RecreateGrid();
        AppMetrica.Instance.ReportEvent("GameRestarted");
    }
}
