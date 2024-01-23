using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Points : MonoBehaviour
{
    private int _points;
    [SerializeField] private TextMeshProUGUI _text;
    void Start()
    {
        _points = 0;
    }

    public void AddPoints(int value)
    {
        _points += value*2;
        UpdateText();
    }

    private void UpdateText()
    {
        _text.text = _points.ToString();
    }

    public void SetToZero()
    {
        _points = 0;
        UpdateText();
    }
}
